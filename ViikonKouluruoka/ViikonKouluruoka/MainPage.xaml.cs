using Xamarin.Forms;

namespace ViikonKouluruoka
{
    public partial class MainPage : TabbedPage
    {
        public MainPage()
		{
			InitializeComponent();

            ItemsSource = SchoolDataModel.All;
        }
	}
}
