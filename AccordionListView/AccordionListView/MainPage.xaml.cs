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
        public State oldState { get; set; }
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
                string newCountry = label.Text;
                if (oldCountry != newCountry)
                {
                    viewModel.ShowStates(oldCountry);
                    viewModel.ShowStates(newCountry);
                    oldCountry = newCountry;
                }
                else
                {
                    viewModel.ShowStates(newCountry);
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
                State state = (State)label.BindingContext;
                if (oldState != state)
                {
                    viewModel.ShowCities(oldState);
                    viewModel.ShowCities(state);
                    oldState = state;
                }
                else
                {
                    viewModel.ShowCities(state);
                    oldState = null;
                }
            }
        }
    }
}
