using MagicAccount.Pages;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MagicAccount
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new MainPage();
            MainPage = new LoginPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
