using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleAssetManagement.Data
{
    public class LocationDto
    {
        [Required]
        [StringLength(10)]
        [Display(Name = "Location Name")]
        public string Location_Name { get; set; }
    }
}
