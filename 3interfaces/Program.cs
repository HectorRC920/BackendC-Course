
void Some(ISave save)
{
  save.Save();
}
Beer beer = new Beer();
Some(beer);


// Esto no va a funcionar porque la clase order no implementa
// la interfaz ISave
// Order order= new Order();
// Some(order);

Sale sale= new Sale();
Some(sale);
interface ISale 
{
  decimal Total { get; set; }
}
interface ISave 
{
  void Save();
}
public class Sale : ISale, ISave
{
  public decimal Total { get; set; }
  public void Save()
  {
    Console.WriteLine("Se guardo en db");
  }
}
public class Beer : ISave
{
  public void Save()
  {
    Console.WriteLine("Se guardo en servicio");
  }
}
public class Order : ISale
{
  public decimal Total { get; set;}
}