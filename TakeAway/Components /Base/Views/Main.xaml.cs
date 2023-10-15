using TakeAway.Components.Base.ViewModels;
namespace TakeAway.Components.Base.Views;

public partial class Main : BasePage
{
	public Main(MainViewModel mainViewModel)
	{
        InitializeComponent();
        BindingContext = mainViewModel;
	}
	
}
