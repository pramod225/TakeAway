using System;
namespace TakeAway.Model.Models
{
	public class Restraurant
	{
        public Guid RestaurantId { get; set; }
        public string RestaurantName { get; set; }
        public string RestaurantAddress { get; set; }
        public string Image { get; set; }
        public double RatingStar { get; set; }
        public string Time { get; set; }
        public string OpenRestaurantTime { get; set; }
        public bool HeartFavourite { get; set; }
    }
}

