using EsriNeaMvvm;
using EsriNeaMvvmPattern.ViewModels;
using EsriNeaMvvmPattern.Pages;
using EsriNeaMvvmPattern.ViewModels.Home;
using EsriNeaMvvmPattern.ViewModels.Login;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;

namespace EsriNeaMvvmPattern
{
    public partial class App : Xamarin.Forms.Application
    { 
        public App()
        {
            InitializeComponent();

            SetupDependencyInjection();

          //  SetStartPage();

         //   SetupMasterDetail();

            SetupTabbedPage();
        }

        private void SetupDependencyInjection()
        {
           // FreshIOC.Container.Register<IValidatorService, ValidatorService>();
            EsriIOC.Container.Register<BaseViewModel,LoginViewModel>().AsSingleton();
            EsriIOC.Container.Register<BaseViewModel, MainViewModel>().AsSingleton();
            EsriIOC.Container.Register<MasterDetailNavigationContainer, MasterDetailNavigationContainer>().AsSingleton();
        }

        private void SetStartPage()
        {
            var mainPage = ViewModelResolver.ResolvePageModel<LoginViewModel>();
            MainPage = new NavigationPageContainer(mainPage);
        }
        public void SetupMasterDetail()
        {
            var masterDetailNav = EsriIOC.Container.Resolve<MasterDetailNavigationContainer>();
         // masterDetailNav.Init("Menu", "Menu.png");
            masterDetailNav.Init<MasterMenuViewModel>("navigationList");
            masterDetailNav.AddPage<LoginViewModel>("Hii");
            masterDetailNav.AddPage<MainViewModel>(new List<int>() { 1,2,3});
            MainPage = masterDetailNav;
        }
        public void SetupTabbedPage()
        {
            var tabbedpage = new TabbedNavigationContainer();
            tabbedpage.On<Android>().SetToolbarPlacement(ToolbarPlacement.Bottom);
            
            tabbedpage.AddTab<MasterMenuViewModel>("master", "icon");
            tabbedpage.AddTab<LoginViewModel>("login", "icon");
            tabbedpage.AddTab<MainViewModel>("main", "icon");
            MainPage = tabbedpage;
        }
    }
}
