using EsriNeaMvvm;
using EsriNeaMvvmPattern.ViewModels;
using EsriNeaMvvmPattern.Pages;
using EsriNeaMvvmPattern.ViewModels.Home;
using EsriNeaMvvmPattern.ViewModels.Login;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EsriNeaMvvmPattern
{
    public partial class App : Application
    { 
        public App()
        {
            InitializeComponent();

            SetupDependencyInjection();

          //  SetStartPage();

            SetupMasterDetail();
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
    }
}
