using System.ComponentModel;

namespace AplikacjaRandkowa.Models
{
	public enum KolorOczuEnum
	{
		Szare = 0,
		Niebieskie = 1_000,
		[DisplayName("Brązowe")] Brazowe = 2_000,
		Zielone = 3_000
	}
}