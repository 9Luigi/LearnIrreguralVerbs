using LearnIrreguralVerbs.Model;
using System.Text.Json;

namespace LearnIrreguralVerbs.Services
{
	class VerbService
	{

		public async Task<List<IrregularVerb>> LoadVerbsAsync()
		{
			var options = new JsonSerializerOptions
			{
				PropertyNameCaseInsensitive = true,
				ReadCommentHandling = JsonCommentHandling.Skip,
				AllowTrailingCommas = true,
				Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
			};

			string fileName = "irregular_verbs.json";

			using Stream stream = await FileSystem.OpenAppPackageFileAsync(fileName);
			using StreamReader reader = new StreamReader(stream);
			string json = await reader.ReadToEndAsync();

			return JsonSerializer.Deserialize<List<IrregularVerb>>(json, options);
		}
	}
}
