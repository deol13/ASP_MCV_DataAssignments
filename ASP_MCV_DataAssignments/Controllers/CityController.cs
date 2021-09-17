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
    [Authorize(Roles = "Admin, User")]
    public class CityController : Controller
    {
        ICityService _citiesService;
        PeopleDbContext _context;

        public CityController(ICityService citiesService, PeopleDbContext context)
        {
            _citiesService = citiesService;
            _context = context;
        }


        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            List<Country> countries = _context.Countries.ToList();
            List<Person> people = _context.People.ToList();

            return View(_citiesService.All());
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Index(CitiesViewModel citiesViewModel)
        {
            if (citiesViewModel.FilterText != null)
            {
                citiesViewModel = _citiesService.FindBy(citiesViewModel);
            }
            else
            {
                return RedirectToAction(nameof(Index));
            }

            return View(citiesViewModel);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Create()
        {
            CreateCityViewModel vm = new CreateCityViewModel();
            vm.CountrySelectList = new SelectList(_context.Countries, "CountryId", "Name"); //Change so the id is sent back.

            return View(vm);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Create(CreateCityViewModel createCitiesViewModel)
        {
            if (ModelState.IsValid)
            {
                City city = _citiesService.Add(createCitiesViewModel);

                return RedirectToAction(nameof(Index));
            }

            createCitiesViewModel.CountrySelectList = new SelectList(_context.Countries, "CountryId", "Name"); //Change so the id is sent back.


            return View(createCitiesViewModel);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int id)
        {
            List<Country> countries = _context.Countries.ToList();

            CreateCityViewModel vm = new CreateCityViewModel();
            City city = _citiesService.Findby(id);

            vm.Id = id;
            vm.Name = city.Name;
            vm.CountryId = city.Country.CountryId;

            //List<int> PeopleIds = new List<int>();
            //foreach (var item in city.PeopleInCity)
            //{
            //    PeopleIds.Add(item.Id);
            //}
            //vm.PeopleIds = PeopleIds;

            //vm.selectList = new SelectList(_context.Cities, "PeopleIds", "Name"); //Change so the id is sent back.
            vm.CountrySelectList = new SelectList(_context.Countries, "CountryId", "Name"); //Change so the id is sent back.

            return View(vm);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Edit(CreateCityViewModel createCityViewModel) //Or  EditPersonViewModel editPersonViewModel
        {
            if (ModelState.IsValid)
            {
                City city = _citiesService.Edit(createCityViewModel);

                return RedirectToAction(nameof(Index));
            }

            //createCityViewModel.CountrySelectList = new SelectList(_context.Cities, "PeopleIds", "Name");
            createCityViewModel.CountrySelectList = new SelectList(_context.Countries, "CountryId", "Name");

            return View(createCityViewModel);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Remove(int id)
        {
            _citiesService.Remove(id);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult AddPersonToCity()
        {
            AddPersonToCityViewModel addPersonToCityViewModel = new AddPersonToCityViewModel();

            addPersonToCityViewModel.CitiesSelectList = new SelectList(_context.Cities, "CityId", "Name");
            addPersonToCityViewModel.PeopleSelectList = new SelectList(_context.People, "Id", "Name");

            return View(addPersonToCityViewModel);
        }

        [HttpPost]
        public IActionResult AddPersonToCity(AddPersonToCityViewModel addPersonToCityViewModel)
        {
            if (ModelState.IsValid)
            {
                _citiesService.AddPersonToCity(addPersonToCityViewModel.Id, addPersonToCityViewModel.PersonId);

                return RedirectToAction("Index", "People");
            }


            addPersonToCityViewModel.CitiesSelectList = new SelectList(_context.Cities, "CityId", "Name");
            addPersonToCityViewModel.PeopleSelectList = new SelectList(_context.People, "Id", "Name");

            return View(addPersonToCityViewModel);
        }

        public void Test()
        {
            //addDefaultValues();


            ////Test1 All without anything in it
            //CitiesViewModel citiesViewModel = _citiesService.All();

            ////Test2 Add
            //CreateCityViewModel createCityViewModel = new CreateCityViewModel();
            //createCityViewModel.Name = "Stockholm";
            //_citiesService.Add(createCityViewModel);


            ////Test 3 All with something in it
            //CitiesViewModel citiesViewModel3 = _citiesService.All();

            ////Test 4 Edit
            //CreateCityViewModel createCityViewModel2 = new CreateCityViewModel();
            //createCityViewModel2.Name = "påsk";
            //_citiesService.Add(createCityViewModel2);

            //City city = new City("Stockholm");
            //city.CityId = 2;

            //_citiesService.Edit(city.CityId, city);

            ////Test 5 Findby ViewModel
            //CitiesViewModel citiesViewModel2 = new CitiesViewModel();
            //citiesViewModel2.FilterText = "Göteborg";
            //citiesViewModel2 = _citiesService.FindBy(citiesViewModel2);


            ////Test 6 Findby id
            //City city3 = _citiesService.Findby(3);


            ////Test 7 Remove
            //City city5 = new City("Test");
            //_context.Cities.Add(city5);
            //_context.SaveChanges();
            //bool t = _citiesService.Remove(5);


            //Test 8 AddPersonToCity
            //Person person1 = _context.People.Find(1);
            //Person person2 = _context.People.Find(8);

            //_citiesService.AddPersonToCity(1, person1);
            //_citiesService.AddPersonToCity(1, person2);
        }

        public void addDefaultValues()
        {
            Country Sweden = _context.Countries.Find(1);
            Country England = _context.Countries.Find(2);
            Country Spain = _context.Countries.Find(3);
            Country Germany = _context.Countries.Find(4);
            Country France = _context.Countries.Find(5);
            Country Russia = _context.Countries.Find(6);

            City city1 = new City("Stockholm");
            City city2 = new City("Gothenburg");

            City city3 = new City("London");
            City city4 = new City("Oxford");

            City city5 = new City("Madrid");
            City city6 = new City("Zaragoza");

            City city7 = new City("Berlin");
            City city8 = new City("Hamburg");

            City city9 = new City("Paris");
            City city10 = new City("Lyon");

            City city11 = new City("Moscow");
            City city12 = new City("Volgograd");

            city1.Country = Sweden;
            city2.Country = Sweden;

            city3.Country = England;
            city4.Country = England;

            city5.Country = Spain;
            city6.Country = Spain;

            city7.Country = Germany;
            city8.Country = Germany;

            city9.Country = France;
            city10.Country = France;

            city11.Country = Russia;
            city12.Country = Russia;

            _context.Cities.Add(city1);
            _context.Cities.Add(city2);
            _context.Cities.Add(city3);
            _context.Cities.Add(city4);
            _context.Cities.Add(city5);
            _context.Cities.Add(city6);
            _context.Cities.Add(city7);
            _context.Cities.Add(city8);
            _context.Cities.Add(city9);
            _context.Cities.Add(city10);
            _context.Cities.Add(city11);
            _context.Cities.Add(city12);

            _context.SaveChanges();

        }
    }
}
