using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace ShanePrototypeXamarin
{
    public partial class MovieListPage : ContentPage
    {
        public MovieListPage()
        {
            InitializeComponent();
        }

        async void OnMovieSelected(object sender, SelectedItemChangedEventArgs e){
            await DisplayAlert("Movie Selected", "Movie Selected", "OK");
        }

		async void OnTextChanged(object sender, Xamarin.Forms.TextChangedEventArgs e)
		{
            List<Modals.MovieModal> movieModals = new List<Modals.MovieModal>();
            movieModals.Add(new Modals.MovieModal());
            movieModals.Add(new Modals.MovieModal());
            moviesListView.ItemsSource = movieModals;
		}
    }
}
