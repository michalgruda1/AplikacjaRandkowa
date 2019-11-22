﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AplikacjaRandkowa.Models;

namespace AplikacjaRandkowa.Controllers
{
	public class HomeController : Controller
	{
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
			// GET
			// inicjalizuj WizardViewModel, a w środku nullable: KobietaViewModel, MezczyznaViewModel, DopasowanieViewModel (każdy sub-model ma mocną walidację)
			// wyswietl formularz z KobietaViewModel
			return View();
		}

		[AutoValidateAntiforgeryToken]
		[HttpPost]
		public IActionResult Krok1Post()
		{
			// POST
			// Binduj KobietaViewModel z danych formularza
			// zweryfikuj poprawnosc KobietaViewModel
			// niepoprawny - wyswietl formularz ponownie z bledami walidacji
			// poprawny - idz dalej
			// zapisz tresc KobietaViewModel w Wizard.KobietaViewModel
			// przejdz do kroku Mezczyzna, przekazujac WizardViewModel do widoku
			return View(nameof(Krok2Post_ShowView), WizardViewModel);
		}

		[AutoValidateAntiforgeryToken]
		[HttpGet]
		public IActionResult Krok2Get()
		{
			// GET
			// Wyświetl, że to krok 2, i trzeba zacząć od kroku 1 (link do action Krok1Get)
		}

		[AutoValidateAntiforgeryToken]
		[HttpPost]
		public IActionResult Krok2Post_ShowView()
		{
			// POST
			// Odczytaj WizardViewModel via binding z formularza
			// Zweryfikuj poprawnosc WizardViewModel.KobietaViewModel
			// niepoprawny - cofnij POST-em do Krok1Post, przekazujac WizardViewModel.KobietaViewModel
			// poprawny - wyświetl widok MezczyznaViewModel
			// NIE sprawdzamy czy są i NIE wczytujemy danych mężczyzny (kejs wstecza z kroku 3) 
			//		- zdajemy się na wstecz przeglądarki, bo wstecz przyjdzie GET-em i nie będzie danych POST do bindowania
			// Wyświetl formularz MezczyznaViewModel z ukrytym polem ze WizardViewModel z danymi KobietaViewModel
			// Submit wywołuje POST-em Krok2Post
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
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
