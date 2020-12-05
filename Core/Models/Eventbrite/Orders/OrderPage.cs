using System.Collections.Generic;

namespace LatinoNETOnline.App.Client.Core.Models.Eventbrite.Orders
{
    public class OrderPage
    {
        public Pagination Pagination { get; set; }

        public List<Order> Orders { get; set; }
    }
}
