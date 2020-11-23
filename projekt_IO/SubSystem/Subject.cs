using System;
using System.Collections.Generic;
using System.Text;

namespace projekt_IO.SubSystem
{
    public abstract class Subject
    {
        protected List<IObserver> _observerList = new List<IObserver>();

        // dodanie nowego obserwatora
        public void Attach(IObserver observer)
        {
            if (!this._observerList.Contains(observer))
                this._observerList.Add(observer);
        }

        // usuniecie danego obserwatora
        public void Detach(IObserver observer)
        {
            if (this._observerList.Contains(observer))
                this._observerList.Remove(observer);
        }

        // powiadamianie obserwatorów o zmianie danych w obserwowanycn podmiocie (Thesis)
        // implementacja powiadomenia znajduje się w klasie pochodnej Thesis
        abstract protected void Notify();
    }
}
