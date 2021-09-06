using ASP_MCV_DataAssignments.Data;
using ASP_MCV_DataAssignments.Models;
using ASP_MCV_DataAssignments.Models.Service;
using ASP_MCV_DataAssignments.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_MCV_DataAssignments.Controllers
{
    public class CountryController : Controller
    {
        ICountryService _countriesService;
        PeopleDbContext _context;

        public CountryController(ICountryService countriesService, PeopleDbContext context)
        {
            _countriesService = countriesService;
            _context = context;
        }

        //A Bunch of test to see if City and Country service's works
        public IActionResult Index()
        {
            ////Test1 All without anything in it
            //CountriesViewModel countriesViewModel = _countriesService.All();

            ////Test2 Add
            //CreateCountryViewModel createCountryViewModel = new CreateCountryViewModel();
            //createCountryViewModel.Name = "Sweden";

            //_countriesService.Add(createCountryViewModel);

            ////Test 3 All with something in it
            //CountriesViewModel countriesViewModel3 = _countriesService.All();

            ////Test 4 Edit
            //CreateCountryViewModel createCountryViewModel2 = new CreateCountryViewModel();
            //createCountryViewModel2.Name = "England";
            //_countriesService.Add(createCountryViewModel2);

            //Country country = new Country("Denmark");
            //country.CountryId = 2;
            //_countriesService.Edit(country.CountryId, country);


            ////Test 5 Findby ViewModel
            //CountriesViewModel countriesViewModel2 = new CountriesViewModel();
            //countriesViewModel2.FilterText = "Denmark";
            //countriesViewModel2 = _countriesService.FindBy(countriesViewModel2);


            ////Test 6 Findby id
            //Country country2 = _countriesService.Findby(1);

            //Test 7 Remove
            //Country country5 = new Country("Test");
            //_context.Countries.Add(country5);
            //_context.SaveChanges();
            //bool t = _countriesService.Remove(4);

            ////Test 8 AddPersonToCity
            //City city1 = _context.Cities.Find(10);
            //City city2 = _context.Cities.Find(12);
            //City city3 = _context.Cities.Find(13);
            //City city4 = _context.Cities.Find(14);
            //City city5 = _context.Cities.Find(15);

            //_countriesService.AddCityToCountry(5, city1);
            //_countriesService.AddCityToCountry(5, city2);
            //_countriesService.AddCityToCountry(5, city3);
            //_countriesService.AddCityToCountry(5, city4);
            //_countriesService.AddCityToCountry(5, city5);

            return View();
        }
    }
}
