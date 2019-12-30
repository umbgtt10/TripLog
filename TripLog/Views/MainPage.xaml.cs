﻿using System.ComponentModel;
using System.Threading.Tasks;
using TripLog.ViewModels;
using Xamarin.Forms;

namespace TripLog.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        public void SetViewModel(MainPageViewModel vm)
        {
            BindingContext = vm;
        }

        protected override void OnAppearing()
        {
            var task = ((MainPageViewModel)BindingContext).Init();

            Task.WaitAll(task);
        }
    }
}
