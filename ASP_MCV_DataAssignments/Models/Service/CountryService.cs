using ASP_MCV_DataAssignments.Models.Repo;
using ASP_MCV_DataAssignments.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_MCV_DataAssignments.Models.Service
{
    public class CountryService : ICountryService
    {
        ICountryRepo _countriesRepo;

        public CountryService(ICountryRepo countriesRepo)
        {
            _countriesRepo = countriesRepo;
        }

        public Country Add(CreateCountryViewModel country)
        {
            return _countriesRepo.Create(country.Name);
        }

        public City AddCityToCountry(int id, City city)
        {
            return _countriesRepo.AddCityToCountry(id, city);
        }

        public CountriesViewModel All()
        {
            CountriesViewModel countriesViewModel = new CountriesViewModel();

            countriesViewModel.CountryList = _countriesRepo.Read();

            return countriesViewModel;
        }

        public Country Edit(int id, Country country)
        {
            return _countriesRepo.Update(country);
        }

        public CountriesViewModel FindBy(CountriesViewModel search)
        {
            List<Country> searchedCountryList = new List<Country>();

            foreach (Country item in _countriesRepo.Read())
            {
                if (item.Name.Contains(search.FilterText, StringComparison.OrdinalIgnoreCase))
                {
                    searchedCountryList.Add(item);
                }
            }
            search.CountryList = searchedCountryList;

            return search;
        }

        public Country Findby(int id)
        {
            return _countriesRepo.Read(id);
        }

        public bool Remove(int id)
        {
            Country country = _countriesRepo.Read(id);

            return _countriesRepo.Delete(country);
        }
    }
}
