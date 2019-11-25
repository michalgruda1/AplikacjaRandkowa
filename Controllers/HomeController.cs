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

		public IActionResult Privacy()
		{
			return View();
		}

		[AutoValidateAntiforgeryToken]
		[HttpGet]
		public IActionResult Krok1Get()
		{
			Wizard = new WizardViewModel() { Kobieta = null, Mezczyzna = null };
			return View("~/Views/Randka/Kobieta.cshtml", Wizard);
		}

		[AutoValidateAntiforgeryToken]
		[HttpPost]
		public IActionResult Krok1Post()
		{
			if (!ModelState.IsValid) return View("~/Views/Randka/Kobieta.cshtml", Wizard);

			return View("~/Views/Randka/Mezczyzna.cshtml", Wizard);
		}

		[AutoValidateAntiforgeryToken]
		[HttpGet]
		public IActionResult Krok2Get()
		{
			return View("~/Views/Randka/MezczyznaGet.cshtml");
		}

		[AutoValidateAntiforgeryToken]
		[HttpPost]
		public IActionResult Krok2Post([FromForm] string Kobieta)
		{
			if (!ModelState.IsValid) return RedirectToAction(nameof(Krok1Get));
			
			var kobietaVM = JsonConvert.DeserializeObject<KobietaViewModel>(Kobieta);
			if (!TryValidateModel(kobietaVM, nameof(Wizard.Kobieta))) return RedirectToAction(nameof(Krok1Get));

			Wizard.Kobieta = kobietaVM;
			MatchModel dopasowanie = new MatchModel(matchGovernor, Wizard.Kobieta, Wizard.Mezczyzna);
			return View("~/Views/Randka/Dopasowanie.cshtml", dopasowanie);
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
