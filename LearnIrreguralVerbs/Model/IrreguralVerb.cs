namespace LearnIrreguralVerbs.Model
{
	public class IrregularVerb
	{
		public string Russian { get; set; }
		public string Forms { get; set; }

		public IrregularVerb(string russian, string forms)
		{
			Russian = russian;
			Forms = forms;
		}
	}
}
