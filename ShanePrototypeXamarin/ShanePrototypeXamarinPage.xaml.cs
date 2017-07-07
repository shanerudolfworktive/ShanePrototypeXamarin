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
    }
}
