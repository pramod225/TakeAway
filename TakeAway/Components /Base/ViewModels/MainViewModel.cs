using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TakeAway.Components.Constants;
using TakeAway.Components.Dashboard.Views;
using TakeAway.Components.Registrations.Views;

namespace TakeAway.Components.Base.ViewModels
{
	public partial class MainViewModel 
    {

        public MainViewModel()
        {
        }
        [RelayCommand]
		public void Login()
		{
            Shell.Current.GoToAsync(nameof(DashbaordPage));
        }

        [RelayCommand]
        public void Register()
        {
             Shell.Current.GoToAsync(nameof(RegistrationPage));
        }
    }
}

