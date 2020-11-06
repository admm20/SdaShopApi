using SdaProductService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SdaProductService.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private static int _ID = 0;
        private static int _AUTOINCREMENT_ID { get { return _ID++; } }

        private static List<Address> _ADDRESS_DB = new List<Address>();

        public Address Get(int id)
        {
            return _ADDRESS_DB.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Address> GetAll()
        {
            return _ADDRESS_DB;
        }

        public Address Add(AddressAdd address)
        {
            var res = new Address()
            {
                Id = _AUTOINCREMENT_ID,
                City = address.City,
                PostNumber = address.PostNumber,
                Street = address.Street,
            };

            _ADDRESS_DB.Add(res);

            return res;
        }

        public bool Delete(int id)
        {
            var res = _ADDRESS_DB.FirstOrDefault(p => p.Id == id);

            if (res != null)
            {
                _ADDRESS_DB.Remove(res);
                return true;
            }

            return false;
        }

        public Address Update(int id, AddressAdd product)
        {
            var address = _ADDRESS_DB.FirstOrDefault(p => p.Id == id);

            address.City = product.City;
            address.PostNumber = product.PostNumber;
            address.Street = product.Street;

            return address;
        }
    }
}
