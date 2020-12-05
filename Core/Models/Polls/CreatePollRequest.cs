using System.Collections.Generic;

namespace LatinoNETOnline.App.Client.Core.Models.Polls
{
    public class CreatePollRequest
    {
        public string Question { get; set; }
        public IEnumerable<string> Answers { get; set; }
    }
}
