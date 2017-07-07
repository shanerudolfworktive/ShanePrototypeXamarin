using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Collections;
using System.Threading.Tasks;
namespace ShanePrototypeXamarin
{
    public partial class MovieListPage : ContentPage
    {
        private Services.MovieListService _movieListService = new Services.MovieListService();

        public MovieListPage()
        {
            InitializeComponent();
        }

        async void OnMovieSelected(object sender, SelectedItemChangedEventArgs e){
            await DisplayAlert("Movie Selected", "Movie Selected", "OK");
        }

		async void OnTextChanged(object sender, Xamarin.Forms.TextChangedEventArgs e)
		{
            var movieModals = await _movieListService.FindMoviesByActorName(e.NewTextValue);
            moviesListView.ItemsSource = movieModals;
		}
    }
}
