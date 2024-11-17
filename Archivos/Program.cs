// See https://aka.ms/new-console-template for more information

using System.Linq;

//string root = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
string rootFILES = "../../.." + "/FILES";
Console.WriteLine(Directory.GetCurrentDirectory());
Console.WriteLine(rootFILES);
string nameRandomDirectory = Path.GetRandomFileName().Replace(".", "");

if (!Directory.Exists(rootFILES))
{ //Probar mejor a creae un string random con longitud limitada y hacer concat con .txt
    Directory.CreateDirectory(rootFILES);
    for (int i = 0; i < 2; i++)
    {
        string nameRandomFile = Path.GetRandomFileName().Replace(".", "") + ".txt";
        File.Create(rootFILES  +"/"+ nameRandomFile);
    }

    Directory.CreateDirectory(rootFILES + "/" + nameRandomDirectory);
}
else
{
    Console.WriteLine("**Archivo ya existe.**");
    foreach (var item in Directory.GetDirectories(rootFILES))
    {
      
        Console.WriteLine(Path.GetFileName(item));
    }
    foreach (var item in Directory.GetFiles(rootFILES))
    {

        Console.WriteLine(Path.GetFileName(item));
    }

}

