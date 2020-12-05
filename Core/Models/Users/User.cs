using System;
using System.ComponentModel.DataAnnotations;

using LatinoNETOnline.App.Client.Core.Enums;

namespace LatinoNETOnline.App.Client.Core.Models.Users
{
    public class User
    {
        public Guid UserId { get; set; }
        [Required]
        public string Username { get; set; }
        public UserRole Role { get; set; }
    }
}
