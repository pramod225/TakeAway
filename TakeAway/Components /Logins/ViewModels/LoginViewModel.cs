using System;
using CommunityToolkit.Mvvm.ComponentModel;
using TakeAway.Components.Registrations.Views;
using CommunityToolkit.Mvvm.Input;
using TakeAway.Components.Dashboard.Views;
using TakeAway.Components.Logins.Services;
using TakeAway.Model.Models;
using TakeAway.Components.Base.ViewModels;

namespace TakeAway.Components.Logins.ViewModels;

    [QueryProperty(nameof(Login), nameof(Login))]
    public partial class LoginsViewModel : BaseViewModel
    {
        private readonly ILoginService _service;

        [ObservableProperty]
        private Login _login;
        public LoginsViewModel(ILoginService service)
		{
            _service = service;
            Login = new Login();
		}

        //public void ApplyQueryAttributes(IDictionary<string, object> query)
        //{
        //   Login = query["Login"] as Models.Models.Login;
        //}

        //[ObservableProperty]
        //private string password;

        [RelayCommand]
        public async Task ForgotPassword()
        {
        await Shell.Current.GoToAsync(nameof(Components.ForgotPassword.Views.ForgotPasswordPage));
        }
        [RelayCommand]
        private async Task SignUp()
        {
            await Shell.Current.GoToAsync(nameof(RegistrationPage));
        }
        [RelayCommand]
        public async Task Logins()
        {
            bool isLoginResponse = await _service.GetLogin(Login);
            if (isLoginResponse)
            {
                await Shell.Current.GoToAsync(nameof(DashbaordPage));
            }
            
        }
    }


