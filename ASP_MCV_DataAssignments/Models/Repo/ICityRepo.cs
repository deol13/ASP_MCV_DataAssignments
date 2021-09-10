using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_MCV_DataAssignments.Models.Repo
{
    public interface ICityRepo
    {
        City Create(string name);
        List<City> Read();
        City Read(int id);
        City Update(City city);
        bool Delete(City city);
    }
}
