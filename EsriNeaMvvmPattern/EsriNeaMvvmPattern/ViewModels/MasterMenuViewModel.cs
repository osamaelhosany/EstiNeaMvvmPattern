using EsriNeaMvvm;
using EsriNeaMvvmPattern.ViewModels.Home;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EsriNeaMvvmPattern.ViewModels
{
    public class MasterMenuViewModel : BaseViewModel
    {
        public List<MenuItems> MenuItems { get; set; }
        public AwaitCommand GoBackCommand { get; }
        public AwaitCommand SelectedCommand { get; }
        public MasterMenuViewModel()
        {
            Title = "Master";
            Icon = "logo";
            MenuItems = new List<MenuItems> 
            { 
                new MenuItems 
                { 
                    Title="Login",
                    Image ="logo"
                }, 
                new MenuItems 
                { 
                    Title = "Home",
                    Image ="logo"
                } 
            };
            GoBackCommand = new AwaitCommand(GoBackCommandExecute);
            SelectedCommand = new AwaitCommand(SelectedCommandExecute);
        }

        private async void SelectedCommandExecute(object arg1, TaskCompletionSource<bool> arg2)
        {
            await NavigationService.PushPageModel<MainViewModel>("", false, true);
            arg2.SetResult(false);

        }

        private void GoBackCommandExecute(object arg1, TaskCompletionSource<bool> arg2)
        {
            EsriIOC.Container.Resolve<MasterDetailNavigationContainer>().IsPresented = false;
            arg2.SetResult(false);
        }
    }
}
