using System;
using SafeNotes.Models;

namespace SafeNotes.DataModels
{
    public class Note : BaseEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime DateTime { get { return DateTime.Now; } } 
        public int UserId { get; set; }

        public Note() { }

        public Note(string title, string content, int userId)
        {
            Title = title;
            Content = content;
            UserId = userId;
        }

        public Note(string title, string content)
        {
            Title = title;
            Content = content;
        }

        public override string ToString()
        {
            return Title + Content;
        }

    }
}
