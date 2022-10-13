using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bevaregas.Entities
{
    public class Snack
    {
        public string UserName { get; set; }

        public List<SnackItem> Items { get; set; } = new List<SnackItem>();

        public Snack()
        {

        }

        public Snack(string userName)
        {
            UserName = userName;
        }

        public decimal TotalPrice
        {
            get
            {
                decimal totalprice = 0;
                foreach (var item in Items)
                {
                    totalprice += item.SnackPrice * item.Quantity;
                }
                return totalprice;
            }
        }

    }
}
