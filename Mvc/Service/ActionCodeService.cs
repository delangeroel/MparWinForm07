using MparWinForm07.Mvc.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MparWinForm07.Mvc.Service
{
    public class ActionCodeService
    {
        public void save(ActionCode actionCode)
        {
            using (var context = new MyContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.Actioncode.Add(actionCode);
                        
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

        public void delete(ActionCode actionCode)
        {
            using (var context = new MyContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.Actioncode.Remove(actionCode);

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

        public IList getAllActionCodes() 
        {
            using (var context = new MyContext())
            {
                return context.Actioncode
                    .OrderBy(b => b.Actioncode)
                    .ToList();
            }
        }

        public IList getCodes(string partialtext)
        {
            using (var context = new MyContext())
            {
                return context.Actioncode
                    .OrderBy(b => b.Actioncode)
                    .Where(b => b.Actioncode.StartsWith(partialtext))
                    .ToList();
            }
        }

        public ActionCode getActionCode(string actionCode)
        {
            using (var context = new MyContext())
            {
                return context.Actioncode
                    .OrderBy(b => b.Actioncode)
                    .Where(b => b.Actioncode.Equals(actionCode))
                    .First();
            }
        }
        public IList getAllPaging(int offset, int showrecords)
        {
            using (var context = new MyContext())
            {
                int skipped = 0;
                //if (startPage == 0)   skipped = 0;
                //else if (startPage>0) skipped = (startPage ) * showrecords;
               // else             skipped =  showrecords;
                return context.Actioncode
                    .OrderBy(b => b.Actioncode)
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
            for (int i=1;  i < 500; i++)
            {
                string tekst = "";
                using (var context = new MyContext())
                {
                    ActionCode code = new ActionCode();
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
                    
 
                    code.Actioncode = tekst;
                    code.Description = "ABCDE_" + i;
                    context.Add(code);
                    context.SaveChanges();
                } 
            }
        }
    }
}
