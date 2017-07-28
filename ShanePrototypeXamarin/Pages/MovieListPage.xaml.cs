using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Collections;
using System.Threading.Tasks;
using System.Linq;
using ShanePrototypeXamarin.Services;
using ShanePrototypeXamarin.Modals;
using System.Collections.ObjectModel;
namespace ShanePrototypeXamarin
{
    public partial class MovieListPage : ContentPage
    {
        private MovieListService _movieListService = new MovieListService();
        private ObservableCollection<MovieModal> observableMovieModals;
        private String searchedTextForRefreshing;

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

		void OnTextChanged(object sender, Xamarin.Forms.TextChangedEventArgs e)
		{
            searchedTextForRefreshing = e.NewTextValue;
            SearchMovies(searchedTextForRefreshing);
		}

        async void SearchMovies(String searchTitle){
			IsSearching = true;
            var movieModals = await _movieListService.FindMoviesByActorName(searchTitle);
			observableMovieModals = new ObservableCollection<MovieModal>(movieModals);
			IsSearching = false;
			moviesListView.ItemsSource = observableMovieModals;
			moviesListView.IsVisible = observableMovieModals.Any();
			notFoundLabel.IsVisible = !observableMovieModals.Any();
            moviesListView.EndRefresh();
        }

        void Handle_Click_Delete(object sender, System.EventArgs e){
            var menuItem = sender as MenuItem;
            var movieModal = menuItem.CommandParameter as MovieModal;
            observableMovieModals.Remove(movieModal);
        }

		void Handle_Refreshing(object sender, System.EventArgs e)
		{
			SearchMovies(searchedTextForRefreshing);
		}



    }
}
