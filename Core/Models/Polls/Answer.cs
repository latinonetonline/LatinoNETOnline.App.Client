using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace LatinoNETOnline.App.Client.Core.Models.Polls
{
    [Table("answers")]
    public class Answer
    {
        public Guid OptionId { get; set; }
    }
}
