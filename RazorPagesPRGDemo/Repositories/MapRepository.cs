using RazorPagesPRGDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPagesPRGDemo.Repositories
{
    public interface IMapRepository
    {
        List<Map> GetAll();
        List<Map> Search(Country? country, DateTime? startRange, DateTime? endRange);
    }

    public class MapRepository : IMapRepository
    {
        public List<Map> GetAll()
        {
            return new List<Map>()
            {
                new Map()
                {
                    Country = Country.UnitedStates,
                    ID = 1,
                    PublicationDate = new DateTime(2019,12,14)
                },
                new Map()
                {
                    Country = Country.Canada,
                    ID = 2,
                    PublicationDate = new DateTime(2017,1,19)
                },
                new Map()
                {
                    Country = Country.India,
                    ID = 3,
                    PublicationDate = new DateTime(2018,4,10)
                },
                new Map()
                {
                    Country = Country.UnitedStates,
                    ID = 4,
                    PublicationDate = new DateTime(2018,1,1)
                },
                new Map()
                {
                    Country = Country.UnitedKingdom,
                    ID = 4,
                    PublicationDate = new DateTime(1977,5,1)
                },
                new Map()
                {
                    Country = Country.Serbia,
                    ID = 4,
                    PublicationDate = new DateTime(2017,5,17)
                }
            };
        }

        public List<Map> Search(Country? country, DateTime? startRange, DateTime? endRange)
        {
            var allMaps = GetAll().AsQueryable();

            if(country.HasValue)
            {
                allMaps = allMaps.Where(x => x.Country == country);
            }
            if(startRange.HasValue && endRange.HasValue)
            {
                allMaps = allMaps.Where(x => x.PublicationDate >= startRange.Value && x.PublicationDate <= endRange.Value);
            }

            return allMaps.ToList();
        }
    }
}
