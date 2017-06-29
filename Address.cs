using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryProject
{
    class Address
    {
        string type;
        string street;
        string zipCode;
        string city;

        public Address(string type, string street, string zipCode, string city)
        {
            this.type = type;
            this.street = street;
            this.zipCode = zipCode;
            this.city = city;
        }

    }
}
