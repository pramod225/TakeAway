using TakeAway.Components.Registration.ViewModels;
using TakeAway.Components.Base.Views;
namespace TakeAway.Components.Registrations.Views;

public partial class RegistrationPage : BasePage
{
	public RegistrationPage(RegisterViewModel registerViewModel)
	{
		InitializeComponent();
        BindingContext = registerViewModel;
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
        Task.Run(() => {
            Device.BeginInvokeOnMainThread(() => TxtName.Focus());
        });
    }
}
