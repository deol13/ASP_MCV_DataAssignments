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

namespace ASP_MCV_DataAssignments.Controllers
{
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
            vm.selectList = new SelectList(_context.Cities, "CityId", "Name"); //Change so the id is sent back.
            vm.selectLanguageList = new SelectList(_context.Languages, "LanguageId", "Name"); //Change so the id is sent back

            return View(vm);
        }

        [HttpPost]
        public IActionResult Create(CreatePersonViewModel createPersonViewModel)
        {
            if (ModelState.IsValid)
            {
                Person person = _peopleService.Add(createPersonViewModel);

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
    }
}
