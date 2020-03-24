using MparWinForm07.Mvc.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MparWinForm07.Mvc.Service
{
    public class BlogService
    {
        public void save(Blog blog)
        {
            using (var context = new MyContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.Blog.Add(blog);

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
        public void delete(Blog blog)
        {
            using (var context = new MyContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.Blog.Remove(blog);

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
        public IList getAllBlogs()
        {
            using (var context = new MyContext())
            {
                return context.Blog
                    .OrderBy(b => b.BlogId)
                    .ToList();
            }
        }
        public IList getCodes(string partialtext)
        {
            using (var context = new MyContext())
            {
                return context.Blog
                    .OrderBy(b => b.BlogId)
                    .ToList();
            }
        }
        public Blog getBlogCode(long id)
        {
            using (var context = new MyContext())
            {
                return context.Blog
                    .OrderBy(b => b.BlogId)
                    .Where(b => b.BlogId==(id))
                    .First();
            }
        }
        public IList getAllPaging(int offset, int showrecords)
        {
            using (var context = new MyContext())
            {
                return context.Blog
                    .OrderBy(b => b.BlogId)
                    .Skip(offset).Take(showrecords)
                    .ToList();
            }
        }
        public int getMaxAllPaging()
        {
            using (var context = new MyContext())
            {
                return context.Blog
                    .OrderBy(b => b.BlogId)
                    .Count();
            }
        }
        public void createRecords(int numberOfRecords)
        {
            for (int i = 1; i < numberOfRecords; i++)
            {
                string tekst = "";
                using (var context = new MyContext())
                {
                    Blog blog = new Blog();
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
    
                    context.Add(blog);
                    context.SaveChanges();
                }
            }
        }
    }
}
