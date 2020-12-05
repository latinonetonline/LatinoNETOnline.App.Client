using System.Net;

using LatinoNETOnline.App.Client.Core.Models.Events;

namespace LatinoNETOnline.App.Client.Core.Extensions
{
    public static class BlogExtensions
    {
        public static string GetSlug(this Event @event)
        {
            var formated = @event.Title.Trim()
                .Replace(" - ", " ")
                .Replace("-", string.Empty)
                .Replace(" : ", " ")
                .Replace(":", string.Empty)
                .Replace(" # ", " ")
                .Replace("#", string.Empty)
                .Replace(" + ", " ")
                .Replace("+", string.Empty)
                .Replace(" < ", " ")
                .Replace("<", string.Empty)
                .Replace(" > ", " ")
                .Replace(">", string.Empty)
                .Replace(" ? ", " ")
                .Replace("?", string.Empty)
                .Replace(" | ", " ")
                .Replace("|", string.Empty)
                .Replace(" / ", " ")
                .Replace("/", string.Empty)
                .Replace(" \\ ", " ")
                .Replace("\\", string.Empty)
                .Replace("--", " ")
                .Replace(" ", "-");
            return WebUtility.UrlEncode(formated).ToLower();

        }
    }
}
