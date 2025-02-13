using LearnIrreguralVerbs.Services;

namespace LearnIrreguralVerbs
{
	public partial class MainPage : ContentPage
	{
		private readonly VerbService _verbService = new();
		public MainPage()
		{
			InitializeComponent();
			LoadData();
		}
		private async void LoadData()
		{
			var verbs = await _verbService.LoadVerbsAsync();
			VerbsListView.ItemsSource = verbs;
		}
	}

}
