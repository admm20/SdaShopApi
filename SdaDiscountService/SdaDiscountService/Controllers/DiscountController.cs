using Microsoft.AspNetCore.Mvc;
using SdaDiscountService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SdaDiscountService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        // POST api/discount
        [HttpPost]
        public ActionResult<decimal> Post([FromBody] IEnumerable<Product> products)
        {
            decimal sum = products.Sum(p => p.Price);

            if (products.Count() > 2)
                sum *= 0.9M;

            return Ok(sum);
        }
    }
}
