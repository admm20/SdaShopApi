using SdaProductService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace SdaProductService.Providers
{
    public class DiscountProvider
    {
        public decimal GetOrderPrice(IEnumerable<Product> products)
        {
            var client = new HttpClient();

            var content = client.PostAsJsonAsync<IEnumerable<Product>>("https://localhost:44309/api/discount", products)
                .GetAwaiter().GetResult();

            var stringContent = content.Content.ReadAsStringAsync()
                .GetAwaiter()
                .GetResult()
                .Replace(".", ",");

            var price = decimal.Parse(stringContent, System.Globalization.NumberStyles.Number);

            return price;
        }
    }
}
