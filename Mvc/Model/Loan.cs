using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MparWinForm07.Mvc.Model
{
    public class Loan
    {
        [Key]
        public long Id { get; set; }
        public int CustomerNumber { get; set; }
        public decimal Amount { get; set; }
        public DateTime IntrestDay { get; set; }
        public string User { get; set; }
        public DateTime ChangeDate { get; set; }
        public Status Status { get; set; }
        [Timestamp]
        public byte[] Timestamp { get; set; }

        public Loan() { }
        public Loan(int CustomerNumber, decimal Amount, DateTime IntrestDay, string User, Status Status)
        {
            this.CustomerNumber = CustomerNumber;
            this.Amount = Amount;
            this.IntrestDay = IntrestDay;
            this.User = User;
            this.Status = Status;
        }

    }
}
