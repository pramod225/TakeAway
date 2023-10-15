using System;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TakeAway.Components.Base.ViewModels;
using TakeAway.Components.Registration.Services;
using TakeAway.Model.Models;

namespace TakeAway.Components.Registration.ViewModels
{
    [QueryProperty(nameof(Register), nameof(Register))]
    public partial class RegisterViewModel : BaseViewModel
    {
        private readonly IRegistrationService _registrationService;

        [ObservableProperty]
        private SignUp _register;
        public RegisterViewModel(IRegistrationService registrationService)
        {
            _registrationService = registrationService;
            Register = new SignUp();
          
        }

        [RelayCommand]
        private async Task Save()
        {
            await _registrationService.AddRegistration(Register);
        }

        
    }
}
