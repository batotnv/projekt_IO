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
            //Symulacja działania wzorca OBSERWATOR - metoda pull

            //studenci
            Student student1 = new Student("Fifi", "Chełmikowska", "fifiq@student.agh.edu.pl", "fifi123", "Informatyka i Ekonometria", "WZ");
            Student student2 = new Student("Janina", "Bobrowska", "bobrowska@student.agh.edu.pl", "agh", "Zarzadzanie", "WZ");
            //Student student3 = new Student("Andrzej", "Mrozny", "amrozny@student.agh.edu.pl", "abc", "ZIP", "WZ");

            //pracownicy uczelni
            UniversityEmployee emp1 = new UniversityEmployee("Pan", "Paweł", "ppawel@agh.edu.pl", "123", "dr hab", "WZ");
            UniversityEmployee emp2 = new UniversityEmployee("Pan", "Tomek", "ptomek@agh.edu.pl", "456", "prof", "WZ");
            //UniversityEmployee emp3 = new UniversityEmployee("Pan", "Henryk", "phenryk@student.agh.edu.pl", "xyz", "prof", "WZ");


            //przydzielenie promotorow
            emp1.AddSupervisedStudent(student1);
            emp2.AddSupervisedStudent(student2);
            //emp3.AddSupervisedStudent(student3);

            //przydzielenie recenzentow
            emp1.AddReviewedStudent(student2);
            emp2.AddReviewedStudent(student1);
            //emp3.AddReviewedStudent(student2);

            //prace dyplomowe
            Thesis praca1 = new Thesis("Analiza krajow UE", student1);
            Thesis praca2 = new Thesis("Porownanie metod analizy skupien", student2);
            //Thesis praca3 = new Thesis("Regresje swiata", student3);

            //rejestracja na notyfikacje
            praca1.RegisterForNotification(student1);
            praca1.RegisterForNotification(emp1);
            praca1.RegisterForNotification(emp2);

            praca2.RegisterForNotification(student2);
            praca2.RegisterForNotification(emp2);
            praca2.RegisterForNotification(emp1);
            Console.ReadKey();


            Console.WriteLine("==============");
            praca1.Upload(student1);
            Console.WriteLine("==============");
            praca2.Upload(student2);
            Console.ReadKey();

            Console.WriteLine("==============");
            praca2.UnregisterForNotification(student2);
            praca2.UnregisterForNotification(emp1);
            praca2.UnregisterForNotification(emp2);

            Console.ReadKey();

            Console.WriteLine("==============");
            praca1.Modify(student1);
            praca2.Modify(student2);

            praca1.ToImprove();
            praca2.ToImprove();
            praca1.SendToAntiPlagarism();
            

            Opinion op1 = new Opinion("Super praca", emp1, praca1, 5);
            Review r1 = new Review("Fajna praca", emp2, praca1, 5);
            
            AntiPlagarismReport anti1 = new AntiPlagarismReport("Wynik: 80%");

            praca1.AddAntiPlagarismReport(anti1);
            praca1.AddOpinion(op1);
            praca1.AddReview(r1);
            praca1.CalculateMark();
            Console.ReadKey();



        }
    }
}
