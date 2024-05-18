using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using WeatherForecast.Domain.Entity;

namespace WeatherForecast.Application.DTO
{
	public class WheatherSearchDto
	{
		public Coords coord { get; set; }
		public List<Weathers> weather { get; set; }

		[JsonPropertyName("base")]
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
}
