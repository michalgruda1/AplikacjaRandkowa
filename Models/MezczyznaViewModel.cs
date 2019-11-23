using System;
using System.ComponentModel.DataAnnotations;

namespace AplikacjaRandkowa.Models
{
	[Serializable]
	public class MezczyznaViewModel
	{
		[Required(AllowEmptyStrings = false, ErrorMessage = "Imię jest wymagane")]
		[Display(Name = "Imię"), DataType(DataType.Text), MaxLength(50, ErrorMessage = "Imię za długie"), MinLength(1, ErrorMessage = "Imię za krótkie")]
		public string Imie { get; set; }

		[Required(AllowEmptyStrings = false, ErrorMessage = "Nazwisko jest wymagane")]
		[DataType(DataType.Text), MaxLength(50, ErrorMessage = "Nazwisko za długie"), MinLength(1, ErrorMessage = "Nazwisko za krótkie")]
		public string Nazwisko { get; set; }

		[Required(AllowEmptyStrings = false, ErrorMessage = "Data urodzenia jest wymagana")]
		[Display(Name = "Data urodzenia"), DataType(DataType.Date)]
		public DateTime DataUrodzenia { get; set; }

		[Required]
		[Display(Name = "Kolor oczu")]
		[EnumDataType(typeof(KolorOczuEnum), ErrorMessage = "Nie znamy takiego koloru")]
		public KolorOczuEnum KolorOczu { get; set; }
	}
}
