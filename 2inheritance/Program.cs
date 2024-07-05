//Formas de crear un objeto
// Sale venta = new Sale(12);
// Console.WriteLine(venta.GetInfo());

SaleWithTax ventaConTax = new SaleWithTax(100,16);
Console.WriteLine(ventaConTax.GetInfo());
// var venta2 = new Sale();
// venta2.Total = 200;

// Sale sale= new;
// sale.Total = 300;
 
class SaleWithTax : Sale
{
  public decimal Tax { get; set; }
  public SaleWithTax(decimal total ,decimal tax) : base(total)
  {
    Tax = tax;
  }
  public override string GetInfo()
  {
    decimal totalWithTax = ((Tax / 100) * Total) + Total;
    return $"Total with tax {totalWithTax}"; 
  }
  public string GetInfo(string message)
  {
    return message; 
  }
}

class Sale{
  public decimal Total { get; set; }
  protected string _realTotal = "";
  public Sale(decimal total)
   { 
      //cualquiere de las dos formas funciona
      //this.Total = total; 
      Total = total; 
   }
   public virtual string GetInfo()
   {
      _realTotal = $"El total es {Total} real" ;
      return _realTotal;
   }
}
