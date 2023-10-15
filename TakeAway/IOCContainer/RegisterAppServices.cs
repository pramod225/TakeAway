using System;
using TakeAway.Components.Base.Services;
using TakeAway.Components.Dashboard.Services;
using TakeAway.Components.Logins.Services;
using TakeAway.Components.Registration.Services;

namespace TakeAway.IOCContainer
{
    public static class RegisterAppServices
    {
       
        public static MauiAppBuilder RegisterAppService(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddSingleton<ILoginService, LoginService>();
            mauiAppBuilder.Services.AddSingleton<IConnectionCheckedService, ConnectionCheckedService>();
            mauiAppBuilder.Services.AddSingleton<IRegistrationService, RegistrationService>();
            mauiAppBuilder.Services.AddSingleton<IRestaurantService, RestaurantService>();
            return mauiAppBuilder;

        }

      

    }
}

