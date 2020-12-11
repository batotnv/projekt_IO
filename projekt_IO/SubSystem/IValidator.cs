using System;
using System.Collections.Generic;
using System.Text;

//interface zeby bylo mozliwe testowanie przy pomocy moq

namespace projekt_IO.SubSystem
{
    public interface IValidator
    {
        bool IsCorrectMark(double mark);

    }
}
