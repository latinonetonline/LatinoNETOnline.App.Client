using System;

namespace LatinoNETOnline.App.Client.Core.Models.Polls
{
    public class Option
    {
        public Guid OptionId { get; set; }
        public string Text { get; set; }
        public Guid PollId { get; set; }
    }
}
