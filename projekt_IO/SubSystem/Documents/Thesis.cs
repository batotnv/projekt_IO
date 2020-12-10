using projekt_IO.SubSystem.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace projekt_IO.SubSystem.Documents
{
    public class Thesis : Subject
    {
        public string Title { get; protected set; }
        public Student Author { get; protected set; }
        private ThesisStatus _status;
        public Review Review { get; protected set; }
        public Opinion Opinion { get; protected set; }
        public AntiPlagarismReport AntiPlagarismReport { get; protected set; }
        public double Mark { get; protected set; }
        public List<Notifier> Notifiers = new List<Notifier>();


        public Thesis(string title, Student student)
        {
            if (title == null)
                throw new ArgumentNullException("Title cannot be null");

            Title = title;
            Author = student;
            Status = ThesisStatus.NotUploaded;

        }

        public ThesisStatus Status
        {
            get { return this._status; }
            set
            {
                this._status = value;
                    Notify();
            }
        }

        protected override void Notify()
        {
            foreach (IObserver observer in this._observerList)
            {
                // Wersja "PULL"
                // Obserwowany podmiot (Thesis) wywołuje metodę Update() na rzecz każdego obserwatora.
                // Obserwatorzy pobierają samodzielnie interesujące ich dane z obserwowanego podmiotu.
                observer.Update(this);
             
            }
        }

     
        //rejestracja notifiera
        public void RegisterForNotification(User user)
        {
            Notifier notifier = new Notifier(user);
            this.Notifiers.Add(notifier);
            this.Attach(notifier);

            Console.WriteLine("{0} {1} dostaje od teraz notyfikacje o pracy dyplomowej {2}", user.FirstName, user.LastName, this.Title);

        }

        //wyrejestrowanie sie z otrzymywania powiadomien

        public void UnregisterForNotification(User user)
        {

            List<Notifier> NotifiersToRemove = new List<Notifier>();

            foreach (Notifier notifier in Notifiers)
            {
                if (notifier.AttachedUser == user)
                {
                    NotifiersToRemove.Add(notifier);
                    this.Detach(notifier);
                }
            }

            if (NotifiersToRemove.Any())
            {
                Notifiers.RemoveAll(item => NotifiersToRemove.Contains(item));
                Console.WriteLine("{0} {1} juz nie dostaje od teraz notyfikacji o pracy dyplomowej {2}", user.FirstName, user.LastName, this.Title);
            }
            else
                Console.WriteLine("Uzytkownika {0} {1} nie ma na liscie osob otrzymujacych powiadomienia o pracy dyplomowej {2}", user.FirstName, user.LastName, this.Title);
        }

        //metody, ktore zmieniaja stan pracy dyplomowej
        public void Upload(Student student)
        {
            if (student == this.Author)
            {
                Console.WriteLine("Pierwsze wrzucenie pracy do systemu!");
                this.Status = ThesisStatus.UploadedByStudent;
            }
            else
                Console.WriteLine("Brak uprawnien");
            
        }

        public void Modify(Student student)
        {
            if (student == this.Author)
            {
                Console.WriteLine("Modyfikacja pracy dyplomowej!");
                this.Status = ThesisStatus.ModifiedByStudent;
            }
            else
                Console.WriteLine("Brak uprawnien");
        }

        public void ToImprove()
        {
            Console.WriteLine("Praca do poprawy!");
            this.Status = ThesisStatus.ToImprove;
        }

        public void AddReview(Review review)
        {
            Console.WriteLine("Dodano recenzje!");
            this.Review = review;
            this.Status = ThesisStatus.ReviewedByReviewer;
        }

        public void AddOpinion(Opinion opinion)
        {
            Console.WriteLine("Dodano opinie!");
            this.Opinion = opinion;
            this.Status = ThesisStatus.ConfirmedBySupervisor;
        }

        public void SendToAntiPlagarism()
        {
            Console.WriteLine("Wyslano do systemu antyplagiatowego!");
            this.Status = ThesisStatus.UnderAntiPlagarismSystem;
        }

        public void AddAntiPlagarismReport(AntiPlagarismReport antiPlagarismReport)
        {
            Console.WriteLine("Dodano raport antyplagiatowy!");
            this.AntiPlagarismReport = antiPlagarismReport;
            this.Status = ThesisStatus.WaitingForSupervisorAcceptance;
        }

        public void CalculateMark()
        {
            this.Mark = (Review.Mark + Opinion.Mark) / 2;
            
            Console.WriteLine("####################");
            Console.WriteLine("Praca dyplomowa ukonczona sukcesem!");
            Console.WriteLine("Ocena pracy: {0}", this.Mark);
            this.Status = ThesisStatus.Finished;

            this.Author.GetStudiesResult(this.Mark);
        }



    }

   
}
