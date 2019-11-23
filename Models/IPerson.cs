using System;

namespace AplikacjaRandkowa.Models
{
	public interface IPerson
	{
		string Imie { get; set; }
		int Wzrost { get; set; }
		DateTime DataUrodzenia { get; set; }
		KolorOczuEnum KolorOczu { get; set; }
	}
}
