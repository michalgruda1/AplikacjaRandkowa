using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AplikacjaRandkowa.Models;
using Newtonsoft.Json;

namespace AplikacjaRandkowa.Controllers
{
	public class HomeController : Controller
	{
		[BindProperty]
		public WizardViewModel Wizard { get; set; }

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
			Wizard = new WizardViewModel() {Kobieta = null, Mezczyzna = null };

			// wyswietl formularz z KobietaViewModel
			return View("~/Views/Randka/Kobieta.cshtml", Wizard);
		}

		[AutoValidateAntiforgeryToken]
		[HttpPost]
		public IActionResult Krok1Post()
		{
			// POST
			// Binduj KobietaViewModel z danych formularza
			// zweryfikuj poprawnosc KobietaViewModel
			// niepoprawny - wyswietl formularz ponownie z bledami walidacji
			if (!ModelState.IsValid) View("~/Views/Randka/Kobieta.cshtml");

			// poprawny - idz dalej
			// zapisz tresc KobietaViewModel w Wizard.KobietaViewModel
			// przejdz do kroku Mezczyzna, przekazujac WizardViewModel do widoku

			return View("~/Views/Randka/Mezczyzna.cshtml", Wizard);
		}

		[AutoValidateAntiforgeryToken]
		[HttpGet]
		public IActionResult Krok2Get()
		{
			// GET
			// Wyświetl, że to krok 2, i trzeba zacząć od kroku 1 (link do action Krok1Get)
			return View("~/Views/Randka/MezczyznaGet.cshtml");
		}

		[AutoValidateAntiforgeryToken]
		[HttpPost]
		public IActionResult Krok2Post_ShowView()
		{
			// POST
			// Odczytaj WizardViewModel via binding z formularza
			// Zweryfikuj poprawnosc WizardViewModel.KobietaViewModel
			// niepoprawny - cofnij GET-em do Krok1Get
			if (!ModelState.IsValid) return RedirectToAction(nameof(Krok1Get));

			// poprawny - wyświetl widok MezczyznaViewModel
			// NIE sprawdzamy czy są i NIE wczytujemy danych mężczyzny (kejs wstecza z kroku 3) 
			//		- zdajemy się na wstecz przeglądarki, bo wstecz przyjdzie GET-em i nie będzie danych POST do bindowania
			// Wyświetl formularz MezczyznaViewModel z ukrytym polem ze WizardViewModel z danymi KobietaViewModel
			// Submit wywołuje POST-em Krok2Post
			return View();
		}

		[AutoValidateAntiforgeryToken]
		[HttpPost]
		public IActionResult Krok2Post()
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
			return View();
		}

		[AutoValidateAntiforgeryToken]
		[HttpGet]
		public IActionResult Krok3Get()
		{
			// GET
			// Wyświetl, że to krok 3, i trzeba zacząć od kroku 1 (link do action Krok1Get)
			return View();
		}
 

		[AutoValidateAntiforgeryToken]
		[HttpPost]
		public IActionResult Krok3Post()
		{
			// POST
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
