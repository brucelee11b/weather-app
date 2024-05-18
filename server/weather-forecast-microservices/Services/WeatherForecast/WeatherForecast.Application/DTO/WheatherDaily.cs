using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using WeatherForecast.Domain.Entity;

namespace WeatherForecast.Application.DTO
{
	public class WheatherDaily
	{
		[JsonPropertyName("cod")]
		public string cod {  get; set; }

		public int message { get; set; }
		public int cnt { get; set; }

		public List<WheatherList> list { get; set; }
		public City city { get; set; }
	}

    public class WheatherList
	{
        public float dt { get; set; }
		public Mains main { get; set; }
		public List<Weathers> weather { get; set; }
		public CLoud clouds { get; set; }
		public Wind wind { get; set; }
		public float visibility {  get; set; }
		public float pop {  get; set; }
		public Rain rain { get; set; }
		public Syse sys { get; set; }
		public string dt_txt { get; set; }
	}

	public class Syse
	{
		public string pod { get; set; }
	}
}
