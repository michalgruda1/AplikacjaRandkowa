using AplikacjaRandkowa.Services;

namespace AplikacjaRandkowa.Models
{
	public class MatchModel
	{
		private readonly IMatchGovernor matchGovernor;

		public IPerson PersonOne { get; private set; }
		public IPerson PersonTwo { get; private set; }

		public MatchModel(IMatchGovernor matchGovernor)
		{
			this.matchGovernor = matchGovernor;
		}

		public bool IsMatch()
		{
			return matchGovernor.CheckMatch(this.PersonOne, this.PersonTwo);
		}

		public void SetPersonOne(IPerson person)
		{
			this.PersonOne = person;
		}

		public void SetPersonTwo(IPerson person)
		{
			this.PersonTwo = person;
		}
	}
}
