using System;
using TakeAway.Components.Logins.ViewModels;
using TakeAway.Components.Base.ViewModels;
using TakeAway.Components.Registration.ViewModels;
using TakeAway.Components.DashBoard.ViewModels;

namespace TakeAway.IOCContainer
{
	public static class RegisterViewModels
	{
        public static MauiAppBuilder RegisterViewModel(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddSingleton<LoginsViewModel>();
            mauiAppBuilder.Services.AddSingleton<MainViewModel>();
            mauiAppBuilder.Services.AddSingleton<RegisterViewModel>();
            mauiAppBuilder.Services.AddTransient<DashBoardViewModel>();
            return mauiAppBuilder;
        }

    }
}

