using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleAssetManagement.Data
{
    public class PippetteUser
    {
        [Key]
        public Guid Pippette_User_Id { get; set; }

        public string Pippette_User_Name { get; set; }

        public ICollection<Pippette> Pippette { get; set; }
    }
}
