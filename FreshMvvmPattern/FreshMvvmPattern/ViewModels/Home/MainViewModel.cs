using EsriNeaMvvm;
using FreshMvvmPattern.ViewModels.Login;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FreshMvvmPattern.ViewModels.Home
{
    public class MainViewModel : BaseViewModel
    {
        public AwaitCommand GoBackCommand { get; }
        public MainViewModel()
        {
            GoBackCommand = new AwaitCommand(GoBackCommandExecute);
        }

        private async void GoBackCommandExecute(object arg1, TaskCompletionSource<bool> arg2)
        {
             await NavigationService.PopPageModel("adada"); 
        }

        protected override void ViewIsAppearing(object sender, EventArgs e)
        {
            base.ViewIsAppearing(sender, e);
            //FreshIOC.Container.Resolve<IValidatorService>().populate();
            //var test = FreshIOC.Container.Resolve<IValidatorService>();
            //FreshIOC.Container.Resolve<IValidatorService>().populate();
            //var test2 = FreshIOC.Container.Resolve<IValidatorService>();
            //FreshIOC.Container.Resolve<IValidatorService>().populate();
            //var test3 = FreshIOC.Container.Resolve<IValidatorService>();
        }
        public override void Init(object initData)
        {
            base.Init(initData);
        }
        public override void ReverseInit(object returnedData)
        {
            base.ReverseInit(returnedData);
        }
    }
}
