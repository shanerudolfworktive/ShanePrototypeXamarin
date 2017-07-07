using System;
using System.Collections.Generic;

using Xamarin.Forms;
using ShanePrototypeXamarin.Services;
using ShanePrototypeXamarin.Modals;

namespace ShanePrototypeXamarin.Pages
{
    public partial class MovieDetailsPage : ContentPage
    {
		private MovieListService _movieService = new MovieListService();
        private MovieModal _incomingMovieModal;

        public MovieDetailsPage(MovieModal movie)
        {
			if (movie == null)
				throw new ArgumentNullException(nameof(movie));

			_incomingMovieModal = movie;
            InitializeComponent();
        }

		protected override async void OnAppearing()
		{
            BindingContext = await _movieService.GetMovieDetails(_incomingMovieModal.Title);

			base.OnAppearing();
		}
    }
}
