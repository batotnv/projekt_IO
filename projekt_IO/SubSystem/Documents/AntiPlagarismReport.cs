using System;
using System.Collections.Generic;
using System.Text;

namespace projekt_IO.SubSystem.Documents
{
    public class AntiPlagarismReport
    {
        public string Text { get; protected set; }

        public AntiPlagarismReport(string text)
        {
            this.Text = text;
        }

    }
}
