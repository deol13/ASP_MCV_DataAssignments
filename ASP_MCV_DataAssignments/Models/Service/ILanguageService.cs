using ASP_MCV_DataAssignments.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_MCV_DataAssignments.Models.Service
{
    public interface ILanguageService
    {
        Language Add(CreateLanguageViewModel language);
        KnownLanguage AddPersonToCity(int id, Person person);
        LanguagesViewModel All();
        LanguagesViewModel FindBy(LanguagesViewModel search);
        Language Findby(int id);
        Language Edit(int id, Language language);
        bool Remove(int id);
    }
}
