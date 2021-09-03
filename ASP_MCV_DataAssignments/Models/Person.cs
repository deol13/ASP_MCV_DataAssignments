using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_MCV_DataAssignments.Models
{
    public class Person
    {
        [Required]
        [MaxLength(15)]
        [MinLength(1)]
        public string Name { get; set; }

        [Required]
        [Range(10, 14)]
        public int Phone { get; set; }

        [Required]
        [MaxLength(15)]
        [MinLength(1)]
        public string City { get; set; }

        [Required]
        public int Id { get; set; }

        public Person(string Name, int Phone, string City)
        {
            this.Name = Name;
            this.Phone = Phone;
            this.City = City;
        }
        public Person(string Name, int Phone, string City, int Id)
        {
            this.Name = Name;
            this.Phone = Phone;
            this.City = City;
            this.Id = Id;
        }
    }
}
