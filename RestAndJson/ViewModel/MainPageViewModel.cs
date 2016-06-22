using System;
using System.ComponentModel;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RestAndJson
{
	public class MainPageViewModel : INotifyPropertyChanged
	{
		private string station;
		public string StationName
		{
			get
			{
				return station;
			}
			set
			{
				station = value;
				NotifyPropertyChanged();
			}
		}

		private long elevation;
		public long Elevation
		{
			get
			{
				return elevation;
			}
			set
			{
				elevation = value;
				NotifyPropertyChanged();
			}
		}

		private long temperature;
		public long Temperature
		{
			get
			{
				return temperature;
			}
			set
			{
				temperature = value;
				NotifyPropertyChanged();
			}
		}

		private long humidity;
		public long Humidity
		{
			get
			{
				return humidity;
			}
			set
			{
				humidity = value;
				NotifyPropertyChanged();
			}
		}

		public async Task GetWeatherAsync(string url)
		{
			HttpClient client = new HttpClient();
			client.BaseAddress = new Uri(url);

			var response = await client.GetAsync(client.BaseAddress);
			response.EnsureSuccessStatusCode();

			var JsonResult = response.Content.ReadAsStringAsync().Result;
			var weather = JsonConvert.DeserializeObject<WeatherResult>(JsonResult);

			SetValues(weather);
		}

		private void SetValues(WeatherResult weather)
		{
			if (weather.weatherObservation != null)
			{
				StationName = weather.weatherObservation.stationName;
				Elevation = weather.weatherObservation.elevation;
				Temperature = weather.weatherObservation.temperature;
				Humidity = weather.weatherObservation.humidity;
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;

		private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
		{
			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}

