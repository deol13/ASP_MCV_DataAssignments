using Microsoft.AspNetCore.Mvc;
using ASP_MCV_DataAssignments.Models.Service;
using ASP_MCV_DataAssignments.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP_MCV_DataAssignments.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using ASP_MCV_DataAssignments.Models;
using Microsoft.AspNetCore.Authorization;

namespace ASP_MCV_DataAssignments.Controllers
{
    [Authorize(Roles = "Admin, User")]
    public class PeopleController : Controller
    {
        IPeopleService _peopleService;
        ICityService _cityService;
        ILanguageService _languageService;
        PeopleDbContext _context;

        public PeopleController(IPeopleService peopleService, ICityService cityService, ILanguageService languageService, PeopleDbContext context)
        {
            _peopleService = peopleService;
            _cityService = cityService;
            _languageService = languageService;
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<KnownLanguage> knownLanguage = _context.KnownLanguages.ToList();
            LanguagesViewModel languagesViewModel = _languageService.All();
            CitiesViewModel citiesViewModel = _cityService.All();
            List<Country> countries = _context.Countries.ToList();

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

            //The second and third parameter should be the name of the variables of the type of object the list consists of
            //In this case its a list of City's, so CityId and Name is the names of two of City's class variables.
            //Not From the viewmodel
            vm.selectList = new SelectList(_context.Cities, "CityId", "Name"); //Change so the id is sent back.

            vm.selectLanguageList = new SelectList(_context.Languages, "LanguageId", "Name"); //Change so the id is sent back

            return View(vm);
        }

        [HttpPost]
        public IActionResult Create(CreatePersonViewModel createPersonViewModel)
        {
            //Goes invalid if one of the Req in CreateViewModel is not met
            if (ModelState.IsValid)
            {
                Person person = _peopleService.Add(createPersonViewModel);

                return RedirectToAction(nameof(Index));
            }

            createPersonViewModel.selectList = new SelectList(_context.Cities, "CityId", "Name");
            createPersonViewModel.selectLanguageList = new SelectList(_context.Languages, "LanguageId", "Name"); //Change so the id is sent back

            return View(createPersonViewModel);
        }

        public IActionResult Edit(int id)
        {
            CreatePersonViewModel vm = new CreatePersonViewModel();
            Person person = _peopleService.Findby(id);

            vm.Id = id;
            vm.Name = person.Name;
            vm.Phone = person.Phone;
            vm.City = person.City.Name;
            vm.CityId = person.City.CityId;

            List<int> lIds = new List<int>();
            foreach (var item in person.KnownLanguageList)
            {
                lIds.Add(item.LanguageId);
            }
            vm.LanguageId = lIds;

            vm.selectList = new SelectList(_context.Cities, "CityId", "Name"); //Change so the id is sent back.
            vm.selectLanguageList = new SelectList(_context.Languages, "LanguageId", "Name"); //Change so the id is sent back

            return View(vm);
        }

        [HttpPost]
        public IActionResult Edit(CreatePersonViewModel createPersonViewModel) //Or  EditPersonViewModel editPersonViewModel
        {
            if (ModelState.IsValid)
            {
                List<Person> ppptesst = _context.People.ToList();
                List<KnownLanguage> teeest = _context.KnownLanguages.ToList();
                List<Language> llltteest = _context.Languages.ToList();

                Person person = _peopleService.Edit(createPersonViewModel);

                return RedirectToAction(nameof(Index));
            }

            createPersonViewModel.selectList = new SelectList(_context.Cities, "Name", "Name");
            createPersonViewModel.selectLanguageList = new SelectList(_context.Languages, "LanguageId", "Name"); //Change so the id is sent back

            return View(createPersonViewModel);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Remove(int id)
        {
            _peopleService.Remove(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
