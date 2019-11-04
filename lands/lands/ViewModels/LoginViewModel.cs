

namespace lands.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Windows.Input;
    using Xamarin.Forms;
    using System.ComponentModel;
    using Views;

    public class LogingViewModel : BaseViewModel
    {


        #region Atributos

        private string email;
        private string password;
        private bool isRunning;
        private bool isEnable;
        private bool isRemembered;


        #endregion

        #region Properties

        public string Email
        {
            get { return email; }
            set { SetValue(ref email, value); }
        }
        public string Password
        {
            get { return password; }
            set { SetValue(ref password, value); }
        }

        public bool IsRunning
        {
            get { return isRunning; }
            set { SetValue(ref isRunning, value); }
        }

        public bool IsRemembered
        {
            get { return isRemembered; }
            set { SetValue(ref isRemembered, value); }
        }

        public bool IsEnable
        {
            get { return isEnable; }
            set { SetValue(ref isEnable, value); }
        }
        #endregion

        #region Constructor

        public LogingViewModel()
        {
            this.IsRunning = false;
            this.IsRemembered = true;
            this.IsEnable = true;
        }

        #endregion


        #region Comands

        public ICommand LoginComand
        {
            get
            {
                return new RelayCommand(Login);
            }

        }
        public ICommand RegisterComand
        {
            get;
            set;
        }


        #endregion

        #region Method

        private async void Login()
        {
            this.IsEnable = false;
            this.IsRunning = true;
            if (string.IsNullOrEmpty(this.Email))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "You Must enter your Email",
                    "Ok"
                    );
                this.IsEnable = true;
                this.IsRunning = false;
                return;
            }
            if (string.IsNullOrEmpty(this.Password))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "You Must enter your Password",
                    "Ok"
                    );
                this.IsEnable = true;
                this.IsRunning = false;
                return;
            }
            if (this.Email != "asdf" || this.Password != "1234")
            {
                await Application.Current.MainPage.DisplayAlert(
                "Error",
                "Todo mal",
                "Ok"
                );
                this.IsEnable = true;
                this.IsRunning = false;
                this.Password = string.Empty;
                this.Email = string.Empty;
                return;
            }
            this.IsEnable = true;
            this.IsRunning = false;
            this.Password = string.Empty;
            this.Email = string.Empty;

            MainViewModel.GetInstance().Lands = new LandsViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new LandsPage());
        }

        #endregion
    }
}
