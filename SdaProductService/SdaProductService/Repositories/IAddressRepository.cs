using SdaProductService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SdaProductService.Repositories
{
    public interface IAddressRepository
    {
        Address Get(int id);
        IEnumerable<Address> GetAll();
        Address Update(int id, AddressAdd product);
        Address Add(AddressAdd product);
        bool Delete(int id);
    }
}
