using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace SEOChecker.Services.GoogleSearch
{
	public class GoogleParser : ISearchResultParser
	{
		private const string RegexPattern = "(<div class=\"BNeawe UPmit AP7Wnd\">)(?<searchResult>.*?)(</div>)";

		public string ParseSearchResultForRanks(string searchResults, string url)
		{
			List<int> searchRanks = new List<int>();
			int i = 1;
			MatchCollection results = Regex.Matches(searchResults, RegexPattern);

			foreach (Match result in results)
			{
				string resultUrl = result.Groups["searchResult"].Value.Trim();
				
				if (resultUrl.Contains(url))
				{
					searchRanks.Add(i);
				}

				i++;
			}

			if (searchRanks.Count == 0)
			{
				return "0";
			}
			else
			{
				return string.Join(", ", searchRanks.Select(sr => sr.ToString()).ToArray());
			}
		}
	}
}
