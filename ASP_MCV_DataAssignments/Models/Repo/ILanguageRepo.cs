using ASP_MCV_DataAssignments.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_MCV_DataAssignments.Models.Repo
{
    public interface ILanguageRepo
    {
        Language Create(CreateLanguageViewModel language);
        List<Language> Read();
        Language Read(int id);
        Language Update(CreateLanguageViewModel createLanguageViewModel);
        bool Delete(Language language);
    }
}
