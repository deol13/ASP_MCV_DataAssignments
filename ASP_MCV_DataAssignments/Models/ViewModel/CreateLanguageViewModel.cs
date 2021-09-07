using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_MCV_DataAssignments.Models.ViewModel
{
    public class CreateLanguageViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 1)]
        public string Name { get; set; }

        public SelectList selectList { get; set; }

        public CreateLanguageViewModel()
        {

        }
    }
}
