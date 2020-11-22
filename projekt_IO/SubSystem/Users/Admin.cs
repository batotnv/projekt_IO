using System;
using System.Collections.Generic;
using System.Text;

namespace projekt_IO.SubSystem.Users
{
    public class Admin : User
    {

        public Admin(string firstname, string lastname, string email, string password)
        {
            FirstName = firstname;
            LastName = lastname;
            Email = email;
            Password = password;
        }
    }
}
