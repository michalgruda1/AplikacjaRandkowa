using System;
using System.ComponentModel.DataAnnotations;

namespace AplikacjaRandkowa.Models
{
	public class MezczyznaViewModel : IPerson
	{
		[Required(AllowEmptyStrings = false, ErrorMessage = "Imię jest wymagane")]
		[Display(Name = "Imię"), DataType(DataType.Text), MaxLength(50, ErrorMessage = "Imię za długie"), MinLength(1, ErrorMessage = "Imię za krótkie")]
		public string Imie { get; set; }

		[Required(ErrorMessage = "Wzrost jest wymagany")]
		[Display(Name = "Wzrost [cm]"), Range(typeof(int), "50", "250", ErrorMessage = "Wzrost musi być między {1} i {2} cm")]
		public int Wzrost { get; set; }

		[Required(AllowEmptyStrings = false, ErrorMessage = "Data urodzenia jest wymagana")]
		[Display(Name = "Data urodzenia"), DataType(DataType.Date)]
		public DateTime DataUrodzenia { get; set; }

		[Required]
		[Display(Name = "Kolor oczu")]
		[EnumDataType(typeof(KolorOczuEnum), ErrorMessage = "Nie znamy takiego koloru")]
		public KolorOczuEnum KolorOczu { get; set; }
	}
}
