using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TakeAway.Components.Base.ViewModels;
using TakeAway.Components.Dashboard.Services;
using TakeAway.Model.Models;

namespace TakeAway.Components.DashBoard.ViewModels;
    public partial class DashBoardViewModel : BaseViewModel
    {
        private IRestaurantService _restaurantService;
        [ObservableProperty]
        private ObservableCollection<Restraurant> _latestItems;

   
        [ObservableProperty]
        private bool _isFavourite;
       
        public DashBoardViewModel(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
            LatestItems = new ObservableCollection<Restraurant>();
            GetLatestItems();
        }

        //private async void GetLatestItems()
        //{
        //    LatestItems = new ObservableCollection<RestraurantModel>(await _restaurantService.GetRestaurantData());

        //}
    private async Task GetLatestItems()
    {
        var data = await _restaurantService.GetLatestFoodItemsAsync();
        LatestItems.Clear();
        foreach (var item in data)
        {
            LatestItems.Add(item);
        }
    }
    [RelayCommand]
    private async Task ItemTappedCommand()
    {
        await Shell.Current.GoToAsync(nameof(Dashboard.Views.FullDetailsPage));
    }


}
