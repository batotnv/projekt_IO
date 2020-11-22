using projekt_IO.SubSystem.Documents;
using System;
using System.Collections.Generic;
using System.Text;

namespace projekt_IO.SubSystem
{
    public interface IObserver
    {
        void Update(Thesis thesis);
    }
}
