using System;
using System.Threading.Tasks;
using TakeAway.Model.Models;

namespace TakeAway.Components.Registration.Services
{
    public interface IRegistrationService
    {
        Task<string> SignUp(string userName , string password);
        Task<bool> AddRegistration(SignUp register);
    }
}
