using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MparWinForm07.Mvc.Model
{
    public class Country
    {
        [Key]
        public string countrycode { get; set; }

        public string countryName { get; set; }
        
        [Timestamp]
        public byte[] Timestamp { get; set; }

        public Country() { }
        public Country(string countrycode, string countryName)
        {
            this.countrycode = countrycode;
            this.countryName = countryName;
        }

    }
}
