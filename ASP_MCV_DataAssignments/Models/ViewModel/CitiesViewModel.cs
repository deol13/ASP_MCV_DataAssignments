using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_MCV_DataAssignments.Models.ViewModel
{
    public class CitiesViewModel
    {
        public string FilterText { get; set; }

        public List<City> CityList { get; set; }
    }
}
