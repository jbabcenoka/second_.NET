using System;
using InterfacesImplementation;

namespace uzdevums_10
{
    class Program
    {
        static void Main(string[] args)
        {
            string FileName = "..//..//test.bin";
            Implementation1 fi = new Implementation1();
            fi.CreateTestData();
            Console.WriteLine("------------------------------------------\n");
            Console.WriteLine("Kolekcijas pirms saglabāšanas failā: \n");
            Console.WriteLine("------------------------------------------\n");
            Console.WriteLine(fi.Print());   //atgriežam kā tekstu informāciju par visiem kolekcijās esošajiem elementiem.
            fi.Save(FileName);  //saglabāt visas kolekciju datus failā 
            Console.WriteLine("------------------------------------------\n");
            Console.WriteLine("Kolekcijas pēc saglabāšanas failā (Pec RESET metodes): \n");
            Console.WriteLine("------------------------------------------\n");
            fi.Reset();  //padaram kolekcijas tukšas
            fi.Load(FileName); //nolasam visu kolekciju datus no faila
            Console.WriteLine("------------------------------------------\n");
            Console.WriteLine("Kolekcijas pēc ielādēšanas no faila: \n");
            Console.WriteLine("------------------------------------------\n");
            Console.WriteLine(fi.Print());
        }
    }
}
