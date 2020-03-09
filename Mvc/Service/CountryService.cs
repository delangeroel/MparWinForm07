using MparWinForm07.Mvc.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MparWinForm07.Mvc.Service
{
    public class CountryService
    {
        public void save(Country actionCode)
        {
            using (var context = new MyContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.Country.Add(actionCode);

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

        public void delete(Country actionCode)
        {
            using (var context = new MyContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.Country.Remove(actionCode);

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
                return context.Country
                    .OrderBy(b => b.countrycode)
                    .ToList();
            }
        }

        public IList getCodes(string partialtext)
        {
            using (var context = new MyContext())
            {
                return context.Country
                    .OrderBy(b => b.countrycode)
                    .Where(b => b.countrycode.StartsWith(partialtext))
                    .ToList();
            }
        }

        public Country getActionCode(string actionCode)
        {
            using (var context = new MyContext())
            {
                return context.Country
                    .OrderBy(b => b.countrycode)
                    .Where(b => b.countrycode.Equals(actionCode))
                    .First();
            }
        }
        public IList getAllPaging(int offset, int showrecords)
        {
            using (var context = new MyContext())
            {
                int skipped = 0;
                return context.Country
                    .OrderBy(b => b.countrycode)
                    .Skip(offset).Take(showrecords)
                    .ToList();
            }
        }

        public int getMaxAllPaging()
        {
            using (var context = new MyContext())
            {
                return context.Actioncode
                    .OrderBy(b => b.Actioncode)
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
                    Country country = new Country();
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


                    country.countrycode = tekst;
                    country.countryName = "ABCDE_" + i;
                    context.Add(country);
                    context.SaveChanges();
                }
            }
        }
    }
}
