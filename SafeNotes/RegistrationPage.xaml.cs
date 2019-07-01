using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SafeNotes.Models;
using Xamarin.Forms;

namespace SafeNotes
{
    public partial class RegistrationPage : ContentPage
    {
        public RegistrationPage()
        {
            InitializeComponent();
        }

        async void Btn_Clicked(object sender, EventArgs e)
        {
            var login = loginEntry?.Text;
            var password = passwordEntry?.Text;
            var reenteredPass = reEnterPassword?.Text;
            bool passed = await ValidationCheck(login, password, reenteredPass);

            if (passed)
            {
                var user = new User(login, password);
                await App.Database.SaveItem(user);
                await DisplayAlert("Registration successful!", "You're signed up!", "Ok");
                await Navigation.PopAsync();
            }
        }

        private async Task<bool> ValidationCheck(string login, string password,
            string reenteredPass)
        {
            var user = await App.Database.GetByLogin(login);

            if (user != null)
            {
                await DisplayAlert("Error", "User with typed username exist", "Back");
                return false;
            }
            if (string.IsNullOrEmpty(login) || login.Length < 2)
            {
                await DisplayAlert("Error", "Login cannot be empty or it's too short!", "Back");
                return false;
            }
            if (password.Length < 5)
            {
                await DisplayAlert("Error", "Password needs to be stronger - min 5 digits/letters", "Ok");
                return false;
            }
            if(!reenteredPass.Equals(password))
            {
                await DisplayAlert("Error", "Passwords are not the same!", "Back");
                return false;
            }
                return true;
        }


    }
}
