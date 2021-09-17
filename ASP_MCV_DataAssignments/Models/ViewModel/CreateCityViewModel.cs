using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_MCV_DataAssignments.Models.ViewModel
{
    public class CreateCityViewModel
    {

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 1)]
        public string Name { get; set; }

        //[Key]
        //public int CityId { get; set; }

        
        [Required]
        public int CountryId { get; set; }
        public string Country { get; set; }

        //[Required]
        //public List<int> PeopleIds { get; set; }

        //public SelectList PoepleSelectList { get; set; }
        public SelectList CountrySelectList { get; set; }

        public CreateCityViewModel()
        {

        }
    }
}
