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

        public Manufacture Manufacture { get; set; }

        [ForeignKey("Manufacture")]
        public Guid Manufacture_Id { get; set; }

        public PippetteUser PippetteUser { get; set; }

        [ForeignKey("PippetteUser")]
        public Guid Pippette_User_Id { get; set; }

        public Location Location { get; set; }

        [ForeignKey("Location")]
        public Guid Location_Id { get; set; }

        public string ModelName { get; set; }

        public string SerialNumber { get; set; }

        public int UsageFrequency { get; set; }
    }
}
