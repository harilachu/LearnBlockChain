using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleAssetManagement.Data
{
    public class Pippette
    {
        [Key]
        public Guid Pippette_Id { get; set; }

        [ForeignKey("Manufacture_Id")]
        public Manufacture Manufacture { get; set; }

        public Guid Manufacture_Id { get; set; }

        [ForeignKey("Pippette_User_Id")]
        public PippetteUser PippetteUser { get; set; }

        public Guid Pippette_User_Id { get; set; }
        
        [ForeignKey("Location_Id")]
        public Location Location { get; set; }

        public Guid Location_Id { get; set; }

        public string ModelName { get; set; }

        public string SerialNumber { get; set; }

        public int UsageFrequency { get; set; }
    }
}
