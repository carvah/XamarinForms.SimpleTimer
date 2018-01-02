﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleTimer.ViewModel;
using SimpleTimer.Views;
using Xamarin.Forms;

namespace SimpleTimer
{
    public partial class App : Application
    {
        private static ViewModelLocator _locator;
        public static ViewModelLocator Locator => _locator ?? (_locator = new ViewModelLocator());

        public App()
        {
            MainPage = GetMainPage();
        }

        public static NavigationPage GetMainPage()
        {            
            return new NavigationPage(new MainPage())
            {
                //Change bar colorPrimary
                BarBackgroundColor = Color.FromHex("#0282A5"),
                //Change color on bar
                BarTextColor = Color.White
            };

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
