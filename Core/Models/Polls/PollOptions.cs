using System.Collections.Generic;

namespace LatinoNETOnline.App.Client.Core.Models.Polls
{
    public class PollOptions : Poll
    {
        public IEnumerable<Option> Options { get; set; }
    }
}
