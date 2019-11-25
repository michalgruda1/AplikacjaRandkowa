using AplikacjaRandkowa.Models;
using AplikacjaRandkowa.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace AplikacjaRandkowa.Controllers
{
	public class HomeController : Controller
	{
		[BindProperty]
		public WizardViewModel Wizard { get; set; }

		private readonly ICriteriaBuilder criteriaBuilder;
		private readonly IMatchGovernor matchGovernor;

		public HomeController (ICriteriaBuilder criteriaBuilder, IMatchGovernor matchGovernor)
		{
			this.criteriaBuilder = criteriaBuilder;
			this.matchGovernor = matchGovernor;
		}

		public IActionResult Index()
		{
			return View();
		}

		[AutoValidateAntiforgeryToken]
		[HttpGet]
		public IActionResult Krok1Get()
		{
			Wizard = new WizardViewModel() { Kobieta = null, Mezczyzna = null };
			return View("Kobieta", Wizard);
		}

		[AutoValidateAntiforgeryToken]
		[HttpPost]
		public IActionResult Krok1Post()
		{
			if (!ModelState.IsValid) return View("Kobieta", Wizard);

			return View("Mezczyzna", Wizard);
		}

		[AutoValidateAntiforgeryToken]
		[HttpGet]
		public IActionResult Krok2Get()
		{
			return View("MezczyznaGet");
		}

		[AutoValidateAntiforgeryToken]
		[HttpPost]
		public IActionResult Krok2Post([FromForm] string Kobieta)
		{
			if (!ModelState.IsValid) return View("Mezczyzna", Wizard);

			// pobranie i deserializacja danych kobiety i re-walidacja danych
			KobietaViewModel kobietaVM = null;
			try
			{
				kobietaVM = JsonConvert.DeserializeObject<KobietaViewModel>(Kobieta);
			}
			catch
			{
				RedirectToAction(nameof(Krok1Get));
			}
			Wizard.Kobieta = kobietaVM;
			ModelState.Clear();
			if (!TryValidateModel(Wizard)) return View("Kobieta", Wizard);

			// stworzenie i przekazanie modelu dopasowania dla kobiety i mężczyzny
			MatchModel dopasowanie = new MatchModel(matchGovernor, Wizard.Kobieta, Wizard.Mezczyzna);
			return View("Dopasowanie", dopasowanie);
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
