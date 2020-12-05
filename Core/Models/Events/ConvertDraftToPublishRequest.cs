using System;

namespace LatinoNETOnline.App.Client.Core.Models.Events
{
    public class ConvertDraftToPublishRequest
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public Guid Id { get; set; }
    }
}
