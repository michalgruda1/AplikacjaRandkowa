using AplikacjaRandkowa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AplikacjaRandkowa.Services
{
	public interface IMatchGovernor
	{
		bool CheckMatch(IPerson kobieta, IPerson mezczyzna);
	}
}
