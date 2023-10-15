using TakeAway.Components.Dashboard.Views;
using TakeAway.Components.Logins.Views;
using TakeAway.Components.Registrations.Views;

namespace TakeAway;

public partial class App : Application
{
	public App(AppShell shell)
	{
		InitializeComponent();
		MainPage = shell;
        
    }
		
}

