﻿using System;
using System.Collections.Generic;
using System.Text;

namespace projekt_IO.SubSystem.Users
{
    public abstract class User
    {
        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }
        public string Email { get; protected set; }
        public string Password { get; protected set; }

        
    }
}
