using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MparWinForm07.Mvc.Model
{
    public class Blog
    {
        public long BlogId { get; set; }
        public string Url { get; set; }

        public Blog() { }
        public Blog(long id, string url)
        {
            this.BlogId = id;
            this.Url = url;
        }
    }
}
