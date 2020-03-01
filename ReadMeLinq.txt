LINQ

Website  https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/

int[] scores = new int[] { 97, 92, 81, 60 };

//---------------------
// Queries that do not transform the source data
 IEnumerable<int> scoreQuery =
            from score in scores       // From is 'int' in  IEnumerable<int>.  
            where score > 80
            select score;
 foreach(int str in scoreQuery)
 {
 }
 //---------------------
 // Queries that do transform the source data
 Table<Customer> Customers = db.GetTable<Customers>
 IQueryable<string> custNameQuery = from cust in Customers  
                where Cust.City == 'Sevilla'  
                select cust.Name    // Hier kun je ook meerdere velden teruggeven
 foreach (string str in custNameQuery)
 {
 }
 
 //---------------------
var query = from str in stringArray
            group str by str[0] into stringGroup
            orderby stringGroup.Key
            select stringGroup;