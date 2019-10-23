using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using currency_converter_logic;
using currency_converter_logic.DataClasses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace currency_converter.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class CurrencyConverterController : ControllerBase
    {

        private readonly HttpClient client;
        private readonly IParser parser;
        private readonly IConverter converter;

        public CurrencyConverterController(IHttpClientFactory factory, IParser parser, IConverter converter)
        {
            client = factory.CreateClient("currencyAPI");
            this.parser = parser;
            this.converter = converter;
        }


        [HttpGet]
        [Route("{product}/price")]
        public async Task<IActionResult> Get(string product, [FromQuery]string targetCurrency)
        {
            var responseRates = await client.GetAsync("ExchangeRates.csv");
            var responseProduct = await client.GetAsync("Prices.csv");

            var ratesString = await responseRates.Content.ReadAsStringAsync();
            var productsString = await responseProduct.Content.ReadAsStringAsync();

            IEnumerable<Product> products = parser.ParseProducts(productsString);
            IEnumerable<Exchange> exchanges = parser.ParseExchange(ratesString);

            decimal price = converter.convert(product, targetCurrency, products, exchanges);
            return Ok("Preis: " + price);
        }
    }
}
