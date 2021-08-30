using System;
using ASP_MCV_DataAssignments.Models.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_MCV_DataAssignments.Models.Service
{
    public interface IPeopleService
    {
        Person Add(CreatePersonViewModel person);
        PeopleViewModel All();
        PeopleViewModel FindBy(PeopleViewModel search);
        Person Findby(int id);
        Person Edit(int id, Person person);
        bool Remove(int id);

        void CreateDefaultPeople();
    }
}
