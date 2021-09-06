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
    public class CityController : Controller
    {
        ICityService _citiesService;
        PeopleDbContext _context;

        public CityController(ICityService citiesService, PeopleDbContext context)
        {
            _citiesService = citiesService;
            _context = context;
        }

        //A Bunch of test to see if City and Country service's works
        public IActionResult Index()
        {

            ////Test1 All without anything in it
            //CitiesViewModel citiesViewModel = _citiesService.All();

            ////Test2 Add
            //CreateCityViewModel createCityViewModel = new CreateCityViewModel();
            //createCityViewModel.Name = "Göteborg";

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

            return View();
        }
    }
}
