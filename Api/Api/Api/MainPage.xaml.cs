using Api.Services;
using Refit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Api
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await CallApi();
        }
        async Task CallApi()
        {
            var nsAPI = RestService.For<IApiServices>("https://maps.googleapis.com");
            var restaurants = await nsAPI.getNearBySearch("18.491955, -69.93689");
        }
    }
}
