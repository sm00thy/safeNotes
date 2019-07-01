using SafeNotes.Models;
using Xamarin.Forms;

namespace SafeNotes
{
    public partial class NotePage : ContentPage
    {
        private Note _note { get; set; }

        public NotePage()
        {
            InitializeComponent();
            updateBtn.IsVisible = false;
        }

        public NotePage(Note note)
        {
            InitializeComponent();
            updateBtn.IsVisible = true;
            _note = note;
            Title.Text = _note.Title;
            Description.Text = _note.Content;
        }

        private async void Add_Btn_Clicked(object sender, System.EventArgs e)
        {
            var note = new Note(Title.Text, Description.Text);
            await DisplayAlert("Saved!", "Your note has been saved!", "Ok");
            await App.Database.SaveItem(note);
            await Navigation.PopAsync();
        }

        private async void Update_Btn_Clicked(object sender, System.EventArgs e)
        {
            _note.Title = Title.Text;
            _note.Content = Description.Text;
            await DisplayAlert("Updated!", "Your note has been updated!", "Ok");
            await App.Database.SaveItem(_note);
            await Navigation.PopAsync();
        }
    }
}
