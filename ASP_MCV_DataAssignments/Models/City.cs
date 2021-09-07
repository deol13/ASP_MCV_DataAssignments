using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_MCV_DataAssignments.Models
{
    public class City
    {
        [Key]
        public int CityId { get; set; }

        [Required]
        [MaxLength(15)]
        [MinLength(1)]
        public string Name { get; set; }

        [Required]
        public Country Country { get; set; }

        public List<Person> PeopleInCity { get; set; }

        public City(string Name)
        {
            this.Name = Name;
            PeopleInCity = new List<Person>();
        }
    }
}
