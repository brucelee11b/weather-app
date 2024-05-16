using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherForecast.Domain.Entity
{
	public class WheatherForest
	{
		//public List<City> Cities { get; set; }

		//public string Cod {  get; set; }
		//public float Message { get; set; }
		//public int Cnt { get; set; }
		//public List<WheatherList> List { get; set; }
		public Coords coord { get; set; }
		public List<Weathers> weather { get; set; }

		public string Base { get; set; }
		public Mains main { get; set; }

		public float visibility { get; set; }

		public Wind wind { get; set; }
		public CLoud clouds { get; set; }

		public float dt { get; set; }
		public Sys sys { get; set; }
		public float timezone { get; set; }
		public int id { get; set; }
		public string name { get; set; }
		public float cod { get; set; }

	}

	public class Wind
	{
		public float speed { get; set; }
		public float deg { get; set; }
		public float gust { get; set; }
	}

	public class CLoud
	{
		public float all { get; set; }
	}
	public class Sys
	{
		public int type { get; set; }
		public int id { get; set; }
		public string country { get; set; }
		public float sunrise { get; set; }
		public float sunset { get; set; }
	}

	//public class WheatherList
	//{
	//	public float Dt { get; set; }
	//	public float Sunrise { get; set; }
	//	public float Sunset { get; set;}
	//	public List<Temp> Temp {  get; set; }
	//	public List<Feel> Feellike { get; set; }

	//	public float Pressure { get; set; }
	//	public float Humidity { get; set; }
	//	public List<Weather> Wheathers { get; set; }
	//	public float Speed { get; set; }
	//	public float Deg {  get; set; }
	//	public float Gust { get; set; }
	//	public float Clouds { get; set; }
	//	public float Pop {  get; set; }
	//	public float Rain { get; set; }
	//}

	//public class Temp
	//{
	//	public float Day { get; set; }
	//	public float Min { get; set; }	
	//	public float Max { get; set; }
	//	public float Night { get; set; }
	//	public float Eve { get; set; }
	//	public float Morn { get; set; }
	//}

	//public class Feel
	//{
	//	public float Day { get; set; }
	//	public float Night { get; set; }
	//	public float Eve { get; set; }
	//	public float Morn { get; set; }
	//}

	//public class Weather
	//{
	//	public int Id { get; set; }
	//	public string Main { get; set; }
	//	public string Description { get; set; }
	//	public string Icon { get; set; }
	//}
	public class Coords
	{
		public float lon { get; set; }
		public float lat { get; set; }
	}

	public class Weathers
	{
		public int id { get; set; }
		public string main { get; set; }
		public string description { get; set; }
		public string icon { get; set; }
	}

	public class Mains
	{
		public float temp { get; set; }
		public float feels_like { get; set; }

		public float temp_min { get; set; }
		public float temp_max { get; set; }
		public float pressure { get; set; }
		public float humidity { get; set; }
		public float sea_level { get; set; }
		public float grnd_level { get; set; }
	}


}

