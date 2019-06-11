using AccordionListView.Custom;
using AccordionListView.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace AccordionListView.ViewModels
{
    public class AccordionViewModel : BaseViewModel
    {
        private CustomObservableCollection<Country> countries;
        public CustomObservableCollection<Country> Countries
        {
            get => countries;
            set => SetProperty(ref countries, value);
        }

        public AccordionViewModel()
        {
            ObservableCollection<State> WDCStates = new ObservableCollection<State>()
            {
                new State(){ StateName = "Washington States", StateCode = "WDC" },
                new State(){ StateName = "New States", StateCode = "NY" },
                new State(){ StateName = "Los States", StateCode = "LA" }
            };

            ObservableCollection<State> NYStates = new ObservableCollection<State>()
            {
                new State(){ StateName = "Washington States", StateCode = "WDC" },
                new State(){ StateName = "New States", StateCode = "NY" },
                new State(){ StateName = "Los States", StateCode = "LA" }
            };

            ObservableCollection<State> BJStates = new ObservableCollection<State>()
            {
                new State(){ StateName = "States DC", StateCode = "WDC" },
                new State(){ StateName = "States York",StateCode = "NY" },
                new State(){ StateName = "States Angeles", StateCode = "LA" }
            };

            ObservableCollection<State> SGStates = new ObservableCollection<State>()
            {
                new State(){ StateName = "States DC", StateCode = "WDC" },
                new State(){ StateName = "States York",StateCode = "NY" },
                new State(){ StateName = "States Angeles", StateCode = "LA" }
            };

            CustomObservableCollection<City> USACities = new CustomObservableCollection<City>()
            {
                new City(){ CityName = "Washington DC", CityCode = "WDC", IsCChildrenVisible = false, States=WDCStates },
                new City(){ CityName = "New York", CityCode = "NY", IsCChildrenVisible = false, States=NYStates  },
                new City(){ CityName = "Los Angeles", CityCode = "LA", IsCChildrenVisible = false, States=SGStates }
            };

            CustomObservableCollection<City> ChinaCities = new CustomObservableCollection<City>()
            {
                new City(){ CityName = "Beijing", CityCode = "BJ", IsCChildrenVisible = false, States=BJStates  },
                new City(){ CityName = "Shanghai", CityCode = "SG", IsCChildrenVisible = false, States=SGStates  },
                new City(){ CityName = "Shenzhen", CityCode = "SZ", IsCChildrenVisible = false, }
            };

            CustomObservableCollection<City> RussiaCities = new CustomObservableCollection<City>()
            {
                new City(){ CityName = "Moscow", CityCode = "MC", IsCChildrenVisible = false, States=SGStates },
                new City(){ CityName = "St. Peterburg", CityCode = "PB", IsCChildrenVisible = false, States=SGStates },
                new City(){ CityName = "Kazan", CityCode = "KZ", IsCChildrenVisible = false, }
            };

            countries = new CustomObservableCollection<Country>()
            {
                new Country(){ CountryName = "United States", CountryCode ="USA", IsChildrenVisible = false, Cities = USACities },
                new Country(){ CountryName = "China", CountryCode ="CN", IsChildrenVisible = false, Cities = ChinaCities },
                new Country(){ CountryName = "Russia", CountryCode ="RUS", IsChildrenVisible = false, Cities = RussiaCities },
            };
        }

        public void ShowCities(string countryName)
        {
            if (countryName != null)
            {
                Country country = Countries.SingleOrDefault(c => c.CountryName == countryName);
                country.IsChildrenVisible = !country.IsChildrenVisible;
                country.ChildrenRowHeightRequest = 0;
                Countries.ReportItemChange(country);
            }
        }

        public void ShowStates(City city)
        {
            if (city != null && city.States != null)
            {
                Country country = Countries.SingleOrDefault(c => c.Cities.SingleOrDefault(ci => ci.CityName == city.CityName) == city);
                city.IsCChildrenVisible = !city.IsCChildrenVisible;
                if (city.IsCChildrenVisible)
                    country.ChildrenRowHeightRequest = city.States.Count;
                else
                    country.ChildrenRowHeightRequest = 0;
                //country.Cities.SingleOrDefault(ci => ci.CityName == city.CityName).IsCChildrenVisible=!city.IsCChildrenVisible;
                //country.IsChildrenVisible = !country.IsChildrenVisible;
                Countries.ReportItemChange(country);
            }
        }
    }
}
