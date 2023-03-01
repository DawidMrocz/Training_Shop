﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training_Shop.Domain.Entities
{
    public class Address
    {
        public int AddressId { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int UserId { get; set; }
        public User User { get; set; } = null!;
        public Address(string country,string city,string street) 
        {
            Country = country;
            City = city;
            Street = street;
        }
    }
}
