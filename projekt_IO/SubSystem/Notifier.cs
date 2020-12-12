using projekt_IO.SubSystem.Documents;
using projekt_IO.SubSystem.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace projekt_IO.SubSystem
{
    public class Notifier : IObserver
    {
        public User AttachedUser { get; protected set; }

        public Notifier(User user)
        {
            AttachedUser = user;
        }

        public void Update(Thesis thesis)
        {
            // pobieranie danych z obserwowanego podmiotu
            // każdy obserwator może pobrać tylko te dane, które go interesują
            Student author = thesis.Author;
            string title = thesis.Title;
            ThesisStatus status = thesis.Status;

            //tresc powiadomienia
            Console.WriteLine("-------------");
            Console.WriteLine("Powiadomienie dla użytkownika: {0} {1}", AttachedUser.FirstName, AttachedUser.LastName);
            Console.WriteLine("Praca dyplomowa: {0} autorstwa: {1} {2} posiada status: {3}", title, author.FirstName, author.LastName, status);
            Console.WriteLine("-------------");
        }
    }
}
