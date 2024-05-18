﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherForecast.Domain.Entity
{
	public class WheatherForest
	{
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
}

