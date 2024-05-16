using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherForecast.Domain.Entity
{
	public class City
	{
		public int Id { get; set; }
		public string Name { get; set; }

		public List<Coord> Coords { get; set; }

		public string Country { get; set; }
		public string Population { get; set; }

		public string Timezone { get; set; }
	}

	public class Coord
	{
		public float lon { get; set; }
		public float lat { get; set; }
	}
}
