using projekt_IO.SubSystem.Users;
using System;
using System.Collections.Generic;
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
        public int Mark { get; protected set; }

        public Thesis(string title, Student student)
        {
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
                // Obserwowany podmiot (Book) wywołuje metodę Update() na rzecz każdego obserwatora.
                // Obserwatorzy pobierają samodzielnie interesujące ich dane z obserwowanego podmiotu.
                observer.Update(this);


                // Wersja "PUSH"
                // Obserwowany podmiot (Book) wywołuje metodę Update() na rzecz każdego obserwatora,
                // przekazując potencjalnie interesujące dane.
                // Obserwatorzy w tym przypadku dostają gotowe dane.
                //observer.Update(this._director, this._title, this._status);
            }
        }

        public void AddReview(Review review)
        {
            this.Review = review;
        }

        public void AddOpinion(Opinion opinion)
        {
            this.Opinion = opinion;
        }

        public void CalculateMark()
        {
            this.Mark = (Review.Mark + Opinion.Mark) / 2;
        }


        public void RegisterForNotification(User user)
        {
            Notifier notifier = new Notifier(user);
            this.Attach(notifier);

        }

        public void UnregisterForNotification(User user)
        {
           //

        }



        public void Upload()
        {
            Console.WriteLine("Pierwsze wrzucenie pracy do systemu!");
            this.Status = ThesisStatus.UploadedByStudent;
        }

        public void Modify()
        {
            Console.WriteLine("Modyfikacja pracy dyplomowej!");
            this.Status = ThesisStatus.ModifiedByStudent;
        }

    }

   
}
