using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleAssetManagement.Data
{
    public class PippetteUserDto
    {
        [Required]
        [StringLength(100)]
        [Display(Name = "Pippette User Name")]
        public string Pippette_User_Name { get; set; }
    }
}
