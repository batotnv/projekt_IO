using projekt_IO.SubSystem.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace projekt_IO.SubSystem.Documents
{
    public class Review
    {
        public string Text { get; protected set; }
        public UniversityEmployee Author { get; protected set; }
        public Thesis Thesis { get; protected set; }
        public double Mark { get; protected set; }

        private IValidator _validator;

        public Review(IValidator validator)
        {
            this._validator = validator;
        }


        public Review(string text, UniversityEmployee author, Thesis thesis, double mark)
        {

            if (IsReviewCorrect(text, mark) == false)
                throw new ArgumentException("Please create review again with proper parameter");
            else
            {
                Text = text;
                Author = author;
                Thesis = thesis;
                Mark = mark;
                
            }
        }

        public bool IsReviewCorrect(string text, double mark)
        {
            IValidator validator = new MarkValidator();
            bool isCorrect = validator.IsCorrectMark(mark);

            //przy testowaniu za pomoca Moqa
            //bool isCorrect = this._validator.IsCorrectMark(mark);

            if (text == null || isCorrect == false)
                return false;
            else
                return true;
        }

    }


  


    


}
