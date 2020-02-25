using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleAssetManagement.Data
{
    public class PippetteDataDto
    {
        [Required]
        [StringLength(10)]
        [Display(Name = "Model Name")]
        public string ModelName { get; set; }

        [Required]
        [StringLength(15)]
        [Display(Name = "Serial Number")]
        public string SerialNumber { get; set; }

        [Range(1, 1000)]
        [Display(Name = "Usage Frequency")]
        public int UsageFrequency { get; set; }

        [Display(Name = "Location")]
        public string Location_Name { get; set; }

        [Display(Name = "Manufacture")]
        public string Manufacture_Name { get; set; }

        [Display(Name = "User")]
        public string Pippette_User_Name { get; set; }
    }
}
