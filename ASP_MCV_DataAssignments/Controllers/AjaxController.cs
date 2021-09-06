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
            PeopleViewModel peopleViewModel = _peopleService.All();

            return View(peopleViewModel);
        }

        [HttpGet]
        public IActionResult PeoplePartial(int id)
        {
            return PartialView("PeoplePartial", _peopleService.All().PersonList);
        }

        [HttpPost]
        public IActionResult PersonPartial(int id)
        {
            Person p = _peopleService.Findby(id);

            return PartialView("PersonPartial", p);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            bool deleted = _peopleService.Remove(id);
            string result = "";

            if (deleted)
                result = "Successfully deleted!";
            else
                result = "Was not deleted!";

            return Content(result);
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
                _peopleService.Add(createPersonViewModel);

                return RedirectToAction(nameof(PeoplePartial));
            }

            return View(createPersonViewModel);
        }
    }
}
