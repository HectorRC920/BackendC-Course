Func<int,int,int> sub = (int a, int b) => a-b;

Func<int,int> some = a => a*2; 
//Es lo mismo de arriba
// int Sub(int a, int b) 
// {
//   return a - b;
// }

Console.WriteLine(Some((int a, int b) => a*b,2));
int Some (Func<int,int,int> fn, int number)
{
  return fn(number, number);
}

