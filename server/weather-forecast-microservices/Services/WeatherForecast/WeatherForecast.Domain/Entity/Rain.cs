using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WeatherForecast.Domain.Entity
{
	public class Rain
	{
		[JsonPropertyName("3h")]
		public float name { get; set; }
	}
}
