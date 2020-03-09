using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MparWinForm07.Linq
{
    public class Market
    {
        public string Name { get; set; }
        public string[] Items { get; set; }


    public void run()
    {
        List<Market> markets = new List<Market>
    {
        new Market { Name = "Roel", Items = new string[] { "Sinaasappel", "CitKersroen", "Banaan" } },
        new Market { Name = "Desiree", Items = new string[] { "Meloen", "mango", "Appel" } },
        new Market { Name = "Stefan", Items = new string[] { "Kers", "Banaan", "Appel" } },
        new Market { Name = "Harry", Items = new string[] { "Kiwi", "apple", "Framboos" } },
        new Market { Name = "Tia", Items = new string[] { "Meloen", "Appel", "Framboos" } },
        new Market { Name = "Wim", Items = new string[] { "Kiwi", "Kers", "Framboos" } },
        new Market { Name = "Jolanda", Items = new string[] { "Mandarijn", "Kers", "Sinaasappel" } },
        new Market { Name = "Jammy", Items = new string[] { "Meloen", "Braam", "Kers" } },
    };

        // Determine which market have all fruit names length equal to 5
        IEnumerable<string> names = from market in markets
                                    where market.Items.All(item => item.Length == 5)
                                    select market.Name;

        foreach (string name in names)
        {
            Console.WriteLine($"{name} market");
        }

        // This code produces the following output:
        //
        // Kim's market
    }
    }
}
