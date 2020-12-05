namespace LatinoNETOnline.App.Client.Core.Models.Eventbrite
{
    public class Pagination
    {
        public long Object_Count { get; set; }

        public long Page_Number { get; set; }

        public long Page_Size { get; set; }

        public long Page_Count { get; set; }

        public string Continuation { get; set; }

        public bool Has_More_Items { get; set; }
    }
}
