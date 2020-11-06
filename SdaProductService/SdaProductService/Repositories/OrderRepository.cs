using SdaProductService.Models;
using SdaProductService.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SdaProductService.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private static int _ID = 0;
        private static int _AUTOINCREMENT_ID { get { return _ID++; } }

        private static List<SimpleOrder> _ORDER_DB = new List<SimpleOrder>();

        private DiscountProvider discountProvider = new DiscountProvider();

        public SimpleOrder Get(int id)
        {
            return _ORDER_DB.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<SimpleOrder> GetAll()
        {
            return _ORDER_DB;
        }

        public SimpleOrder Add(SimpleOrderAdd orderAdd)
        {
            var products = ProductRepository._PRODUCT_DB.Where(p => orderAdd.ProductIds.Contains(p.Id));

            var res = new SimpleOrder()
            {
                Id = _AUTOINCREMENT_ID,
                ClientName = orderAdd.ClientName,
                Products = products,
                Price = discountProvider.GetOrderPrice(products) //orderAdd.Price
            };

            _ORDER_DB.Add(res);

            return res;
        }

        public bool Delete(int id)
        {
            var res = _ORDER_DB.FirstOrDefault(p => p.Id == id);

            if (res != null)
            {
                _ORDER_DB.Remove(res);
                return true;
            }

            return false;
        }

        public SimpleOrder Update(int id, SimpleOrderAdd orderAdd)
        {
            var order = _ORDER_DB.FirstOrDefault(p => p.Id == id);

            order.ClientName = orderAdd.ClientName;
            order.Products = ProductRepository._PRODUCT_DB.Where(p => orderAdd.ProductIds.Contains(p.Id));
            order.Price = discountProvider.GetOrderPrice(order.Products);//orderAdd.Price;

            return order;
        }
    }
}
