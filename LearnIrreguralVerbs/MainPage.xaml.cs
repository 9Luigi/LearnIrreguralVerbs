using System;
using LearnIrreguralVerbs.Model;
using Microsoft.Maui.Controls;

namespace LearnIrreguralVerbs
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

		private readonly List<IrregularVerb> _verbs = new()
		{
			new IrregularVerb("идти", "go went gone"),
			new IrregularVerb("делать", "do did done"),
			new IrregularVerb("быть", "be was/were been"),
			new IrregularVerb("видеть", "see saw seen")
		};

		private readonly Random _random = new Random();
		private string _currentCorrectAnswer;

		// 'New verb' button handler
		private void OnNewVerbClicked(object sender, EventArgs e)
		{
			var randomIndex = _random.Next(_verbs.Count);
			var verb = _verbs[randomIndex];

			VerbLabel.Text = verb.Russian;
			_currentCorrectAnswer = verb.Forms;

			InputEntry.Text = string.Empty;
			ResultLabel.IsVisible = false;
		}

		// 'Check' button handler
		private void OnCheckAnswerClicked(object sender, EventArgs e)
		{
			string userInput = InputEntry.Text?.Trim();
			if (string.IsNullOrEmpty(userInput))
			{
				ResultLabel.Text = "Enter answer";
				ResultLabel.TextColor = Colors.Red;
			}
			else if (userInput.Equals(_currentCorrectAnswer, StringComparison.OrdinalIgnoreCase))
			{
				ResultLabel.Text = "Correct!";
				ResultLabel.TextColor = Colors.Green;
			}
			else
			{
				ResultLabel.Text = "Incorrect!";
				ResultLabel.TextColor = Colors.Red;
			}

			ResultLabel.IsVisible = true;
		}
	}
}
