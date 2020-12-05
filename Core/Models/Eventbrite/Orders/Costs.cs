using System.Collections.Generic;

namespace LatinoNETOnline.App.Client.Core.Models.Eventbrite.Orders
{
    public class Costs
    {
        public BasePrice Base_Price { get; set; }

        public BasePrice Eventbrite_Fee { get; set; }

        public BasePrice Gross { get; set; }

        public BasePrice Payment_Fee { get; set; }

        public BasePrice Tax { get; set; }

        public List<object> Fee_Components { get; set; }

        public List<object> Tax_Components { get; set; }

        public bool Has_Gts_Tax { get; set; }
    }
}
