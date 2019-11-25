using AplikacjaRandkowa.Services;
using System;

namespace AplikacjaRandkowa.Models
{
	public class MatchModel
	{
		private readonly IMatchGovernor matchGovernor;
		private readonly IPerson personOne;
		private readonly IPerson personTwo;

		public MatchModel(IMatchGovernor matchGovernor, IPerson personOne, IPerson personTwo)
		{
			if (matchGovernor == null || personOne == null || personTwo == null) throw new ArgumentNullException();

			this.matchGovernor = matchGovernor;
			this.personOne = personOne;
			this.personTwo = personTwo;
		}

		public bool IsMatch()
		{
			return matchGovernor.CheckMatch(this.personOne, this.personTwo);
		}

		public IPerson GetPersonOne()
		{
			return this.personOne;
		}

		public IPerson GetPersonTwo()
		{
			return this.personTwo;
		}
	}
}
