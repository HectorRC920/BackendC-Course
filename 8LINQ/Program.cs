List<string> names = new List<string>()
{
  "Hector","Pedro","Juan","Maria","Beatriz","Luz","Pepe",
};

var namesResult = from n in names
                  where n.Length > 3 
                  orderby n
                  select n;

var namesResult2 = names.Where(n => n.Length > 3 && n.Length < 5)
                   .OrderByDescending(n => n)
                   .Select(d=>d);
foreach (var item in namesResult)
{
  Console.WriteLine(item); 
}