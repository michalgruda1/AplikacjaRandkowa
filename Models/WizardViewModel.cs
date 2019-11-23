using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AplikacjaRandkowa.Models
{
	[Serializable]
	public class WizardViewModel
	{
		public MezczyznaViewModel Kobieta { get; set; }
		public MezczyznaViewModel Mezczyzna { get; set; }
	}
}
