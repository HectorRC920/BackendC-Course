Mylist<int> numbers = new Mylist<int>(3);
numbers.Add(1);
numbers.Add(2);
numbers.Add(3);
numbers.Add(4);
Console.WriteLine(numbers.GetList());

Beer beer1 = new Beer("Heineken", 21);
Beer beer2 = new Beer("Indio", 23);
Beer beer3 = new Beer("Guiness", 43);
var beers = new Mylist<Beer>(2);
beers.Add(beer1);
beers.Add(beer2);
beers.Add(beer3);
Console.WriteLine(beers.GetList());
public class Mylist<T>
{
  private List<T> _list;
  private int _limit;

  public Mylist(int limit)
  {
    _limit = limit;
    _list = new List<T>();
  }
  public void Add(T item)
  {
    if (_list.Count < _limit)
    {
      _list.Add(item);
    }
  }
  public string GetList()
  {
    string content = "";
    foreach (var item in _list)
    {
      if (item != null)
      {
        content += item.ToString();
      }
    }
    return content;
  }
}
  public class Beer
  {
    public string Name { get; set; }
    public decimal Price { get; set; }

    public Beer(string name, decimal price)
    {
      Name = name;
      Price = price;
    }
    public override string ToString()
    {
        return $"Name: {Name}, Price: {Price}";
    }
  }