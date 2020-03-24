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
        //[Key]
        //public lond id { get; set; }

        [Key]
        public string Countrycode { get; set; }

        public string CountryName { get; set; }
        
        [Timestamp]
        public byte[] Timestamp { get; set; }

        public Country() { }
        public Country(string countrycode, string countryName)
        {
            this.Countrycode = countrycode;
            this.CountryName = countryName;
        }

    }
}
