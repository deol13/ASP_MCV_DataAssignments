using ASP_MCV_DataAssignments.Data;
using ASP_MCV_DataAssignments.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_MCV_DataAssignments.Models.Repo
{
    public class CountryRepo : ICountryRepo
    {
        private readonly PeopleDbContext _context;

        public CountryRepo(PeopleDbContext context)
        {
            _context = context;
        }

        public City AddCityToCountry(int id, City city)
        {
            Country country = Read(id);
            country.Cities.Add(city);

            _context.Countries.Update(country);
            _context.SaveChanges();

            return city;
        }

        public Country Create(string name)
        {
            Country country = new Country(name);

            _context.Countries.Add(country);
            _context.SaveChanges();

            return country;
        }

        public bool Delete(Country country)
        {
            _context.Countries.Remove(country);
            int nrOfChanges = _context.SaveChanges();

            bool deleted = false;
            if (nrOfChanges == 1)
                deleted = true;

            return deleted;
        }

        public List<Country> Read()
        {
            List<Country> countries = _context.Countries.ToList();

            return countries;
        }

        public Country Read(int id)
        {
            Country country = _context.Countries.Find(id);

            return country;
        }

        public Country Update(CreateCountryViewModel countryViewModel)
        {
            Country country = new Country(countryViewModel.Name);
            country.CountryId = countryViewModel.CountryId;

            List<City> cities = new List<City>();
            foreach (var item in countryViewModel.CitiesId)
            {
                cities.Add(_context.Cities.Find(item));
            }
            country.Cities = cities;

            _context.Countries.Update(country);
            _context.SaveChanges();

            return country;
        }
    }
}
