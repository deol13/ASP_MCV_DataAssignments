using ASP_MCV_DataAssignments.Data;
using ASP_MCV_DataAssignments.Models;
using ASP_MCV_DataAssignments.Models.Service;
using ASP_MCV_DataAssignments.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_MCV_DataAssignments.Controllers
{
    public class ReactController : Controller
    {

        IPeopleService _peopleService;
        PeopleDbContext _context;

        public ReactController(IPeopleService peopleService, PeopleDbContext context)
        {
            _peopleService = peopleService;
            _context = context;

            List<City> citiesViewModel = _context.Cities.ToList();
            List<Country> countries = _context.Countries.ToList();
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [Route("people")]
        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult People()
        {
            List<Person> people = _context.People.ToList();
            List<PersonReactModel> peopleReactModel = new List<PersonReactModel>();

            foreach (var person in people)
            {
                PersonReactModel p = new PersonReactModel();
                p.Id = person.Id;
                p.Name = person.Name;
                p.Phone = person.Phone;
                p.City = person.City.Name;
                p.Country = person.City.Country.Name; 
                peopleReactModel.Add(p);
            }

            return Json(peopleReactModel);
        }

        //[Route("people/lists")]
        //[ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult ListOfCitiesAndCounties()
        //{
        //    List<City> lists = new List<City>();

        //    lists = _context.Cities.ToList();

        //    return Json(lists);
        //}

        [Route("people/new")]
        [HttpPost]
        public IActionResult Create(PersonReactModel newPerson)
        {
            CreatePersonViewModel person = new CreatePersonViewModel();
            person.Name = newPerson.Name;
            person.Phone = newPerson.Phone;
            person.CityId = newPerson.CityId;

            _peopleService.Add(person);

            return Content("Success: :)");
            //return Ok();
        }

        [HttpPost]
        public IActionResult Delete()
        {
            return View();
        }
    }
}
