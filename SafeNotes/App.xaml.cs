using System;
using System.IO;
using NotesManagerLib.DataModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SafeNotes
{
    public partial class App : Application
    {
        private static NoteDb _database;

        public static NoteDb Database
        {
            get
            {
                if (_database == null)
                {
                    _database = new NoteDb(
                      Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "NoteSQLite.db3"));
                }
                return _database;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new LoginPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
