using System;
using System.Collections.ObjectModel;
using Firebase.Database;
using Firebase.Storage;
using TakeAway.Components.Base.Services;
using TakeAway.Components.Constants;
using TakeAway.Model.Models;

namespace TakeAway.Components.Dashboard.Services
{
	public class RestaurantService : IRestaurantService
    {
        FirebaseClient _client;
        FirebaseStorage _firebaseStorage;
        private IConnectionCheckedService _checkedService;
        public RestaurantService(IConnectionCheckedService checkedService)
		{
            _checkedService = checkedService;
            _client = new FirebaseClient(ConstantString.FirebaseUrl);
            _firebaseStorage = new FirebaseStorage(ConstantString.FirebaseStorageUrl);
        }

        public Task AddAndUpdateRestaurants(Restraurant restaurant)
        {
            throw new NotImplementedException();
        }

        public async Task<ObservableCollection<Restraurant>> GetLatestFoodItemsAsync()
        {
            var latestFoodItem = new ObservableCollection<Restraurant>();
            var items = await GetRestaurantData();
            foreach (var item in items)
            {
                latestFoodItem.Add(item);
            }
            return latestFoodItem;
        }

        public async Task<List<Restraurant>> GetRestaurantData()
        {
            try
            {
                if ( _checkedService.ConnectionCheckFunction())
                {
                    var data = (await _client.Child(ConstantString.RestaurantTable).OnceAsync<Restraurant>()).Select(x => new Restraurant
                    {
                        RestaurantName = x.Object.RestaurantName,
                        RestaurantAddress = x.Object.RestaurantAddress,
                        RatingStar = x.Object.RatingStar,
                        Image = x.Object.Image,
                        OpenRestaurantTime = x.Object.OpenRestaurantTime,
                        Time = x.Object.Time

                    }).ToList();
                    return data;
                }
                return default;


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<string> UploadFile(Stream fileStream, string fileName)
        {
            throw new NotImplementedException();
        }
    }
}

