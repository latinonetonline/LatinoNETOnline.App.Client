using System.Collections.Generic;

namespace LatinoNETOnline.App.Client.Core.Models.Twitter
{
    public class MentionsAndHashtags
    {
        public IEnumerable<string> Mentions { get; set; }
        public IEnumerable<string> Hashtags { get; set; }
    }
}
