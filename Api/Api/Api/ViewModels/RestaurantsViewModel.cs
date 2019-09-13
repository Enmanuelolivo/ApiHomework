using Api.Model;
using Api.Services;
using Refit;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Api.ViewModels
{
    public class RestaurantsViewModel: INotifyPropertyChanged
    {
        public ObservableCollection<Result>Restaurants { get; set; }
        public ICommand getNearBySearchCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        
    
    public RestaurantsViewModel()
    {
        getNearBySearchCommand = new Command(async () =>
        {
            await getNearBySearch();
        });

    }


    async Task getNearBySearch()
    {
        try
        {
            var current = Connectivity.NetworkAccess;
            if (current == NetworkAccess.Internet)
            {
                    var nsAPI = RestService.For<IApiServices>("https://maps.googleapis.com");
                    var restaurants = await nsAPI.getNearBySearch();

                    Restaurants = new ObservableCollection<Result>(restaurants.Results);
                }
            else
            {
                await App.Current.MainPage.DisplayAlert("Error", "You don't have internet connection", "Ok");
            }
        }
        catch (Exception ex)
        {
            await App.Current.MainPage.DisplayAlert("Error", "Unable to connect to the server", "Ok");
        }
    }

}
}
