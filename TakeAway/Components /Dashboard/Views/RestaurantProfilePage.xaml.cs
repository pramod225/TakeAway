namespace TakeAway.Components.Dashboard.Views;

public partial class RestaurantProfilePage : ContentPage
{
	public RestaurantProfilePage(DashBoard.ViewModels.DashBoardViewModel dashBoardViewModel)
	{
		InitializeComponent();
        BindingContext = dashBoardViewModel;
    }

    void RootScrollView_Scrolled(System.Object sender, Microsoft.Maui.Controls.ScrolledEventArgs e)
    {
    }
}
