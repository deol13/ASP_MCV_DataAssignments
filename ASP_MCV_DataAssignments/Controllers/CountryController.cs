using ASP_MCV_DataAssignments.Data;
using ASP_MCV_DataAssignments.Models;
using ASP_MCV_DataAssignments.Models.Service;
using ASP_MCV_DataAssignments.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_MCV_DataAssignments.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CountryController : Controller
    {
        ICountryService _countriesService;
        PeopleDbContext _context;

        public CountryController(ICountryService countriesService, PeopleDbContext context)
        {
            _countriesService = countriesService;
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<City> cities = _context.Cities.ToList();

            return View(_countriesService.All());
        }

        [HttpPost]
        public IActionResult Index(CountriesViewModel countriesViewModel)
        {
            if (countriesViewModel.FilterText != null)
            {
                countriesViewModel = _countriesService.FindBy(countriesViewModel);
            }
            else
            {
                return RedirectToAction(nameof(Index));
            }
            return View(countriesViewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            CreateCountryViewModel vm = new CreateCountryViewModel();

            //The second and third parameter should be the name of the variables of the type of object the list consists of
            //In this case its a list of City's, so CityId and Name is the names of two of City's class variables.
            //Not From the viewmodel
            //                                              City class CityId variable, City Class Name variable.
            vm.selectList = new SelectList(_context.Cities, "CityId", "Name"); //Change so the id is sent back.

            return View(vm);
        }

        [HttpPost]
        public IActionResult Create(CreateCountryViewModel createCountryViewModel)
        {
            //Goes invalid if one of the Req in CreateViewModel is not met
            if (ModelState.IsValid)
            {
                Country country = _countriesService.Add(createCountryViewModel);

                return RedirectToAction(nameof(Index));
            }

            createCountryViewModel.selectList = new SelectList(_context.Cities, "CityId", "Name");

            return View(createCountryViewModel);
        }

        public IActionResult EditCountry(int id)
        {
            CreateCountryViewModel vm = new CreateCountryViewModel();
            Country country = _countriesService.Findby(id);

            vm.Id = id;
            vm.Name = country.Name;

            List<int> citiesIds = new List<int>();
            foreach (var item in country.Cities)
            {
                citiesIds.Add(item.CityId);
            }
            vm.CitiesId = citiesIds;

            vm.selectList = new SelectList(_context.Cities, "CityId", "Name"); //Change so the id is sent back.

            return View(vm);
        }

        [HttpPost]
        public IActionResult EditCountry(CreateCountryViewModel createCountryViewModel)
        {
            if (ModelState.IsValid)
            {
                Country country = _countriesService.Edit(createCountryViewModel);

                return RedirectToAction(nameof(Index));
            }

            createCountryViewModel.selectList = new SelectList(_context.Cities, "CityId", "Name");

            return View(createCountryViewModel);
        }

        public IActionResult Remove(int id)
        {
            _countriesService.Remove(id);

            return RedirectToAction(nameof(Index));
        }



        public void Test()
        {
            ////Test1 All without anything in it
            //CountriesViewModel countriesViewModel = _countriesService.All();

            ////Test2 Add
            //addDefaultCountriesValues();
            //AddDefaultCitiesToDefaultCountries();

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
        }

        public void addDefaultCountriesValues()
        {
            CreateCountryViewModel createCountryViewModel = new CreateCountryViewModel();
            CreateCountryViewModel createCountryViewModel2 = new CreateCountryViewModel();
            CreateCountryViewModel createCountryViewModel3 = new CreateCountryViewModel();
            CreateCountryViewModel createCountryViewModel4 = new CreateCountryViewModel();
            CreateCountryViewModel createCountryViewModel5 = new CreateCountryViewModel();
            CreateCountryViewModel createCountryViewModel6 = new CreateCountryViewModel();
            createCountryViewModel.Name = "Sweden";
            createCountryViewModel2.Name = "England";
            createCountryViewModel3.Name = "Spain";
            createCountryViewModel4.Name = "Germany";
            createCountryViewModel5.Name = "France";
            createCountryViewModel6.Name = "Russia";

            _countriesService.Add(createCountryViewModel);
            _countriesService.Add(createCountryViewModel2);
            _countriesService.Add(createCountryViewModel3);
            _countriesService.Add(createCountryViewModel4);
            _countriesService.Add(createCountryViewModel5);
            _countriesService.Add(createCountryViewModel6);
        }

        public void AddDefaultCitiesToDefaultCountries()
        {
            City city = _context.Cities.Find(1);

            Country Sweden = _context.Countries.Find(1);
            Country England = _context.Countries.Find(2);
            Country Spain = _context.Countries.Find(3);
            Country Germany = _context.Countries.Find(4);
            Country France = _context.Countries.Find(5);
            Country Russia = _context.Countries.Find(6);

            Sweden.Cities.Add(_context.Cities.Find(1));
            Sweden.Cities.Add(_context.Cities.Find(2));

            England.Cities.Add(_context.Cities.Find(3));
            England.Cities.Add(_context.Cities.Find(4));

            Spain.Cities.Add(_context.Cities.Find(5));
            Spain.Cities.Add(_context.Cities.Find(6));

            Germany.Cities.Add(_context.Cities.Find(7));
            Germany.Cities.Add(_context.Cities.Find(8));

            France.Cities.Add(_context.Cities.Find(9));
            France.Cities.Add(_context.Cities.Find(10));

            Russia.Cities.Add(_context.Cities.Find(11));
            Russia.Cities.Add(_context.Cities.Find(12));

            _context.Countries.Update(Sweden);
            _context.Countries.Update(England);
            _context.Countries.Update(Spain);
            _context.Countries.Update(Germany);
            _context.Countries.Update(France);
            _context.Countries.Update(Russia);

            _context.SaveChanges();
        }
    }
}
