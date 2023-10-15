using System;
using System.Threading.Tasks;
using Firebase.Auth;
using Firebase.Database;
using Firebase.Database.Query;
using TakeAway.Components.Base.Services;
using TakeAway.Components.Constants;
using TakeAway.Model.Models;
using TakeAway.Components.Logins.Views;
using Newtonsoft.Json;

namespace TakeAway.Components.Registration.Services
{
    public class RegistrationService : IRegistrationService
    {
        private readonly IConnectionCheckedService _checkedService;
        FirebaseClient client;
        public RegistrationService(IConnectionCheckedService connectionCheckedService)
        {
            _checkedService = connectionCheckedService;
            client = new FirebaseClient(ConstantString.FirebaseUrl);

        }
        public async Task<bool> AddRegistration(SignUp register)
        {
            try
            {
                if ( _checkedService.ConnectionCheckFunction())
                {
                    if (register !=null)
                    {
                        var registerResponse = await client.Child(ConstantString.RegisterTable).PostAsync(new SignUp()
                        {
                            RegisterId = Guid.NewGuid(),
                            Name = register.Name,
                            Email = register.Email,
                            Password = register.Password,
                            PhoneNo = register.PhoneNo
                        });
                        if (registerResponse != null)
                        {
                            await SignUp(register.Email, register.Password);
                            await Shell.Current.GoToAsync(nameof(LoginPage));
                        }
                       
                    }
                   
                    return false;
                }
                await App.Current.MainPage.DisplayAlert("Message","No Internet !","Ok");
                return false;
               
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<string> SignUp(string userName, string password)
        {
            try
            {
                if ( _checkedService.ConnectionCheckFunction())
                {

                    if (!(string.IsNullOrEmpty(userName) && string.IsNullOrEmpty(password)))
                    {
                        var authProvider = new FirebaseAuthProvider(new FirebaseConfig(ConstantString.WebApiKey));
                        var auth = await authProvider.CreateUserWithEmailAndPasswordAsync(userName, password);
                        string getToken = auth.FirebaseToken;
                        return getToken;
                    }
                    return null;
                }
                return null;

            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("EMAIL_EXISTS"))
                {
                    await App.Current.MainPage.DisplayAlert("Warning", "Email exist", "Ok");
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Error", ex.Message, "Ok");
                }
                return null;
            }
        }

        private void GetRefreshToken(string userName)
        {
            var authProvider = new FirebaseAuthProvider(new FirebaseConfig(ConstantString.WebApiKey));
            try
            {
                var saveFirebaseAuth = JsonConvert.DeserializeObject<FirebaseAuth>(Preferences.Get(ConstantString.Token, ""));
                var refreshToken = authProvider.RefreshAuthAsync(saveFirebaseAuth);
                Preferences.Set(ConstantString.Token, JsonConvert.SerializeObject(refreshToken));
                userName = saveFirebaseAuth.User.DisplayName;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
