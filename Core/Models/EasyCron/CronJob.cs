using System;

namespace LatinoNETOnline.App.Client.Core.Models.EasyCron
{
    public class CronJob
    {
        public long Cron_Job_Id { get; set; }

        public string Cron_Job_Name { get; set; }

        public string Description { get; set; }

        public string Url { get; set; }

        public string Cron_Expression { get; set; }

        public bool Status { get; set; }

        public DateTimeOffset Created { get; set; }

        public DateTimeOffset Updated { get; set; }
    }
}
