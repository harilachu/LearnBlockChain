using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleAssetManagement.Data
{
    public class ManufactureDto
    {
        [Required]
        [StringLength(100)]
        [Display(Name = "Manufacture Name")]
        public string Manufacture_Name { get; set; }
    }
}
