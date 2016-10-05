using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reindawn.Domain.Models;

namespace Reindawn.Domain.Helper
{
    public static class CountryHelper
    {

        public static List<Country> CountryList()
        {
            List<Country> countries = new List<Country>();
            foreach (CultureInfo info in CultureInfo.GetCultures(CultureTypes.SpecificCultures))
            {
                RegionInfo info2 = new RegionInfo(info.LCID);

                if (!(countries.Any(o=>o.Name == info2.EnglishName)))
                {
                    countries.Add(new Country { Code = info2.TwoLetterISORegionName, Name = info2.EnglishName });
                }
                
            }
            return countries.OrderBy(o=>o.Name).ToList();
        }
    }
}
