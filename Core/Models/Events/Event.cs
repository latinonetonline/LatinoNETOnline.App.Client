using System;
using System.ComponentModel.DataAnnotations;

namespace LatinoNETOnline.App.Client.Core.Models.Events
{
    public class Event
    {
        public Guid Guid { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public string ImageUrl { get; set; }
        [Required]
        public string Speaker { get; set; }
        public string TwitterSpeaker { get; set; }
        public string EventbriteEventId { get; set; }
        public bool IsDraft { get; set; }
    }
}
