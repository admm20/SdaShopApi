using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SdaProductService.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Address Address { get; set; }
        public string NIP { get; set; }
    }
}
