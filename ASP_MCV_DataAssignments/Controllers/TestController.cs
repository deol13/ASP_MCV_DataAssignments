using Microsoft.AspNetCore.Mvc;
using ASP_MCV_DataAssignments.Models.Service;
using ASP_MCV_DataAssignments.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP_MCV_DataAssignments.Models.Repo;
using ASP_MCV_DataAssignments.Models;

namespace ASP_MCV_DataAssignments.Controllers
{
    public class TestController : Controller
    {
        IPeopleRepo _peopleService;

        public TestController(IPeopleRepo peopleService)
        {
            _peopleService = peopleService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            PeopleViewModel peopleViewModel = new PeopleViewModel();
            peopleViewModel.PersonList = _peopleService.Read();

            //Update();

            //peopleViewModel.PersonList = _peopleService.Read();

            return View(peopleViewModel);
        }

        [HttpPost]
        public IActionResult Index(PeopleViewModel peopleViewModel)
        {
            if (peopleViewModel.FilterText != null)
            {
                List<Person> searchedPersonList = new List<Person>();

                foreach (Person item in _peopleService.Read())
                {
                    if (item.City.Contains(peopleViewModel.FilterText, StringComparison.OrdinalIgnoreCase) || item.Name.Contains(peopleViewModel.FilterText, StringComparison.OrdinalIgnoreCase))
                    {
                        searchedPersonList.Add(item);
                    }
                }
                peopleViewModel.PersonList = searchedPersonList;
            }
            else
            {
                return RedirectToAction(nameof(Index));
            }
            return View(peopleViewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreatePersonViewModel createPersonViewModel)
        {
            if (ModelState.IsValid)
            {
                _peopleService.Create(createPersonViewModel.Name, createPersonViewModel.City, createPersonViewModel.Phone);

                return RedirectToAction(nameof(Index));
            }

            return View(createPersonViewModel);
        }

        public IActionResult Remove(int id)
        {
            Person person = _peopleService.Read(id);
            _peopleService.Delete(person);

            return RedirectToAction(nameof(Index));
        }

        public void Update()
        {
            //Old ("Björn bergtop", 95235233, "Malmö", 2)
            Person person = new Person("Ola", 51239881, "Bergsjön", 2);
            _peopleService.Update(person);
        }
    }
}
