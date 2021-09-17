using ASP_MCV_DataAssignments.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_MCV_DataAssignments.Models.Repo
{
    public interface ICityRepo
    {
        City Create(string name, int countryId);

        City AddPersonToCity(int cityId, int personId);

        List<City> Read();
        City Read(int id);
        City Update(CreateCityViewModel city);
        bool Delete(City city);
    }
}
