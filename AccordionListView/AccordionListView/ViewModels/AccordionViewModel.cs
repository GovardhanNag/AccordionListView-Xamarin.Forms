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
            ObservableCollection<City> WDCity = new ObservableCollection<City>()
            {
                new City(){ CityName = "Barberton", CityCode = "330" },
                new City(){ CityName = "Kent", CityCode = "253" },
                new City(){ CityName = "Woodland", CityCode = "530" }
            };

            ObservableCollection<City> NYCity = new ObservableCollection<City>()
            {
                new City(){ CityName = "Adams", CityCode = "608" },
                new City(){ CityName = "Otego", CityCode = "607" },
                new City(){ CityName = "Milton", CityCode = "289" }
            };
            
            ObservableCollection<City> KECity = new ObservableCollection<City>()
            {
                new City(){ CityName = "Albany", CityCode = "518" },
                new City(){ CityName = "Augusta", CityCode = "762" },
                new City(){ CityName = "Benton", CityCode = "501" }
            };

            ObservableCollection<City> TBCity = new ObservableCollection<City>()
            {
                new City(){ CityName = "Baiba", CityCode = "123" },
                new City(){ CityName = "Chaba",CityCode = "121" },
                new City(){ CityName = "Lian", CityCode = "231" }
            };

            ObservableCollection<City> XJCity = new ObservableCollection<City>()
            {
                new City(){ CityName = "Urumqi", CityCode = "991" },
                new City(){ CityName = "Karamay",CityCode = "990" },
                new City(){ CityName = "Tumxuk", CityCode = "998" }
            };

            CustomObservableCollection<State> USAStates = new CustomObservableCollection<State>()
            {
                new State(){ StateName = "Washington", StateCode = "206", IsCChildrenVisible = false, Cities=WDCity },
                new State(){ StateName = "New York", StateCode = "718", IsCChildrenVisible = false, Cities=NYCity  },
                new State(){ StateName = "Kentucky", StateCode = "859", IsCChildrenVisible = false, Cities=KECity }
            };

            CustomObservableCollection<State> ChinaStates = new CustomObservableCollection<State>()
            {
                new State(){ StateName = "Tibet", StateCode = "86", IsCChildrenVisible = false, Cities =TBCity  },
                new State(){ StateName = "Xinjiang", StateCode = "993", IsCChildrenVisible = false, Cities=XJCity  },
                new State(){ StateName = "Shanghai", StateCode = "21", IsCChildrenVisible = false, }
            };

            CustomObservableCollection<State> RussiaStates = new CustomObservableCollection<State>()
            {
                new State(){ StateName = "Moscow", StateCode = "495", IsCChildrenVisible = false },
                new State(){ StateName = "St. Peterburg", StateCode = "727", IsCChildrenVisible = false },
                new State(){ StateName = "Kazan", StateCode = "843", IsCChildrenVisible = false, }
            };

            countries = new CustomObservableCollection<Country>()
            {
                new Country(){ CountryName = "United States", CountryCode ="USA", IsChildrenVisible = false, States = USAStates },
                new Country(){ CountryName = "China", CountryCode ="CN", IsChildrenVisible = false, States = ChinaStates },
                new Country(){ CountryName = "Russia", CountryCode ="RUS", IsChildrenVisible = false, States = RussiaStates },
            };
        }

        public void ShowStates(string countryName)
        {
            if (countryName != null)
            {
                Country country = Countries.SingleOrDefault(c => c.CountryName == countryName);
                country.IsChildrenVisible = !country.IsChildrenVisible;
                country.ChildrenRowHeightRequest = 0;
                Countries.ReportItemChange(country);
            }
        }

        public void ShowCities(State state)
        {
            if (state != null && state.Cities != null)
            {
                Country country = Countries.SingleOrDefault(c => c.States.SingleOrDefault(ci => ci.StateName == state.StateName) == state);
                state.IsCChildrenVisible = !state.IsCChildrenVisible;
                if (state.IsCChildrenVisible)
                    country.ChildrenRowHeightRequest = state.Cities.Count;
                else
                    country.ChildrenRowHeightRequest = 0;
                //country.Cities.SingleOrDefault(ci => ci.StateName == city.StateName).IsCChildrenVisible=!city.IsCChildrenVisible;
                //country.IsChildrenVisible = !country.IsChildrenVisible;
                Countries.ReportItemChange(country);
            }
        }
    }
}
