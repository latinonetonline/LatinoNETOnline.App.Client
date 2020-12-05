using System.ComponentModel.DataAnnotations;

namespace LatinoNETOnline.App.Client.Core.Models.Links
{
    public class LinkModel
    {
        [Required]
        public string Name { get; set; }
        [Url]
        public string Url { get; set; }
    }
}
