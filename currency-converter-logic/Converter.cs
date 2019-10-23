using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using currency_converter_logic.DataClasses;

namespace currency_converter_logic
{
    public class Converter : IConverter
    {
        public decimal convert(string product, string targetCurrency, IEnumerable<Product> products, IEnumerable<Exchange> exchanges)
        {
            decimal price = 0;
            foreach(var curProduct in products)
            {
                if (curProduct.Description.Equals(product))
                {
                    var exchangeRate = from exchange in exchanges
                                       where exchange.Currency.Equals(curProduct.Currency)
                                       select exchange.Rate;
                    price = curProduct.Price / exchangeRate.First();
                }
            }
            return Decimal.Round(price, 2);
        }
    }
}
