using currency_converter_logic.DataClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace currency_converter_logic
{
    public interface IParser
    {
        public IEnumerable<Product> ParseProducts(string text);

        public IEnumerable<Exchange> ParseExchange(string text);
    }
}
