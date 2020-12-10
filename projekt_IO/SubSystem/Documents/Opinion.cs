using projekt_IO.SubSystem.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace projekt_IO.SubSystem.Documents
{
    public class Opinion
    {
        public string Text { get; protected set; }
        public UniversityEmployee Author { get; protected set; }
        public Thesis Thesis { get; protected set; }
        public double Mark { get; protected set; }


        public Opinion(string text, UniversityEmployee author, Thesis thesis, double mark)
        {
            if (text == null)
                throw new ArgumentNullException("Text cannot be null");

            if (mark == null)
                throw new ArgumentNullException("Mark cannot be null");

            double[] marks = { 2, 2.5, 3, 3.5, 4, 4.5, 5 };

            if (!marks.Contains(mark))
                throw new ArgumentException("Mark is not correct");

            Text = text;
            Author = author;
            Thesis = thesis;
            Mark = mark;
        }
    }
}
