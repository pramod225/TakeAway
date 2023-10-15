using TakeAway.Components.Logins.ViewModels;
using TakeAway.Components.Base.Views;

namespace TakeAway.Components.Logins.Views;

public partial class LoginPage : BasePage
{
	public LoginPage(LoginsViewModel loginViewModel)
	{
        InitializeComponent();
        BindingContext = loginViewModel;
    }
    

    
}
