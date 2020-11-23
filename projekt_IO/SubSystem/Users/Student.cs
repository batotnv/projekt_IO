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


        public Student(string firstname, string lastname, string email, string password, string fieldofstudy, string faculty)
        {
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


    }
}
