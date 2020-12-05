namespace LatinoNETOnline.App.Client.Core.Models.EasyCron
{
    public class ListCronJob
    {
        public string Status { get; set; }
        public CronJob[] Cron_Jobs { get; set; }
    }
}
