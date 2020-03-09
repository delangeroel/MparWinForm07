using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MparWinForm07.Mvc.Model
{
    public class Customer
    {
        [Key]
        public int CustomerNumber { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public Country CountryCode { get; set; }

        [Timestamp]
        public byte[] Timestamp { get; set; }

        public Customer() { }
        public Customer(int CustomerNumber, string Name, string Address, string City, Country CountryCode)
        {
            this.CustomerNumber = CustomerNumber;
            this.Name = Name;
            this.Address = Address;
            this.City = City;
            this.CountryCode = CountryCode;

        }
    }
}
