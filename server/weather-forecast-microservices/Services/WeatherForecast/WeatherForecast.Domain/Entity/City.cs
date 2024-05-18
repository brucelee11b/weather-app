﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherForecast.Domain.Entity
{
	public class City
	{
		public float id { get; set; }
		public string name { get; set; }
		public Coords coord { get; set; }
		public string country { get; set; }
		public float population { get; set; }
		public float timezone { get; set; }
		public float sunrise { get; set; }
		public float sunset { get; set; }
	}
}
