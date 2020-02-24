using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using SimpleAssetManagement.Helpers;

namespace SimpleAssetManagement.Data
{
    public class AuditLog
    {
        [Key]
        public Guid Log_Id { get; set; }

        public DateTime DateTimeStamp { get; set; }

        public string User { get; set; }

        public EnumChange Change { get; set; }

        public string OldValue { get; set; }

        public string NewValue { get; set; }
    }
}
