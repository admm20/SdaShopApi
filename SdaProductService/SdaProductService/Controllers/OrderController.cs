using Microsoft.AspNetCore.Mvc;
using SdaProductService.Models;
using SdaProductService.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SdaProductService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private IOrderRepository _orderRepository;

        public OrderController(IOrderRepository repo)
        {
            _orderRepository = repo;
        }

        // GET api/order
        [HttpGet]
        public ActionResult<IEnumerable<SimpleOrder>> Get()
        {
            return Ok(_orderRepository.GetAll());
        }

        // GET api/order/5
        [HttpGet("{id}")]
        public ActionResult<SimpleOrder> Get(int id)
        {
            var order = _orderRepository.Get(id);

            if (order != null)
                return Ok(order);

            return NotFound();
        }

        // POST api/order
        [HttpPost]
        public ActionResult<SimpleOrder> Post([FromBody] SimpleOrderAdd orderAdd)
        {
            var addedProduct = _orderRepository.Add(orderAdd);

            return Ok(addedProduct);
        }

        // PUT api/order/5
        [HttpPut("{id}")]
        public ActionResult<SimpleOrder> Put(int id, [FromBody] SimpleOrderAdd orderAdd)
        {
            return Ok(_orderRepository.Update(id, orderAdd));
        }

        // DELETE api/order/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var deleted = _orderRepository.Delete(id);

            if (deleted)
                return Ok();

            return NotFound();
        }
    }
}
