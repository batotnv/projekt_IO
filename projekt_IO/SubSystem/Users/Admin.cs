using System;
using System.Collections.Generic;
using System.Text;

namespace projekt_IO.SubSystem.Users
{
    public class Admin : User
    {

        public Admin(string firstname, string lastname, string email, string password)
        {
            if (firstname == null)
                throw new ArgumentNullException("First Name cannot be null");

            if (lastname == null)
                throw new ArgumentNullException("Last Name cannot be null");

            if (email == null || !(email.ToLower().Contains('@')))
                throw new ArgumentNullException("Email cannot be null/Email has wrong format ");

            if (password == null)
                throw new ArgumentNullException("Password cannot be null");

            FirstName = firstname;
            LastName = lastname;
            Email = email;
            Password = password;
        }
      
    }
}
