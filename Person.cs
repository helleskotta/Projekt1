﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryProject
{

    class Person
    {
        string firstName;
        string lastName;
        string ssn;
        List<Address> addresses;
        List<PhoneNr> phoneNrs;
        
        public Person(string firstName, string lastName, string ssn)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.ssn = ssn;
            this.addresses = new List<Address>();
            this.phoneNrs = new List<PhoneNr>();
        }
        public void AddAddress(string type, string street, string zipCode, string city)
        {
            addresses.Add(new Address(type, street, zipCode, city));
        }
        public void AddPhoneNrs(string type, string phoneNr)
        {
            phoneNrs.Add(new PhoneNr(type, phoneNr));
        }
    }
}
