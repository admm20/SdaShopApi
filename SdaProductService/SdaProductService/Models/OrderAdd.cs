using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SdaProductService.Models
{
    public class OrderAdd
    {
        public int ClientId { get; set; }
        public IEnumerable<int> ProductIds { get; set; }
        public decimal Price { get; set; }
    }
}
