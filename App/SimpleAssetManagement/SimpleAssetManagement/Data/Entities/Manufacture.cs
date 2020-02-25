using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleAssetManagement.Data
{
    public class Manufacture
    {
        [Key]
        public Guid Manufacture_Id { get; set; }

        public string Manufacture_Name { get; set; }

        public ICollection<Pippette> Pippette { get; set; }
    }
}
