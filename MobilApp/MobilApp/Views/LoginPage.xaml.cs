using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobilApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        private string _pass;
        public LoginPage()
        {
            InitializeComponent();
            _pass = Preferences.Get("Password", String.Empty);
            if (_pass != string.Empty)
            {
                lPin.Text = "Пин-код для входа:";
            }
        }

        private void ButtonPwd_Click(object sender, EventArgs e)
        {
            string enterPwd = Password.Text;
            if (_pass == string.Empty)
            {
                Preferences.Set("Password", enterPwd);
            }
            else
            {
                if (_pass != Password.Text)
                {
                    MsgInfo.Text = "Неверный ПИН-код";
                    return;
                }
            }

            Navigation.PushAsync(new GalleryPage());
        }

        private void Password_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Password.Text.Length != 4)
            {
                MsgInfo.Text = "ПИН-код должен состоять из 4 символов";
                ButtonPwd.IsEnabled = false;
            }
            else
            {
                ButtonPwd.IsEnabled = true;
                MsgInfo.Text = string.Empty;
            }
        }
    }
}