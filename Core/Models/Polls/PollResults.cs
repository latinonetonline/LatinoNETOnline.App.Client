using System.Collections.Generic;

namespace LatinoNETOnline.App.Client.Core.Models.Polls
{
    public class PollOptionsResults
    {
        public Poll Poll { get; set; }
        public IEnumerable<OptionVotes> Options { get; set; }
    }
}
