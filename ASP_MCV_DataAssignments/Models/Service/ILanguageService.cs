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
        LanguagesViewModel All();
        LanguagesViewModel FindBy(LanguagesViewModel search);
        Language Findby(int id);
        Language Edit(CreateLanguageViewModel createLanguageViewModel);
        bool Remove(int id);
    }
}
