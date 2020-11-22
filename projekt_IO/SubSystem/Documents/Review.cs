using projekt_IO.SubSystem.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace projekt_IO.SubSystem.Documents
{
    public class Review
    {
        public string Text { get; protected set; }
        public UniversityEmployee Author { get; protected set; }
        public Thesis Thesis { get; protected set; }
        public int Mark { get; protected set; }


        public Review(string text, UniversityEmployee author, Thesis thesis, int mark)
        {
            Text = text;
            Author = author;
            Thesis = thesis;
            Mark = mark;
        }

    }


    

}
