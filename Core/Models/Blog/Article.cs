using System;

using LatinoNETOnline.App.Client.Core.Enums;

namespace LatinoNETOnline.App.Client.Core.Models.Blog
{
    public class Article
    {
        public Guid ArticleId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Slug { get; set; }
        public DateTime Date { get; set; }
        public string ImageLink { get; set; }
        public string Html { get; set; }
        public string Speaker { get; set; }
        public PublicationStatus PublicationStatus { get; set; }
    }
}
