using EsriNeaMvvm;
using EsriNeaMvvmPattern.ViewModels.Home;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EsriNeaMvvmPattern.ViewModels.Login
{
    public class LoginViewModel : BaseViewModel
    {
       // readonly IValidatorService _validatorService;
        public string UserName { get; set; }
        public AwaitCommand LoginCommand { get; }
        public LoginViewModel()
        {
            Title = "Login";
           // _validatorService = validatorService;
            LoginCommand = new AwaitCommand(LoginCommandExecute);
           // this.WhenAny((string s)=> { populate(); }, x=> x.UserName);
        }
        void OnUserNameChanged() 
        {

        }
        public int count { get; set; }
        private async void LoginCommandExecute(object arg1, TaskCompletionSource<bool> arg2)
        {
            await NavigationService.PushPageModel<MainViewModel>("",true,true);
            arg2.SetResult(false);
        }
        public void populate() 
        {
            UserName = "osama";
            count++;
        }
        protected override void ViewIsAppearing(object sender, EventArgs e)
        {
            base.ViewIsAppearing(sender, e);
        }
        public override void Init(object initData)
        {
            base.Init(initData);
        }
        public override void ReverseInit(object returnedData)
        {
            populate();
            base.ReverseInit(returnedData);

        }
    }
}
