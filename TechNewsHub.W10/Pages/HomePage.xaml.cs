//---------------------------------------------------------------------------
//
// <copyright file="HomePage.xaml.cs" company="Microsoft">
//    Copyright (C) 2015 by Microsoft Corporation.  All rights reserved.
// </copyright>
//
// <createdOn>5/11/2016 6:40:33 AM</createdOn>
//
//---------------------------------------------------------------------------

using AppStudio.Uwp;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using TechNewsHub.ViewModels;

namespace TechNewsHub.Pages
{
    public sealed partial class HomePage : Page
    {
        public HomePage()
        {
            ViewModel = new MainViewModel(12);            
            InitializeComponent();
            NavigationCacheMode = NavigationCacheMode.Required;
        }		
        public MainViewModel ViewModel { get; set; }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            await this.ViewModel.LoadDataAsync();			
            
        }

    }
}
