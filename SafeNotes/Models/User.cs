using System;
using System.Collections.Generic;
using SafeNotes.Models;
using SQLite;

namespace SafeNotes.DataModels
{
    public class User : BaseEntity
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public List<Note> Notes { get; set; }

        public User()
        { }

        public User(string login, string password)
        {
            Login = login;
            Password = password;
        }

    }
}
