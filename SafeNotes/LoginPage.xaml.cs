using System;
using SafeNotes.Models;
using Xamarin.Forms;

namespace SafeNotes
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();

        }

        async void Register_Btn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegistrationPage());
        }

        async void Submit_Btn_Clicked(object sender, EventArgs e)
        {
            var login = loginEntry?.Text;
            var password = passwordEntry?.Text;
            var user = await App.Database.GetByLogin(login);
            bool checkIfEmpty, checkLogin;
            Validation(login, password, user,
                out checkIfEmpty, out checkLogin);

            if (!checkIfEmpty && checkLogin)
                await Navigation.PushAsync(new DashboardPage());
            else
                await DisplayAlert("Error", "Wrong username or password", "Back");
        }

        public static void Validation(string login, string password, User user,
            out bool checkIfEmpty, out bool checkLogin)
        {
            checkIfEmpty = string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password);
            checkLogin = (login == user.Login) && (password == user.Password);
        }
    }
}
