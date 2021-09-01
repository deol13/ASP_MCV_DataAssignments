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

        [Key]
        public int Id { get; set; }

        public Person(string name, int phone, string city, int id)
        {
            Name = name;
            Phone = phone;
            City = city;
            Id = id;
        }
    }
}
