//---------------------------------------------------------------------------
//
// <copyright file="ZDNETListPage.xaml.cs" company="Microsoft">
//    Copyright (C) 2015 by Microsoft Corporation.  All rights reserved.
// </copyright>
//
// <createdOn>5/11/2016 6:40:33 AM</createdOn>
//
//---------------------------------------------------------------------------

using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml;
using AppStudio.DataProviders.Rss;
using TechNewsHub.Sections;
using TechNewsHub.ViewModels;
using AppStudio.Uwp;

namespace TechNewsHub.Pages
{
    public sealed partial class ZDNETListPage : Page
    {
	    public ListViewModel ViewModel { get; set; }
        public ZDNETListPage()
        {
			this.ViewModel = ListViewModel.CreateNew(Singleton<ZDNETConfig>.Instance);

            this.InitializeComponent();

        }


        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            await this.ViewModel.LoadDataAsync();
            base.OnNavigatedTo(e);
        }

    }
}
