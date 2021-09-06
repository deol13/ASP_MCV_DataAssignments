using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_MCV_DataAssignments.Models
{
    public class Country
    {
        [Key]
        public int CountryId { get; set; }
        [Required]
        [MaxLength(15)]
        [MinLength(1)]
        public string Name { get; set; }

        public List<City> Cities { get; set; }

        public Country(string Name)
        {
            this.Name = Name;
            Cities = new List<City>();
        }
    }
}
