using currency_converter_logic.DataClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace currency_converter_logic
{
   public interface IConverter
    {
        public decimal convert(string product, string targetCurrency, IEnumerable<Product> products, IEnumerable<Exchange> exchanges);
    }
}
