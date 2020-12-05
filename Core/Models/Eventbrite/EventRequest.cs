namespace LatinoNETOnline.App.Client.Core.Models.Eventbrite
{
    public class EventRequest
    {
        public HtmlText Name { get; set; }
        public HtmlText Description { get; set; }
        public Date Start { get; set; }
        public Date End { get; set; }
        public string Currency { get; set; }
        public string Capacity { get; set; }
        public string Logo_Id { get; set; }
        public bool Shareable { get; set; }
        public bool Listed { get; set; }
        public bool Online_Event { get; set; }
        public string Category_Id { get; set; }
        public string Subcategory_Id { get; set; }
        public string Organizer_Id { get; set; }
    }
}
