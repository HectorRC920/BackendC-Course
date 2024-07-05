using System.Text.Json;

var hector = new People()
{
  Name = "Héctor",
  Age = 26,
};

string json = JsonSerializer.Serialize(hector);
Console.WriteLine(json);

string myJson = @"{
  ""Name"":""Juan"",""Age"":26
}";
People? juan = JsonSerializer.Deserialize<People>(myJson);
juan?.GetInfo();
Console.WriteLine(juan?.Name);
Console.WriteLine(juan?.Age);
public class People
{
  public string? Name { get; set; }
  public int Age { get; set; }
  public void GetInfo()
  {
    Console.WriteLine("Hola");
  }
}