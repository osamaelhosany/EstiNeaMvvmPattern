using EsriNeaMvvm;
using FreshMvvmPattern.Pages;
using FreshMvvmPattern.ViewModels.Home;
using FreshMvvmPattern.ViewModels.Login;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FreshMvvmPattern
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            SetupDependencyInjection();

            SetStartPage();

          //  SetupMasterDetail();
        }

        private void SetupDependencyInjection()
        {
           // FreshIOC.Container.Register<IValidatorService, ValidatorService>();
            EsriIOC.Container.Register<BaseViewModel,LoginViewModel>().AsSingleton();
            EsriIOC.Container.Register<BaseViewModel, MainViewModel>().AsSingleton();
        }

        private void SetStartPage()
        {
            var mainPage = ViewModelResolver.ResolvePageModel<LoginViewModel>();
            MainPage = new NavigationPageContainer(mainPage);
        }
        public void SetupMasterDetail()
        {
            var masterDetailNav = new MasterDetailNavigationContainer();
            masterDetailNav.Init("Menu", "Menu.png");
            masterDetailNav.AddPage<LoginViewModel>("Login", "Hii");
            masterDetailNav.AddPage<MainViewModel>("Home", new List<int>() { 1,2,3});
            MainPage = masterDetailNav;
        }
    }
}
