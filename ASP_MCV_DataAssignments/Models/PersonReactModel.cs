using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_MCV_DataAssignments.Models
{
    public class PersonReactModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Phone { get; set; }

        public string City { get; set; }

        public int CityId { get; set; }

        public string Country { get; set; }



        public PersonReactModel(int Id, string Name, int Phone, string City, string Country)
        {
            this.Id = Id;
            this.Name = Name;
            this.Phone = Phone;
            this.City = City;
            this.Country = Country;
        }
    }
}
