using MparWinForm07.Mvc.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MparWinForm07.Mvc.Service
{
    public class LoanService
    {
        public void save(Loan actionCode)
        {
            using (var context = new MyContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.Loan.Add(actionCode);

                        context.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                    }
                }
            }
        }

        public void delete(Loan actionCode)
        {
            using (var context = new MyContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.Loan.Remove(actionCode);

                        context.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                    }
                }
            }
        }

        public IList getAllCountries()
        {
            using (var context = new MyContext())
            {
                return context.Loan
                    .OrderBy(b => b.Id)
                    .ToList();
            }
        }

        public IList getCodes(string partialtext)
        {
            using (var context = new MyContext())
            {
                return context.Loan
                    .OrderBy(b => b.Id) 
                    .ToList();
            }
        }

        public Loan getActionCode(long id)
        {
            using (var context = new MyContext())
            {
                return context.Loan
                    .OrderBy(b => b.Id)
                    .Where(b => b.Id.Equals(id))
                    .First();
            }
        }
        public IList getAllPaging(int offset, int showrecords)
        {
            using (var context = new MyContext())
            {
                return context.Loan
                    .OrderBy(b => b.Id)
                    .Skip(offset).Take(showrecords)
                    .ToList();
            }
        }

        public int getMaxAllPaging()
        {
            using (var context = new MyContext())
            {
                return context.Loan
                    .OrderBy(b => b.Id)
                    .Count();
            }
        }

        public void create500()
        {
            for (int i = 1; i < 500; i++)
            {
                string tekst = "";
                using (var context = new MyContext())
                {
                    Loan loan = new Loan();
                    if (i < 10)
                    {
                        tekst = "000" + i;
                    }
                    else if (i < 100)
                    {
                        tekst = "00" + i;
                    }
                    else if (i < 1000)
                    {
                        tekst = "0" + i;
                    }


                    loan.IntrestDay = DateTime.Now;
                    loan.CustomerNumber = i;
                    loan.Amount = new decimal(100000 / i);
                    context.Add(loan);
                    context.SaveChanges();
                }
            }
        }
    }
}
