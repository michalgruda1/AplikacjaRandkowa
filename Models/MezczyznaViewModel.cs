using System;
using System.ComponentModel.DataAnnotations;

namespace AplikacjaRandkowa.Models
{
	public class KobietaViewModel
	{
		[Required]
		[Display(Name = "Imię"), DataType(DataType.Text), MaxLength(50, ErrorMessage = "Imię za długie"), MinLength(1, ErrorMessage = "Imię za krótkie")]
		public string Imie { get; set; }

		[Required]
		[DataType(DataType.Text), MaxLength(50, ErrorMessage = "Nazwisko za długie"), MinLength(1, ErrorMessage = "Nazwisko za krótkie")]
		public string Nazwisko { get; set; }

		[Required]
		[DataType(DataType.Date)]
		public DateTime DataUrodzenia { get; set; }

		[Required]
		[EnumDataType(typeof(KolorOczuEnum), ErrorMessage = "Nie znamy takiego koloru")]
		public KolorOczuEnum KolorOczu { get; set; }
	}
}
