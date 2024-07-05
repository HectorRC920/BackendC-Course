// DateTime date = DateTime.Now;

// Console.WriteLine(GetTomorrow(date));

// DateTime GetTomorrow(DateTime date)
// {
//   return date.AddDays(1);
// }


Beer beer = new Beer()
{
  Name = "guinness",
};

Console.WriteLine(ToUpper(beer).Name);
Console.WriteLine(beer.Name);
//Aqui podriamos mutar la clase pasada por referencia
//Pero lo que se quiere es tener una funcion pura
Beer ToUpper(Beer beer)
{
  var newBeer = new Beer() { Name = $"{beer.Name.ToUpper()}" };
  return newBeer;
}
//---------------------------------------------------------------------------
//Funcion de primera clase:
//Una funcion que puede ser guardada en una variable

var show = Show;

// show("Hola");

string Show(string message)
{
  return message.ToUpper();
}
void  Some (Func<string, string> fn, string message)
{
  Console.WriteLine("Hace algo aqui");
  Console.WriteLine(fn(message));
  Console.WriteLine("Hace otra cosa aca");
}
Some(show, "Que peo");
public class Beer
{
  public string Name { get; set; }
}


