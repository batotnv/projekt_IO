using System;
using System.Collections.Generic;
using System.Text;

namespace projekt_IO.SubSystem.Documents
{
    public class AntiPlagarismReport
    {
        public string Text { get; protected set; }
        public int Result { get; protected set; }

        public AntiPlagarismReport(string text, int result)
        {
            if (text == null)
                throw new ArgumentNullException("Text cannot be null");
            if (IsResultCorrect(result) == false)
                throw new ArgumentException("Result incorrect");

            this.Text = text;
            this.Result = result;
        }

        public bool IsResultCorrect(int result)
        {
            if (result > 100 || result < 0)
                return false;
            else
                return true;
        }
    }
}
