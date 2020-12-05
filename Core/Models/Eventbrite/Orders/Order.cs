using System;

namespace LatinoNETOnline.App.Client.Core.Models.Eventbrite.Orders
{
    public class Order
    {
        public Costs Costs { get; set; }

        public Uri Resource_Uri { get; set; }

        public string Id { get; set; }

        public DateTimeOffset Changed { get; set; }

        public DateTimeOffset Created { get; set; }

        public string Name { get; set; }

        public string First_Name { get; set; }

        public string Last_Name { get; set; }
        public string Email { get; set; }

        public string Status { get; set; }

        public object Time_Remaining { get; set; }

        public string Event_Id { get; set; }
    }
}
