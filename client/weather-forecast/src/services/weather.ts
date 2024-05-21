const baseUrl = 'http://localhost:5001';

export const fetchWeatherData = async (
  city: string | { lat: number; lng: number }
) => {
  console.log(city);
  let url = '';
  if (typeof city === 'object') {
    url = `${baseUrl}/current-weather?lat=${city.lat}&lon=${city.lng}`;
  }

  // if (typeof city === 'object') {
  //   url = `${baseUrl}/weather?lat=${city.lat}&lon=${city.lng}&appid=${process.env.REACT_APP_WEATHER_API_KEY}`;
  // }
  return await (await fetch(url)).json();

  // const result = {
  //   coord: {
  //     lon: 105.5408,
  //     lat: 21.0149,
  //   },
  //   weather: [
  //     {
  //       id: 802,
  //       main: 'Clouds',
  //       description: 'scattered clouds',
  //       icon: '03d',
  //     },
  //   ],
  //   base: 'stations',
  //   main: {
  //     temp: 303.14,
  //     feels_like: 305.57,
  //     temp_min: 303.14,
  //     temp_max: 303.14,
  //     pressure: 1010,
  //     humidity: 58,
  //     sea_level: 1010,
  //     grnd_level: 1008,
  //   },
  //   visibility: 10000,
  //   wind: {
  //     speed: 2.51,
  //     deg: 37,
  //     gust: 2.46,
  //   },
  //   clouds: {
  //     all: 45,
  //   },
  //   dt: 1715586235,
  //   sys: {
  //     type: 1,
  //     id: 9308,
  //     country: 'VN',
  //     sunrise: 1715552463,
  //     sunset: 1715599646,
  //   },
  //   timezone: 25200,
  //   id: 1570565,
  //   name: 'Phu Huu',
  //   cod: 200,
  // };

  // return result;
};

export const fetchExtendedForecastData = async (
  city: string | { lat: number; lng: number }
) => {
  let url = `${baseUrl}/forecast/daily?q=${city}&appid=${process.env.REACT_APP_WEATHER_API_KEY}`;

  if (typeof city === 'object') {
    url = `${baseUrl}/forecast/daily?lat=${city.lat}&lon=${city.lng}&appid=${process.env.REACT_APP_WEATHER_API_KEY}`;
  }

  // return await (await fetch(url)).json();
  const result = {
    city: {
      id: 1570565,
      name: 'Phu Huu',
      coord: {
        lon: 105.5408,
        lat: 21.0149,
      },
      country: 'VN',
      population: 0,
      timezone: 25200,
    },
    cod: '200',
    message: 10.2497173,
    cnt: 7,
    list: [
      {
        dt: 1715572800,
        sunrise: 1715552463,
        sunset: 1715599646,
        temp: {
          day: 302.78,
          min: 297.67,
          max: 303.47,
          night: 299.47,
          eve: 303.47,
          morn: 297.79,
        },
        feels_like: {
          day: 305.66,
          night: 299.47,
          eve: 306.39,
          morn: 298.66,
        },
        pressure: 1012,
        humidity: 62,
        weather: [
          {
            id: 501,
            main: 'Rain',
            description: 'moderate rain',
            icon: '10d',
          },
        ],
        speed: 2.95,
        deg: 23,
        gust: 5.87,
        clouds: 71,
        pop: 1,
        rain: 10.99,
      },
      {
        dt: 1715659200,
        sunrise: 1715638839,
        sunset: 1715686072,
        temp: {
          day: 303.4,
          min: 298.09,
          max: 304.95,
          night: 298.09,
          eve: 302.56,
          morn: 298.15,
        },
        feels_like: {
          day: 307.82,
          night: 299.02,
          eve: 307.44,
          morn: 299.03,
        },
        pressure: 1012,
        humidity: 66,
        weather: [
          {
            id: 500,
            main: 'Rain',
            description: 'light rain',
            icon: '10d',
          },
        ],
        speed: 4.97,
        deg: 125,
        gust: 8.51,
        clouds: 71,
        pop: 0.59,
        rain: 3.95,
      },
      {
        dt: 1715745600,
        sunrise: 1715725215,
        sunset: 1715772498,
        temp: {
          day: 303.39,
          min: 297.7,
          max: 304.54,
          night: 298.21,
          eve: 302.11,
          morn: 297.74,
        },
        feels_like: {
          day: 308.28,
          night: 299.2,
          eve: 307.36,
          morn: 298.71,
        },
        pressure: 1013,
        humidity: 68,
        weather: [
          {
            id: 501,
            main: 'Rain',
            description: 'moderate rain',
            icon: '10d',
          },
        ],
        speed: 3.65,
        deg: 139,
        gust: 8.03,
        clouds: 80,
        pop: 1,
        rain: 25.02,
      },
      {
        dt: 1715832000,
        sunrise: 1715811592,
        sunset: 1715858925,
        temp: {
          day: 300,
          min: 297.73,
          max: 302.58,
          night: 297.73,
          eve: 301.16,
          morn: 297.95,
        },
        feels_like: {
          day: 302.73,
          night: 298.62,
          eve: 305.43,
          morn: 298.86,
        },
        pressure: 1014,
        humidity: 82,
        weather: [
          {
            id: 501,
            main: 'Rain',
            description: 'moderate rain',
            icon: '10d',
          },
        ],
        speed: 4.85,
        deg: 124,
        gust: 8.51,
        clouds: 99,
        pop: 1,
        rain: 12.15,
      },
      {
        dt: 1715918400,
        sunrise: 1715897970,
        sunset: 1715945351,
        temp: {
          day: 300.37,
          min: 297.5,
          max: 304.22,
          night: 298.56,
          eve: 303.59,
          morn: 297.53,
        },
        feels_like: {
          day: 303.94,
          night: 299.64,
          eve: 310.11,
          morn: 298.45,
        },
        pressure: 1011,
        humidity: 85,
        weather: [
          {
            id: 501,
            main: 'Rain',
            description: 'moderate rain',
            icon: '10d',
          },
        ],
        speed: 3.83,
        deg: 130,
        gust: 8.59,
        clouds: 96,
        pop: 0.95,
        rain: 8.22,
      },
      {
        dt: 1716004800,
        sunrise: 1715984349,
        sunset: 1716031778,
        temp: {
          day: 302.25,
          min: 298.28,
          max: 304.38,
          night: 298.96,
          eve: 303.93,
          morn: 298.28,
        },
        feels_like: {
          day: 307.73,
          night: 300.08,
          eve: 310.93,
          morn: 299.33,
        },
        pressure: 1007,
        humidity: 78,
        weather: [
          {
            id: 501,
            main: 'Rain',
            description: 'moderate rain',
            icon: '10d',
          },
        ],
        speed: 3.47,
        deg: 117,
        gust: 8.23,
        clouds: 90,
        pop: 1,
        rain: 17.64,
      },
      {
        dt: 1716091200,
        sunrise: 1716070730,
        sunset: 1716118204,
        temp: {
          day: 299.23,
          min: 297.62,
          max: 303.35,
          night: 297.62,
          eve: 303.35,
          morn: 298.12,
        },
        feels_like: {
          day: 299.23,
          night: 298.55,
          eve: 310.35,
          morn: 299.21,
        },
        pressure: 1005,
        humidity: 94,
        weather: [
          {
            id: 501,
            main: 'Rain',
            description: 'moderate rain',
            icon: '10d',
          },
        ],
        speed: 4,
        deg: 52,
        gust: 8.1,
        clouds: 100,
        pop: 1,
        rain: 25.85,
      },
    ],
  };

  return result;
};
