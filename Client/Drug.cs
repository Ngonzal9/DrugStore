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
        public float ITBIS;
        public float TotalPrice;
       

        public Drug(string text, float price, int qty)
        {
            DrugName = text;
            Price = price;
            Qty= qty;
        }
        public Drug(string text, float price, int qty, float iTBIS, float totalPrice)
        {
            DrugName = text;
            Price = price;
            Qty = qty;
            ITBIS = iTBIS;
            TotalPrice = totalPrice;
        }
    }
}
