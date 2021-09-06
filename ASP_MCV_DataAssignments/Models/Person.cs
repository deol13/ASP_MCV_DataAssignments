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
        public int Id { get; set; }

        [Required]
        public City City { get; set; }

        public Person(string Name, int Phone)
        {
            this.Name = Name;
            this.Phone = Phone;
        }
        public Person(string Name, int Phone, int Id)
        {
            this.Name = Name;
            this.Phone = Phone;
            this.Id = Id;
        }
    }
}
