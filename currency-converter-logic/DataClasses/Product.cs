using System;
using System.Collections.Generic;
using System.Text;

namespace currency_converter_logic.DataClasses
{
    public class Product
    {
        public string Description { get; }
        public string Currency { get; }
        public decimal Price { get; }

        public Product(string desc, string currency, decimal price)
        {
            Description = desc;
            Currency = currency;
            Price = price;
        }
    }
}
