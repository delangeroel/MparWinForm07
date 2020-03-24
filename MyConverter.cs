using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MparWinForm07
{
    public static class MyConverter
    {
        public static string getLong(long d)
        {
            return String.Format("0:n");
        }
    }
}
