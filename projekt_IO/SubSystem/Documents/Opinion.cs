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

        private IValidator _validator;

        public Opinion(IValidator validator)
        {
            this._validator = validator;
        }

        public Opinion(string text, UniversityEmployee author, Thesis thesis, double mark)
        {


            if (IsOpinionCorrect(text, mark) == false)
                throw new ArgumentException("Please create opinion again with proper parameter");
            else
            {
                Text = text;
                Author = author;
                Thesis = thesis;
                Mark = mark;

            }
        }

        public bool IsOpinionCorrect(string text, double mark)
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
