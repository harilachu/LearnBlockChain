using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace SimpleAssetManagement.Data
{
    public class AuditDataService
    {
        public AuditDataService(IJSRuntime JSRuntime)
        {
            this.JSRuntime = JSRuntime;
            this.AuditLogCollection = new List<AuditLogDto>();
        }

        public IJSRuntime JSRuntime { get; }
        public int LogCount { get; set; }
        public List<AuditLogDto> AuditLogCollection { get; set; }

        public async Task<IEnumerable<AuditLogDto>> FetchAuditLogsAsync()
        {
            this.AuditLogCollection.Clear();

            var Count = await JSRuntime.InvokeAsync<string>("FetchLogCount");
            LogCount = int.Parse(Count);

            for (int i = 0; i < LogCount; i++)
            {
                var log = await JSRuntime.InvokeAsync<object>("FetchLogs", i.ToString());
                var auditlog = JsonSerializer.Deserialize<Dictionary<string, object>>(log.ToString());

                var datetimestamp = auditlog["datetimestamp"];
                var user = auditlog["user"];
                var change = auditlog["change"];
                var oldvalue = auditlog["oldvalue"];
                var newvalue = auditlog["newvalue"];

                var auditLogDto = new AuditLogDto()
                {
                    DateTimeStamp = datetimestamp.ToString(),
                    User = user.ToString(),
                    Change = change.ToString(),
                    OldValue = oldvalue.ToString(),
                    NewValue = newvalue.ToString()
                };

                AuditLogCollection.Add(auditLogDto);
            }

            return AuditLogCollection;
        }

        public async Task AddLog(AuditLogDto auditLogDto)
        {
            await JSRuntime.InvokeVoidAsync("AddLog", auditLogDto.DateTimeStamp, auditLogDto.User, auditLogDto.Change, auditLogDto.OldValue, auditLogDto.NewValue);
        }
    }
}
