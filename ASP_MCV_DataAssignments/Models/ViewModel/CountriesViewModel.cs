using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_MCV_DataAssignments.Models.ViewModel
{
    public class CountriesViewModel
    {
        public string FilterText { get; set; }

        public List<Country> CountryList { get; set; }
    }
}
