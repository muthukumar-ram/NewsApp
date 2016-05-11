//---------------------------------------------------------------------------
//
// <copyright file="TechNewsListPage.xaml.cs" company="Microsoft">
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
    public sealed partial class TechNewsListPage : Page
    {
	    public ListViewModel ViewModel { get; set; }
        public TechNewsListPage()
        {
			this.ViewModel = ListViewModel.CreateNew(Singleton<TechNewsConfig>.Instance);

            this.InitializeComponent();

        }


        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            await this.ViewModel.LoadDataAsync();
            base.OnNavigatedTo(e);
        }

    }
}
