namespace TakeAway;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        
        Routing.RegisterRoute(nameof(Components.Logins.Views.LoginPage), typeof(Components.Logins.Views.LoginPage));
        Routing.RegisterRoute(nameof(Components.Registrations.Views.RegistrationPage), typeof(Components.Registrations.Views.RegistrationPage));
       Routing.RegisterRoute(nameof(Components.Dashboard.Views.DashbaordPage), typeof(Components.Dashboard.Views.DashbaordPage));
        Routing.RegisterRoute(nameof(Components.ForgotPassword.Views.ForgotPasswordPage), typeof(Components.ForgotPassword.Views.ForgotPasswordPage));
    }
}

