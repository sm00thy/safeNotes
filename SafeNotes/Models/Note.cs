﻿using System;

namespace SafeNotes.Models
{
    public class Note : BaseEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime DateTime { get { return DateTime.Now; } } 
        public Guid UserId { get; set; }

        public Note() { }

        public Note(string title, string content, Guid userId)
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
