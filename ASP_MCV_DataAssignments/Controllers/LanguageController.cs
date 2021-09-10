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
    public class LanguageController : Controller
    {
        ILanguageService _languageService;
        PeopleDbContext _context;

        public LanguageController(ILanguageService languageService, PeopleDbContext context)
        {
            _languageService = languageService;
            _context = context;
        }


        public IActionResult Index()
        {
            ////Test1 All without anything in it
            //LanguagesViewModel languagesViewModel = _languageService.All();

            ////Test2 Add
            //CreateLanguageViewModel createLanguageViewModel = new CreateLanguageViewModel();
            //CreateLanguageViewModel createLanguageViewModel2 = new CreateLanguageViewModel();
            //CreateLanguageViewModel createLanguageViewModel3 = new CreateLanguageViewModel();
            //CreateLanguageViewModel createLanguageViewModel4 = new CreateLanguageViewModel();
            //createLanguageViewModel.Name = "Swedish";
            //createLanguageViewModel2.Name = "French";
            //createLanguageViewModel3.Name = "Mandarin";
            //createLanguageViewModel4.Name = "Spanish";

            //_languageService.Add(createLanguageViewModel);
            //_languageService.Add(createLanguageViewModel2);
            //_languageService.Add(createLanguageViewModel3);
            //_languageService.Add(createLanguageViewModel4);

            ////Test 3 All with something in it
            //LanguagesViewModel languagesViewModel3 = _languageService.All();

            //Test 4 Edit
            //CreateLanguageViewModel createLanguageViewModel5 = new CreateLanguageViewModel();
            //createLanguageViewModel2.Name = "ff";
            //_languageService.Add(createLanguageViewModel2);

            //Language language = new Language("English");
            //language.LanguageId = 5;

            //_languageService.Edit(language.LanguageId, language);

            ////Test 5 Findby ViewModel
            //LanguagesViewModel languagesViewModel2 = new LanguagesViewModel();
            //languagesViewModel2.FilterText = "English";
            //languagesViewModel2 = _languageService.FindBy(languagesViewModel2);


            ////Test 6 Findby id
            //Language language2 = _languageService.Findby(3);



            ////Test 7 Remove
            //Language language3 = new Language("Test");
            //_context.Languages.Add(language3);
            //_context.SaveChanges();
            //bool t = _languageService.Remove(5);


            return View();
        }
    }
}
