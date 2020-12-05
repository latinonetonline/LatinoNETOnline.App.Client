namespace LatinoNETOnline.App.Client.Core.Models.Eventbrite
{
    public class TicketClass
    {
        public string Name { get; set; }
        public long Quantity_Total { get; set; }
        public bool Free { get; set; }

        public static TicketClass FreeTicket { get; set; } = new TicketClass
        {
            Name = "Free",
            Free = true,
            Quantity_Total = 500000
        };
    }
}
