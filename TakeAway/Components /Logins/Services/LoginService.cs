using System;
using System.Threading.Tasks;
using Firebase.Auth;
using Newtonsoft.Json;
using TakeAway.Components.Base.Services;
using TakeAway.Components.Constants;
using TakeAway.Model.Models;

namespace TakeAway.Components.Logins.Services
{
	public class LoginService : ILoginService
	{
        private readonly IConnectionCheckedService _connectionCheckedService;
        public LoginService(IConnectionCheckedService connectionCheckedService)
		{
            _connectionCheckedService = connectionCheckedService;
		}
        public async Task<bool> GetLogin(Login login)
        {
            try
            {
                if ( _connectionCheckedService.ConnectionCheckFunction())
                {
                    var authProvider = new FirebaseAuthProvider(new FirebaseConfig(ConstantString.WebApiKey));
                    if (!(string.IsNullOrEmpty(login.UserName) && string.IsNullOrEmpty(login.Password)))
                    {
                        var auth = await authProvider.SignInWithEmailAndPasswordAsync(login.UserName,login.Password);
                        var content = await auth.GetFreshAuthAsync();
                        var serializedContent = JsonConvert.SerializeObject(content);
                        Preferences.Set(ConstantString.Token, serializedContent);
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
                return false;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("EMAIL_NOT_FOUND"))
                {
                    await App.Current.MainPage.DisplayAlert("Unauthorized", "Email not found", "ok");
                }
                else if (ex.Message.Contains("INVALID_PASSWORD"))
                {
                    await App.Current.MainPage.DisplayAlert("Unauthorized", "Password incorrect", "ok");
                }
                else if (ex.Message.Contains("TOO_MANY_ATTEMPTS_TRY_LATER"))
                {
                    await App.Current.MainPage.DisplayAlert("Error", "please after sometimes", "Ok");

                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Error", "Invalid Email and Password", "Ok");
                }
                return false;
            }

        }
    }
}

