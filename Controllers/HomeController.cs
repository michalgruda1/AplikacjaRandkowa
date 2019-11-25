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
			// inicjalizuj WizardViewModel, a w środku nullable view modele: KobietaViewModel, MezczyznaViewModel (każdy sub-model ma mocną walidację)
			Wizard = new WizardViewModel() { Kobieta = null, Mezczyzna = null };

			// wyswietl formularz z KobietaViewModel
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

		[AutoValidateAntiforgeryToken]
		[HttpPost]
		public IActionResult Krok3Post()
		{
			// POST
			// Sprawdź, czy istnieje WizardViewModel z KobietaViewModel w danych formularza via binding
			// jeśli nie - przekieruj na krok 1
			// Sprawdz czy jest poprawny
			// jeśli nie - przekieruj na krok 1
			// Sprawdź, czy podano w formularzu WizardViewModel z MezczyznaViewModel via binding
			// Odczytaj MezczyznaViewModel via binding
			// Zweryfikuj poprawnosc MezczyznaViewModel
			// niepoprawny - cofnij POST-em do Krok2Post_ShowView, przekazujac zserializowany WizardViewModel
			// poprawny - wyswietl krok 3


			// Sprawdź, czy istnieje WizardViewModel z KobietaViewModel, MezczyznaViewModel w danych formularza via binding
			// Sprawdź czy są valid
			// Zamapuj na pełny obiekt DopasowanieModel z KobietaModel i MezczyznaModel
			// wykonaj metodę sprawdzającą dopasowanie na DopasowanieModel
			// wyświetl widok w zależności od wyniku dopasowania
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
