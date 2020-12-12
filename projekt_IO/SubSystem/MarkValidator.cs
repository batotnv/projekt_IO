using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace projekt_IO.SubSystem
{
    public class MarkValidator : IValidator
    {
        public bool IsCorrectMark(double mark)
        {
            double[] marks = { 2, 2.5, 3, 3.5, 4, 4.5, 5 };
            if (!marks.Contains(mark))
                return false;
            else
                return true;
        }
    }
}
