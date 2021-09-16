using ASP_MCV_DataAssignments.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_MCV_DataAssignments.Models.Repo
{
    public interface IPeopleRepo
    {
        Person Create(string name, int cityId, List<int> languageId, int phoneNumber);//, Language language);
        List<Person> Read();
        Person Read(int id);
        Person Update(CreatePersonViewModel person);
        bool Delete(Person person);
    }
}
