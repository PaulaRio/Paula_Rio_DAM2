// See https://aka.ms/new-console-template for more information

using System.Linq;

string root = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
Console.WriteLine(Directory.GetCurrentDirectory());
Console.WriteLine(root);
string splitRandomFile =Path.GetRandomFileName().Replace(".","")+ ".txt";


if (!Directory.Exists(root + "/FILES"))
{ //Probar mejor a creae un string random con longitud limitada y hacer concat con .txt
    Directory.CreateDirectory(root + "/FILES");
    
    File.Create(root + "/FILES/"+ splitRandomFile);

}
else
{
    Console.WriteLine("**Archivo ya existe.**");
}

