using ASP_MCV_DataAssignments.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_MCV_DataAssignments.Models.Service
{
    public interface ICityService
    {
        City Add(CreateCityViewModel city);
        CitiesViewModel All();
        CitiesViewModel FindBy(CitiesViewModel search);
        City Findby(int id);
        City Edit(CreateCityViewModel city);
        bool Remove(int id);
    }
}
