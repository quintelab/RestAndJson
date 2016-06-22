using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace RestAndJson
{
	public partial class MainPage : ContentPage
	{
		MainPageViewModel viewModel;

		public MainPage()
		{
			viewModel = new MainPageViewModel();
			BindingContext = viewModel;
			InitializeComponent();
		}

		public async void Handle_Clicked(object sender, System.EventArgs e)
		{
			var longitude = double.Parse(entryLongitude.Text);
			var latitude = double.Parse(entryLatitude.Text);

			var url = string.Format("http://api.geonames.org/findNearByWeatherJSON?lat={0}&lng={1}&username=demo",
			                       latitude, longitude);

			await viewModel.GetWeatherAsync(url);
		}
	}
}

