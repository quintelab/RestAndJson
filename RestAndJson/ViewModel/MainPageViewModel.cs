using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

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

		private string elevation;
		public string Elevation
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

		private string temperature;
		public string Temperature
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

		private string humidity;
		public string Humidity
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
		}

		public event PropertyChangedEventHandler PropertyChanged;

		private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
		{
			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}

