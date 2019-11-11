namespace lands.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Text;
    using System.Windows.Input;
    using GalaSoft.MvvmLight.Command;
    using Models;
    using Services;
    using Xamarin.Forms;

    public class LandsViewModel : BaseViewModel
    {

        #region Service

        ApiService apiService;
        string titulo;

        #endregion

        #region Atributes
        private ObservableCollection<Land> lands;
        private bool isRefreshing;
        #endregion

        #region Properties

        public ObservableCollection<Land> Lands
        {
            get { return this.lands; }
            set { SetValue(ref this.lands, value); }
        }

        public bool IsRefreshing
        {
            get { return this.isRefreshing; }
            set { SetValue(ref this.isRefreshing, value); }
        }

        public string Titulo
        {
            get
            {
                return titulo;
            }
            set
            {
                SetValue(ref titulo, value);
            }
        }

        #endregion

        #region Constructor

        public LandsViewModel()
        {
            this.apiService = new ApiService();
            this.LoadLoands();

        }

        #endregion

        #region Method
        private async void LoadLoands()
        {
            IsRefreshing = true;
            var conexion = await this.apiService.CheckConnection();

            if (!conexion.IsSuccess)
            {
                this.IsRefreshing = false;
                await Application.Current.MainPage.DisplayAlert("Error",conexion.Message,"Accept");
                await Application.Current.MainPage.Navigation.PopAsync();
            }

            var response = await this.apiService.GetList<Land>(
                "http://restcountries.eu",
                "/rest", "/v2/all");
            if(!response.IsSuccess)
            {
                this.IsRefreshing = false;
                await Application.Current.MainPage.DisplayAlert("Error", conexion.Message, "Accept");
                await Application.Current.MainPage.Navigation.PopAsync();
            }
            var list = (List<Land>)response.Result;
            this.Lands = new ObservableCollection<Land>(list);
            this.IsRefreshing = false;
        }

        #endregion

        #region Comand
        public ICommand RefreshCommand
        {
            get
            {
                return new RelayCommand(LoadLoands);
            }
        }

        #endregion

    }
}                  