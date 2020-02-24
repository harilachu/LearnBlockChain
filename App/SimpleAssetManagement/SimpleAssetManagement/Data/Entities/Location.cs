using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleAssetManagement.Data
{
    public class Location
    {
        [Key]
        public Guid Location_Id { get; set; }

        public string Location_Name { get; set; }

        public Pippette Pippette { get; set; }
    }
}
