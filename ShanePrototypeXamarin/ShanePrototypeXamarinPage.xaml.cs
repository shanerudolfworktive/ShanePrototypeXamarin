using Xamarin.Forms;

namespace ShanePrototypeXamarin
{
    public partial class ShanePrototypeXamarinPage : ContentPage
    {
        public ShanePrototypeXamarinPage()
        {
            InitializeComponent();
        }

		async void handleClickQuickUIExperiment(object sender, System.EventArgs e)
		{
            await Navigation.PushAsync(new QuickUIExperimentPage());
		}

		async void handleClickImageExperiment(object sender, System.EventArgs e)
		{
            await Navigation.PushAsync(new ImageExperimentPage());
		}

		async void handleClickMovieList(object sender, System.EventArgs e)
		{
			await Navigation.PushAsync(new MovieListPage());
		}

    }
}
