using projekt_IO.SubSystem.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace projekt_IO.SubSystem.Documents
{
    public class Opinion
    {
        public string Text { get; protected set; }
        public UniversityEmployee Author { get; protected set; }
        public Thesis Thesis { get; protected set; }
        public int Mark { get; protected set; }


        public Opinion(string text, UniversityEmployee author, Thesis thesis, int mark)
        {
            Text = text;
            Author = author;
            Thesis = thesis;
            Mark = mark;
        }
    }
}
