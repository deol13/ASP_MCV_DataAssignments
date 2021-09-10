using ASP_MCV_DataAssignments.Models.Repo;
using ASP_MCV_DataAssignments.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_MCV_DataAssignments.Models.Service
{
    public class LanguageService : ILanguageService
    {
        ILanguageRepo _languagesRepo;

        public LanguageService(ILanguageRepo LanguagesRepo)
        {
            _languagesRepo = LanguagesRepo;
        }

        public Language Add(CreateLanguageViewModel language)
        {
            return _languagesRepo.Create(language.Name);
        }

        public LanguagesViewModel All()
        {
            LanguagesViewModel languagesViewModel = new LanguagesViewModel();

            languagesViewModel.LanguageList = _languagesRepo.Read();

            return languagesViewModel;
        }

        public Language Edit(int id, Language language)
        {
            return _languagesRepo.Update(language);
        }

        public LanguagesViewModel FindBy(LanguagesViewModel search)
        {
            List<Language> searchedLanguageList = new List<Language>();

            foreach (Language item in _languagesRepo.Read())
            {
                if (item.Name.Contains(search.FilterText, StringComparison.OrdinalIgnoreCase))
                {
                    searchedLanguageList.Add(item);
                }
            }
            search.LanguageList = searchedLanguageList;

            return search;
        }

        public Language Findby(int id)
        {
            return _languagesRepo.Read(id);
        }

        public bool Remove(int id)
        {
            Language language = _languagesRepo.Read(id);

            return _languagesRepo.Delete(language);
        }
    }
}
