using System;
using System.ComponentModel.DataAnnotations;

namespace LatinoNETOnline.App.Client.Core.Models.Twitter
{
    public class CreateTweetRequest
    {
        [Required]
        [MaxLength(280)]
        public string Status { get; set; }
        public DateTime Date { get; set; }
        public string ImageBase64 { get; set; }
    }
}
