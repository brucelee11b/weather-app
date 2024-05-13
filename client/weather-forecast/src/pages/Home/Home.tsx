import { CurrentWeather } from 'components/CurrentWeather';
import { Forecast } from 'components/Forecast';
import { Header } from 'components/Header';
import { Search } from 'components/Search';

const Home = () => {
  return (
    <>
      <Header />
      <Search />
      <CurrentWeather />
      <Forecast />
    </>
  );
};

export { Home };
