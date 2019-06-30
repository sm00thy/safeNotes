using System;
using System.Collections.Generic;

namespace SafeNotes.Models
{
    public class User : BaseEntity
    {
        public string Login { get; set; }
        public string Password { get; set; }

        public User()
        { }

        public User(string login, string password)
        {
            Login = login;
            Password = password;
        }

    }
}
