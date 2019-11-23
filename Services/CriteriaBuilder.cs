using AplikacjaRandkowa.Services;
using System;
using System.Collections.Generic;

namespace AplikacjaRandkowa.Models
{
	public class CriteriaBuilder : ICriteriaBuilder
	{
		private IList<Func<IPerson, IPerson, bool>> Criteria { get; set; }

		public IList<Func<IPerson, IPerson, bool>> GetCriteria()
		{
			SetMezczyznaWyzszyOdKobietyOMin10cm();
			SetRoznicaWiekuDo5Lat();
			SetKolorOczuTenSam();

			return Criteria;
		}

		public void SetMezczyznaWyzszyOdKobietyOMin10cm()
		{
			Func<IPerson, IPerson, bool> criterium = (kobieta, mezczyzna) =>
			{
				var roznica = mezczyzna.Wzrost - kobieta.Wzrost;
				var ret = roznica >= 10;
				return ret;
			};

			Criteria.Add(criterium);
		}

		public void SetRoznicaWiekuDo5Lat()
		{
			Func<IPerson, IPerson, bool> criterium = (kobieta, mezczyzna) =>
			{
				var roznica = kobieta.DataUrodzenia - mezczyzna.DataUrodzenia;
				var roznicaWDniach = Math.Abs(roznica.Days);
				var piecLatWDniach = TimeSpan.FromDays(5 * 365).Days;
				var ret = roznicaWDniach < piecLatWDniach;
				return ret;
			};

			Criteria.Add(criterium);
		}

		public void SetKolorOczuTenSam()
		{
			Func<IPerson, IPerson, bool> criterium = (kobieta, mezczyzna) =>
			{
				return kobieta.KolorOczu == mezczyzna.KolorOczu;
			};

			Criteria.Add(criterium);
		}
	}
}
