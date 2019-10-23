using System;
using System.Collections.Generic;
using System.Text;

namespace currency_converter_logic.DataClasses
{
    public class Exchange
    {
        public string Currency { get; }
        public decimal Rate { get; }

        public Exchange(string curreny, decimal rate)
        {
            Currency = curreny;
            Rate = rate;
        }
    }
}
