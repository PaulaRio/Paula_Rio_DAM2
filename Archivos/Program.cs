// See https://aka.ms/new-console-template for more information

using System.Linq;

string root = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
Console.WriteLine(Directory.GetCurrentDirectory());
Console.WriteLine(root);
string nameRandomDirectory = Path.GetRandomFileName().Replace(".", "");

if (!Directory.Exists(root + "/FILES"))
{ //Probar mejor a creae un string random con longitud limitada y hacer concat con .txt
    Directory.CreateDirectory(root + "/FILES");
    for (int i = 0; i < 2; i++)
    {
        string nameRandomFile = Path.GetRandomFileName().Replace(".", "") + ".txt";
        File.Create(root + "/FILES/" + nameRandomFile);
    }
       
    Directory.CreateDirectory(root + "/FILES/"+ nameRandomDirectory);
}
else
{
    Console.WriteLine("**Archivo ya existe.**");
}

