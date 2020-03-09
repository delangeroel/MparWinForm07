LINQ

Website  https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/
https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/query-expression-syntax-for-standard-query-operators

int[] scores = new int[] { 97, 92, 81, 60 };

IEnumerable,  IQueryable<string>
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
            group student by student.Last[0];
            select stringGroup;