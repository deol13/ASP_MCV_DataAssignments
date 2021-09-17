using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_MCV_DataAssignments.Models.ViewModel
{
    public class AddPersonToCityViewModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int PersonId { get; set; }

        public string CityString { get; set; }
        public int PersonString { get; set; }

        public SelectList CitiesSelectList { get; set; }
        public SelectList PeopleSelectList { get; set; }

        public AddPersonToCityViewModel()
        {

        }
    }
}
