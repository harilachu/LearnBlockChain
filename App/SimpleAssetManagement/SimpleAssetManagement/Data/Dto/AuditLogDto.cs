using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SimpleAssetManagement.Helpers;

namespace SimpleAssetManagement.Data
{
    public class AuditLogDto
    {
        public string DateTimeStamp { get; set; }

        public string User { get; set; }

        public string Change { get; set; }

        public string OldValue { get; set; }

        public string NewValue { get; set; }
    }
}
