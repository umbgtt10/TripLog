using System;
using System.Collections.Generic;
using System.ComponentModel;
using TripLog.Models;
using TripLog.ViewModels;
using TripLog.Views;
using Xamarin.Forms;

namespace TripLog
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        private ViewModelBase Vm
        {
            get
            {
                return (ViewModelBase)BindingContext;
            }
        }

        public MainPage()
        {
            InitializeComponent();
        }

        public void SetViewModel(ViewModelBase vm)
        {
            BindingContext = vm;
        }

        protected override void OnAppearing()
        {
            Vm.Init();
        }
    }
}
