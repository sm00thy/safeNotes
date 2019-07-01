using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SafeNotes.Models;
using SQLite;

namespace NotesManagerLib.DataModels
{
    public class NoteDb : DbContext
    {
        private readonly SQLiteAsyncConnection db;

        public NoteDb(string dbPath)
        {
            db = new SQLiteAsyncConnection(dbPath);
            db.CreateTableAsync<Note>().Wait();
            db.CreateTableAsync<User>().Wait();
        }

        public async Task<List<Note>> GetNotes(Guid userId)
            => await db.Table<Note>().Where(x => x.UserId == userId)
            .ToListAsync();

        public async Task<List<T>> GetAll<T>() where T : class, new ()
            => await db.Table<T>().ToListAsync();

        public async Task<T> GetByID<T>(Guid id) where T : BaseEntity, new ()
            => await db.Table<T>().Where(t => t.Id == id).FirstOrDefaultAsync();

        public async Task<User> GetByLogin(string login)
            => await db.Table<User>().Where(x => x.Login == login).FirstOrDefaultAsync();

        public async Task<int> SaveItem<T>(T item) where T : BaseEntity
        {
            await Task.Delay(2000);
            var result = await db.UpdateAsync(item);

            if (result == 0)
                result = await db.InsertAsync(item);

            return result;
        }

        public async Task<int> DeleteItem<T>(T item) where T : BaseEntity
            =>  await db.DeleteAsync(item);

    }
}