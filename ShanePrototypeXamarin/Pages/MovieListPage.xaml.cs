using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Collections;
using System.Threading.Tasks;
using System.Linq;
using ShanePrototypeXamarin.Services;
using ShanePrototypeXamarin.Modals;
namespace ShanePrototypeXamarin
{
    public partial class MovieListPage : ContentPage
    {
        private MovieListService _movieListService = new MovieListService();

        private BindableProperty IsSearchingProperty = BindableProperty.Create("IsSearching", typeof(bool), typeof(MovieListPage), false);
		public bool IsSearching
		{
			get { return (bool)GetValue(IsSearchingProperty); }
			set { SetValue(IsSearchingProperty, value); }
		}

        public MovieListPage()
        {
            BindingContext = this;
            InitializeComponent();
        }

        async void OnMovieSelected(object sender, SelectedItemChangedEventArgs e){
            if (e.SelectedItem == null) return;

            await Navigation.PushAsync(new Pages.MovieDetailsPage(e.SelectedItem as MovieModal));
        }

		async void OnTextChanged(object sender, Xamarin.Forms.TextChangedEventArgs e)
		{
            IsSearching = true;
            var movieModals = await _movieListService.FindMoviesByActorName(e.NewTextValue);
            IsSearching = false;
			moviesListView.ItemsSource = movieModals;
            moviesListView.IsVisible = movieModals.Any();
            notFoundLabel.IsVisible = !movieModals.Any();
		}
    }
}
