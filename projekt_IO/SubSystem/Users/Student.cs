using projekt_IO.SubSystem.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace projekt_IO.SubSystem.Users
{
    public class Student : User
    {
        public string FieldOfStudy { get; protected set; }
        public string Faculty { get; protected set; }

        public UniversityEmployee Supervisor { get; protected set; }
        public UniversityEmployee Reviewer { get; protected set; }
        
        public string StudiesResult { get; protected set; }


        public Student(string firstname, string lastname, string email, string password, string fieldofstudy, string faculty)
        {
            if (firstname == null)
                throw new ArgumentNullException("First Name cannot be null");

            if (lastname == null)
                throw new ArgumentNullException("Last Name cannot be null");

            if(email == null || !(email.ToLower().Contains('@')))
                throw new ArgumentException("Email cannot be null/Email has wrong format ");

            if (password == null)
                throw new ArgumentNullException("Password cannot be null");

            FirstName = firstname;
            LastName = lastname;
            Email = email;
            Password = password;
            FieldOfStudy = fieldofstudy;
            Faculty = faculty;
        }

        public void AddSupervisor(UniversityEmployee universityEmployee)
        {
            this.Supervisor = universityEmployee;
        }

        public void AddReviewer(UniversityEmployee universityEmployee)
        {
            this.Reviewer = universityEmployee;
        }

        public void RemoveSupervisor()
        {
            this.Supervisor = null;
        }

        public void RemoveReviewer()
        {
            this.Reviewer = null;
        }

        public void GetStudiesResult(double ThesisMark)
        {
            switch (ThesisMark)
            {
                case 2:
                    this.StudiesResult = "Niezaliczone";
                    break;
                case 2.5:
                    this.StudiesResult = "Niezaliczone";
                    break;
                case 3:
                    this.StudiesResult = "Dostateczny";
                    break;
                case 3.5:
                    this.StudiesResult = "Dostateczny plus";
                    break;
                case 4:
                    this.StudiesResult = "Dobry";
                    break;
                case 4.5:
                    this.StudiesResult = "Dobry plus";
                    break;
                case 5:
                    this.StudiesResult = "Bardzo dobry";
                    break;
                default:
                    this.StudiesResult = "Brak oceny";
                    break;
            }

        }


    }
}
