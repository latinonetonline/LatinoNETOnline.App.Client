using System;

namespace LatinoNETOnline.App.Client.Core.Models.EasyCron
{
    public class EditCronRequest
    {
        public long CronId { get; set; }
        public string Name { get; set; }
        public string Uri { get; }
        public DateTime ExecutionDate { get; set; }
    }
}
