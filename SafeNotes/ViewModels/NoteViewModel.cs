using SafeNotes.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace NotesManagerLib.ViewModel
{
    public abstract class NoteViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        //readonly NoteDb noteDb = new NoteDb();

        //public NoteViewModel(int userId)
        //{
        //    AppDomain.CurrentDomain.SetData("DataDirectory",
        //        Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData));
        //    Notes = noteDb.Notes.Where(x => x.UserId == userId).ToList();
        //}

        public IList<Note> Notes { get; set; }

    }
}
