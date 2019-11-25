using System;
using System.ComponentModel.DataAnnotations;

namespace AplikacjaRandkowa.Models
{
	public class MezczyznaViewModel : IPerson
	{
		[Required(AllowEmptyStrings = false, ErrorMessage = "{0} jest wymagane")]
		[Display(Name = "Imię"), DataType(DataType.Text), MaxLength(50, ErrorMessage = "{0} za długie"), MinLength(1, ErrorMessage = "{0} za krótkie")]
		public string Imie { get; set; }

		[Required(ErrorMessage = "Wzrost jest wymagany")]
		[Display(Name = "Wzrost [cm]"), Range(typeof(int), "50", "250", ErrorMessage = "Wzrost musi być między {1} i {2} cm")]
		public int Wzrost { get; set; }

		[Required(AllowEmptyStrings = false, ErrorMessage = "{0} jest wymagana")]
		[Display(Name = "Data urodzenia"), DataType(DataType.Date)]
		public DateTime DataUrodzenia { get; set; }

		[Required(ErrorMessage = "{0} jest wymagany")]
		[Display(Name = "Kolor oczu")]
		[EnumDataType(typeof(KolorOczuEnum), ErrorMessage = "{0} nieznany")]
		public KolorOczuEnum KolorOczu { get; set; }
	}
}
