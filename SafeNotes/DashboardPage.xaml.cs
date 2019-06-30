using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using SafeNotes.Models;
using Xamarin.Forms;

namespace SafeNotes
{
    public partial class DashboardPage : ContentPage
    {
        public ObservableCollection<Note> Notes { get; set; }

        public DashboardPage()
        {
            InitializeComponent();
            Notes = new ObservableCollection<Note>();
            var note = new Note("test", "test");
            Notes.Add(note);
            NotesList.ItemsSource = Notes;
        }

        void Add_Btn_Clicked(object sender, System.EventArgs e)
        {
            Notes.Add(new Note("Test", "Testowa"));
        }

        void Delete_Btn_Clicked(object sender, System.EventArgs e)
        {
            Notes.Remove(Notes.LastOrDefault());
        }

        void MenuItem_Delete(object sender, System.EventArgs e)
        {
            var menuItem = sender as MenuItem;
            Notes.Remove((Note)menuItem.CommandParameter);
        }
    }
}
