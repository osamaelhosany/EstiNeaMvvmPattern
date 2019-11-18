using DropdownMenu.Models.DropdownModel;
using EsriNeaMvvm;
using EsriNeaMvvmPattern.ViewModels.Login;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace EsriNeaMvvmPattern.ViewModels.Home
{
    public class MainViewModel : BaseViewModel
    {
        public DropMenuModel GenderList { get; set; }
        public DropMenuModel LookingforList { get; set; }
        public ICommand GenderSelectedCommand { get; set; }
        public AwaitCommand GoBackCommand { get; }
        public MainViewModel()
        {
            Title = "Home";
            GenderList = new DropMenuModel
            {
                Id = 1,
                HeaderName = "Gender",
                DropMenuList = new ObservableCollection<DropMenuItemModel>
                    {
                        new DropMenuItemModel
                        {
                            Id = 1,
                            Name = "Male",
                            IsSelected = false,
                        },
                        new DropMenuItemModel
                        {
                            Id = 2,
                            Name = "Female",
                            IsSelected = false,
                        },
                        new DropMenuItemModel
                        {
                            Id = 3,
                            Name = "Other",
                            IsSelected = false,
                        },
                    }
            };

            GoBackCommand = new AwaitCommand(GoBackCommandExecute);
            GenderSelectedCommand = new Command(GenderSelectedCommandExecute);

        }
        private void GenderSelectedCommandExecute(object obj)
        {
            //first we set all is selected == false then we set new value
            GenderList.DropMenuList.Select(x => { x.IsSelected = false; return x; }).ToList();

            if (obj is DropMenuItemModel selecteditem)
                GenderList.DropMenuList.FirstOrDefault(x => x.Id == selecteditem.Id).IsSelected = true;
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
