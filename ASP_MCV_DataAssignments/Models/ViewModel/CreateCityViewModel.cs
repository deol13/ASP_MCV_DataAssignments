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
        [Required]
        [StringLength(15, MinimumLength = 1)]
        public string Name { get; set; }

        [Key]
        public int CityId { get; set; }

        [Required]
        public List<int> PeopleIds { get; set; }

        [Required]
        public SelectList selectList { get; set; }

        public CreateCityViewModel()
        {

        }
    }
}
