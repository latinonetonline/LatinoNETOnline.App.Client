using System.ComponentModel.DataAnnotations;

namespace LatinoNETOnline.App.Client.Core.Models.Polls
{
    public class NewPoll
    {
        [Required]
        public string Question { get; set; }
        [Required]
        public string Answer1 { get; set; }
        [Required]
        public string Answer2 { get; set; }
        [Required]
        public string Answer3 { get; set; }
        [Required]
        public string Answer4 { get; set; }
    }
}
