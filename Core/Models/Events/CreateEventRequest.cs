using System;
using System.ComponentModel.DataAnnotations;

namespace LatinoNETOnline.App.Client.Core.Models.Events
{
    public class CreateEventRequest
    {
        public CreateEventRequest()
        {
            IsDraft = true;
        }

        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTime Date { get; set; }

        public string ImageBase64 { get; set; }
        [Required]
        public string Speaker { get; set; }
        public string TwitterSpeaker { get; set; }

        public bool IsDraft { get; set; }
    }
}
