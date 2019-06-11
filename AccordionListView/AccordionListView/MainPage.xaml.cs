using AccordionListView.Models;
using AccordionListView.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AccordionListView
{
    public partial class MainPage : ContentPage
    {
        public string oldCountry { get; set; }
        public City oldCity { get; set; }
        AccordionViewModel viewModel;
        public MainPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new AccordionViewModel();
            NavigationPage.SetHasNavigationBar(this, true);
        }

        void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            ListView listView = sender as ListView;
            listView.SelectedItem = null;
        }

        async void Handle_Tapped(object sender, EventArgs e)
        {
            Image image = sender as Image;
            var source = image.Source as FileImageSource;
            if (source != null && source.File != "rightarrow.png")
            {
                await image.RotateTo(180);
                Grid grid = image.Parent as Grid;
                Label label = grid.Children[0] as Label;
                if (oldCountry != label.Text)
                {
                    viewModel.ShowCities(oldCountry);
                    viewModel.ShowCities(label.Text);
                    oldCountry = label.Text;
                }
                else
                {
                    viewModel.ShowCities(label.Text);
                    oldCountry = null;
                }
            }
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Image image = sender as Image;
            var source = image.Source as FileImageSource;
            if (source != null && source.File != "rightarrow.png")
            {
                await image.RotateTo(180);
                Grid grid = image.Parent as Grid;
                Label label = grid.Children[0] as Label;
                City city = (City)label.BindingContext;
                if (oldCity != city)
                {
                    viewModel.ShowStates(oldCity);
                    viewModel.ShowStates(city);
                    oldCity = city;
                }
                else
                {
                    viewModel.ShowStates(city);
                    oldCity = null;
                }
            }
        }
    }
}
