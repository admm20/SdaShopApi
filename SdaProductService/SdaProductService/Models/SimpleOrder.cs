using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SdaProductService.Models
{
    public class SimpleOrder
    {
        public int Id { get; set; }
        public string ClientName { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public decimal Price { get; set; }
    }
}
