using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class Drug
    {
        public string DrugName;
        public float Price;
        public int Qty;
       

        public Drug(string text, float price, int qty)
        {
            DrugName = text;
            Price = price;
            Qty= qty;
        }
    }
}
