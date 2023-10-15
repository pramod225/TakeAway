using System;
using System.Linq;
using System.Threading.Tasks;

namespace TakeAway.Components.Base.Services;

    public class ConnectionCheckedService : IConnectionCheckedService
    {
        public ConnectionCheckedService()
        {

        }

       public bool ConnectionCheckFunction()
        {
          
            try
            {
                if (Connectivity.NetworkAccess == NetworkAccess.None)
                {
                    Application.Current.MainPage.DisplayAlert("Message", "No Internet Connection Please check !", "Ok");
                }
                Connectivity.ConnectivityChanged += ConnectivityChangedHandler;
                return true;
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }

        private void ConnectivityChangedHandler(object sender, ConnectivityChangedEventArgs e)
        {
            if(!(e.ConnectionProfiles.Contains(ConnectionProfile.Ethernet)))
            {

            }
        }
    }

