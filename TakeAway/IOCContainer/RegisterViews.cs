using System;
using TakeAway.Components.Logins.Views;
using TakeAway.Components.Dashboard.Views;
using TakeAway.Components.Registrations.Views;
using TakeAway.Components.Base.Views;
namespace TakeAway.IOCContainer
{
	public static class RegisterViews
	{
        public static MauiAppBuilder RegisterAppViews(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddSingleton<LoginPage>();
            mauiAppBuilder.Services.AddTransient<RegistrationPage>();
            mauiAppBuilder.Services.AddSingleton<DashbaordPage>();
            mauiAppBuilder.Services.AddSingleton<BasePage>();
            mauiAppBuilder.Services.AddSingleton<Main>();
            mauiAppBuilder.Services.AddSingleton<FullDetailsPage>();
            mauiAppBuilder.Services.AddSingleton<RestaurantProfilePage>();
            mauiAppBuilder.Services.AddSingleton<AppShell>();
            mauiAppBuilder.Services.AddSingleton<MainPage>();
            mauiAppBuilder.Services.AddSingleton<ProductProfilePage>();
            mauiAppBuilder.Services.AddSingleton<SubProductProfilePage>();
            mauiAppBuilder.Services.AddSingleton<ProductProfileCheckoutPage>();
            return mauiAppBuilder;

        }
    }
}

