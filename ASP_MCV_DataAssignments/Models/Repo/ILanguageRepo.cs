using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_MCV_DataAssignments.Models.Repo
{
    public interface ILanguageRepo
    {
        Person AddPersonToLanguage(int id, Person person);
        Language Create(string name);
        List<Language> Read();
        Language Read(int id);
        Language Update(Language language);
        bool Delete(Language language);
    }
}
