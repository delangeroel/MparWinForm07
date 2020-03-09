using MparWinForm07.Mvc.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MparWinForm07.Mvc.Service
{
    public class CustomerService
    {
        public void save(Customer customer)
        {
            using (var context = new MyContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.Customer.Add(customer);

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

        public void delete(Customer actionCode)
        {
            using (var context = new MyContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.Customer.Remove(actionCode);

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

        public IList getAllCustomers()
        {
            using (var context = new MyContext())
            {
                return context.Country
                    .OrderBy(b => b.countrycode)
                    .ToList();
            }
        }

        public IList getCodes(string partialtext)
        {
            using (var context = new MyContext())
            {
                return context.Customer
                    .OrderBy(b => b.CustomerNumber)
                    .ToList();
            }
        }

        public Customer getActionCode(int customerNumber)
        {
            using (var context = new MyContext())
            {
                return context.Customer
                    .OrderBy(b => b.CustomerNumber)
                    .Where(b => b.CustomerNumber == customerNumber )
                    .First();
            }
        }
        public IList getAllPaging(int offset, int showrecords)
        {
            using (var context = new MyContext())
            {
                return context.Customer
                    .OrderBy(b => b.CustomerNumber)
                    .Skip(offset).Take(showrecords)
                    .ToList();
            }
        }

        public int getMaxAllPaging()
        {
            using (var context = new MyContext())
            {
                return context.Customer
                    .OrderBy(b => b.CustomerNumber)
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
                    Customer customer = new Customer();
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


                    customer.CustomerNumber = i;
                    customer.Name = "Name_" + i;
                    customer.Address = "Add" + i;
                    customer.City = "City" + i;
                    context.Add(customer);
                    context.SaveChanges();
                }
            }
        }
    }
}
