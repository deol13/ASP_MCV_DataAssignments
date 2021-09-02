using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_MCV_DataAssignments.Models.ViewModel
{
    public class CreatePersonViewModel
    {
        [Required]
        [StringLength(15, MinimumLength = 1)]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        public int Phone { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 1)]
        public string City { get; set; }

        [Key]
        public int Id { get; set; }

        public CreatePersonViewModel()
        {

        }
    }
}
