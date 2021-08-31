using Microsoft.AspNetCore.Mvc;
using ASP_MCV_DataAssignments.Models.Service;
using ASP_MCV_DataAssignments.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP_MCV_DataAssignments.Models;

namespace ASP_MCV_DataAssignments.Controllers
{
    public class AjaxController : Controller
    {
        IPeopleService _peopleService;

        public AjaxController(IPeopleService peopleService)
        {
            _peopleService = peopleService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            if (_peopleService.All().PersonList.Count == 0)
            {
                _peopleService.CreateDefaultPeople();
                
            }
            PeopleViewModel peopleViewModel = _peopleService.All();

            return View(peopleViewModel);
        }

        [HttpGet]
        public IActionResult PeoplePartial()
        {
            return PartialView("PeoplePartial", _peopleService.All());//View(_peopleService.All());
        }

        [HttpPost]
        public IActionResult PersonPartial(int id)
        {
            id = 1;

            Person p = _peopleService.Findby(id);
            if (p == null)
            {
                //??
            }

            return PartialView("PersonPartial", p); //View(_peopleService.Findby(id));
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _peopleService.Remove(id);

            return View();
        }

        [HttpGet]
        public IActionResult Test(int id)
        {
            return Content("Hej");
        }
    }
}
