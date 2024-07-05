//Formas de crear un objeto
Sale venta = new Sale(12);
Console.WriteLine(venta.GetInfo());
// var venta2 = new Sale();
// venta2.Total = 200;

// Sale sale= new;
// sale.Total = 300;
class Sale{
  public decimal Total { get; set; }
  protected string _realTotal = "";
  public Sale(decimal total)
   { 
      //cualquiere de las dos formas funciona
      //this.Total = total; 
      Total = total; 
   }
   public string GetInfo()
   {
      _realTotal = $"El total es {Total} real" ;
      return _realTotal;
   }
}
