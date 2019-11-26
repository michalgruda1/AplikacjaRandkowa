using AplikacjaRandkowa.Models;
using System.Linq;

namespace AplikacjaRandkowa.Services
{
	public class MatchGovernor : IMatchGovernor
	{
		private readonly ICriteriaBuilder criteriaBuilder;

		public MatchGovernor(ICriteriaBuilder criteriaBuilder)
		{
			this.criteriaBuilder = criteriaBuilder;
		}

		public bool CheckMatch(IPerson personOne, IPerson personTwo)
		{
			var criteria = criteriaBuilder.GetCriteria();

			int count = 0;

			criteria.ToList()
				.ForEach(c =>
				{
					if (c.Invoke(personOne, personTwo) == true)
					{
						// osoby pasują w/g kryterium
						count++;
					};
				}
			);

			return count >= 2 ? true : false;
		}
	}
}
