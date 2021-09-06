using Microsoft.AspNetCore.Mvc;
using ASP_MCV_DataAssignments.Models.Service;
using ASP_MCV_DataAssignments.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP_MCV_DataAssignments.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ASP_MCV_DataAssignments.Controllers
{
    public class PeopleController : Controller
    {
        IPeopleService _peopleService;
        PeopleDbContext _context;

        public PeopleController(IPeopleService peopleService, PeopleDbContext context)
        {
            _peopleService = peopleService;
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ////Just to test edit/updatem methods
            //PeopleViewModel peopleViewModel = new PeopleViewModel();

            //peopleViewModel = _peopleService.All();
            //Update();

            ////Had to remove this to check if read() actually gets the databases table if local list is empty
            //if(_peopleService.All().PersonList.Count == 0)
            //{
            //    _peopleService.CreateDefaultPeople();
            //}

            return View(_peopleService.All());
        }

        [HttpPost]
        public IActionResult Index(PeopleViewModel peopleViewModel)
        {
            if (peopleViewModel.FilterText != null)
            {
                peopleViewModel = _peopleService.FindBy(peopleViewModel);
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
            CreatePersonViewModel vm = new CreatePersonViewModel();
            vm.selectList = new SelectList(_context.Cities, "Name", "Name");
            
            return View(vm);
            //return View();
        }

        [HttpPost]
        public IActionResult Create(CreatePersonViewModel createPersonViewModel)
        {
            if (ModelState.IsValid)
            {
                _peopleService.Add(createPersonViewModel);

                return RedirectToAction(nameof(Index));
            }

            createPersonViewModel.selectList = new SelectList(_context.Cities, "Name", "Name");
            return View(createPersonViewModel);
        }

        public IActionResult Remove(int id)
        {
            _peopleService.Remove(id);

            return RedirectToAction(nameof(Index));
        }

        //public void Update()
        //{
        //    //Old ("Ola", 51239881, "Bergsjön", 2);
        //    Person person = new Person("Björn bergtop", 95235233, "Malmö", 2);
        //    _peopleService.Edit(2, person);
        //}
    }
}
