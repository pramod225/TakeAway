using TakeAway.Components.DashBoard.ViewModels;
using TakeAway.Components.Base.Views;
using TakeAway.Model.Models;

namespace TakeAway.Components.Dashboard.Views;

public partial class DashbaordPage :ContentPage
{
    [Obsolete]
    public DashbaordPage(DashBoardViewModel dashBoardViewModel)
	{
		InitializeComponent();
		BindingContext = dashBoardViewModel;

        Device.StartTimer(TimeSpan.FromSeconds(3), (Func<bool>)(() =>
        {
            slider.Position = (slider.Position + 1) % dashBoardViewModel.LatestItems.Count;

            return true;
        }));
    }

   async void CollectionView_SelectionChanged(System.Object sender, Microsoft.Maui.Controls.SelectionChangedEventArgs e)
    {
        var restraurant = e.CurrentSelection.FirstOrDefault() as Restraurant;
        if (restraurant == null)
            return;
        await Navigation.PushAsync(new FullDetailsPage());
        ((CollectionView)sender).SelectedItem = null;

        //Shell.Current.GoToAsync(nameof(FullDetailsPage));
    }

    void slider_Scrolled(System.Object sender, Microsoft.Maui.Controls.ItemsViewScrolledEventArgs e)
    {
        double headerPointY = 5;

        if (e.VerticalOffset >= headerPointY)
        {
            VisualStateManager.GoToState(slider, "Hidden");
        }
        else
        {
            VisualStateManager.GoToState(slider, "Visible");
        }
    }
}
