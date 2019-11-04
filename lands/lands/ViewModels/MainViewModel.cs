using System;
using System.Collections.Generic;
using System.Text;

namespace lands.ViewModels
{
    public class MainViewModel
    {
        #region viewModels

        public LogingViewModel Login { get; set; }

        public LandsViewModel Lands { get; set; }

        #endregion

        #region Constructor

        public MainViewModel()
        {
            instance = this;
            this.Login = new LogingViewModel();
        }

        #endregion

        #region singleton

        private static MainViewModel instance;


        public static MainViewModel GetInstance()
        {
            if (instance == null)
            {
                return new MainViewModel();
            }
            return instance;
        }
        #endregion
    }
}
