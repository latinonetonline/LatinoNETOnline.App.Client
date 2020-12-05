using System;

namespace LatinoNETOnline.App.Client.Core.Models.EasyCron
{
    public class CreateCronRequest
    {
        public string Name { get; set; }
        public Uri Uri { get; }
        public DateTime ExecutionDate { get; set; }
    }
}
