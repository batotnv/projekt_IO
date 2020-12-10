using projekt_IO.SubSystem.Documents;
using System;
using System.Collections.Generic;
using System.Text;

namespace projekt_IO.SubSystem.Users
{
    public class UniversityEmployee : User
    {
        public string AcademicTitle { get;  protected set; }
        public string Faculty { get; protected set; }

        public List<Student> SupervisorOf = new List<Student>();
        public List<Student> ReviewerOf = new List<Student>();

        

        public UniversityEmployee(string firstname, string lastname, string email, string password, string academictitle, string faculty)
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
            AcademicTitle = academictitle;
            Faculty = faculty;

        }

        public void AddSupervisedStudent(Student student)
        {
            student.AddSupervisor(this);
            this.SupervisorOf.Add(student); 
        }

        public void AddReviewedStudent(Student student)
        {
            student.AddReviewer(this);
            this.ReviewerOf.Add(student);
        }

        public void RemoveSupervisedStudent(Student student)
        {
            this.SupervisorOf.Remove(student);
        }

        public void RemoveReviewedStudent(Student student)
        {
            this.ReviewerOf.Remove(student);
        }
        

    }
}
