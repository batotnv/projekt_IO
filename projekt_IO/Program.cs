using projekt_IO.SubSystem.Documents;
using projekt_IO.SubSystem.Users;
using System;

namespace projekt_IO
{
    class Program
    {
        static void Main(string[] args)
        {
            //Podsystem składania pracy dyplomowej 
            //Symulacja działania wzorca OBSERWATOR

            Student student1 = new Student("Fifi", "Chełmikowska", "fifiq@student.agh.edu.pl", "fifi123", "Informatyka i Ekonometria", "WZ");
            UniversityEmployee emp1 = new UniversityEmployee("Pan", "Paweł", "ppawel@student.agh.edu.pl", "123", "dr hab", "WZ");

            Thesis praca1 = new Thesis("Analiza krajow UE", student1);

            praca1.RegisterForNotification(student1);
            Console.WriteLine("Fifi dostaje od teraz notyfikacje o pracy dyplomowej 1");
            Console.ReadKey();

            Console.WriteLine("==============");

            praca1.RegisterForNotification(emp1);
            Console.WriteLine("Pan Pawel dostaje od teraz notyfikacje o pracy dyplomowej 1");
            Console.ReadKey();

            Console.WriteLine("==============");
            praca1.Upload();
            Console.ReadKey();

            Console.WriteLine("==============");
            praca1.Modify();
            Console.ReadKey();



        }
    }
}
