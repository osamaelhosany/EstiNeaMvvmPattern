using EsriNeaMvvm;
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
        }

        private void GoBackCommandExecute(object arg1, TaskCompletionSource<bool> arg2)
        {
            EsriIOC.Container.Resolve<MasterDetailNavigationContainer>().IsPresented = false;
            arg2.SetResult(false);
        }
    }
}
