using SdaProductService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SdaProductService.Repositories
{
    public interface IOrderRepository
    {
        SimpleOrder Get(int id);
        IEnumerable<SimpleOrder> GetAll();
        SimpleOrder Update(int id, SimpleOrderAdd product);
        SimpleOrder Add(SimpleOrderAdd product);
        bool Delete(int id);
    }
}
