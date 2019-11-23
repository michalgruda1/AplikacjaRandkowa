using AplikacjaRandkowa.Models;
using System;
using System.Collections.Generic;

namespace AplikacjaRandkowa.Services
{
	public interface ICriteriaBuilder
	{
		IList<Func<IPerson, IPerson, bool>> GetCriteria();
	}
}
