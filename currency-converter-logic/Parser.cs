using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using currency_converter_logic.DataClasses;

namespace currency_converter_logic
{
    public class Parser : IParser
    {
        public IEnumerable<Exchange> ParseExchange(string text)
        {
            List<string[]> csvValues = ParseToLines(text);
            List<Exchange> exchanges = new List<Exchange>();

            foreach (var curExchange in csvValues)
            {
                exchanges.Add(new Exchange(curExchange[0], decimal.Parse(curExchange[1], CultureInfo.InvariantCulture)));
            }
            return exchanges;
        }

        public IEnumerable<Product> ParseProducts(string text)
        {
            List<string[]> csvValues = ParseToLines(text);
            List<Product> products = new List<Product>();

            foreach (var curProduct in csvValues)
            {
                products.Add(new Product(curProduct[0], curProduct[1], decimal.Parse(curProduct[2], CultureInfo.InvariantCulture)));
            }
            return products;
        }

        public List<string[]> ParseToLines(string text)
        {
            List<string[]> elements = new List<string[]>();
            string[] lines = text.Replace("\r", string.Empty).Split("\n");

            bool first = true;
            foreach (var line in lines)
            {
                if (!first)
                {
                    string[] curElements = line.Split(",");
                    if (curElements.Length > 1)
                        elements.Add(curElements);
                }
                first = false;
            }
            return elements;
        }
    }
}
