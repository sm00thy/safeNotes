using System;
using SQLite;

namespace SafeNotes.Models
{
    public class BaseEntity
    {
        [PrimaryKey]
        public Guid Id { get; set; }

        public BaseEntity()
        {
            Id = Guid.NewGuid();
        }
    }
}
