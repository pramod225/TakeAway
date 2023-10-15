using System;
using System.Collections.ObjectModel;
using TakeAway.Model.Models;

namespace TakeAway.Components.Dashboard.Services
{
	public interface IRestaurantService
	{
        Task AddAndUpdateRestaurants(Restraurant restaurant);
       Task<List<Restraurant>> GetRestaurantData();
        Task<string> UploadFile(Stream fileStream, string fileName);
        Task<ObservableCollection<Restraurant>> GetLatestFoodItemsAsync();
    }
}

