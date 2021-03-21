using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace SEOChecker.Services.GoogleSearch
{
	/// <summary>
	/// Service to parse the given Google search results
	/// </summary>
	public class GoogleParser : ISearchResultParser
	{
		private const string RegexPattern = "(<div class=\"BNeawe UPmit AP7Wnd\">)(?<searchResult>.*?)(</div>)";

		/// <summary>
		/// Parses the given Google search results into and returns the ranks of the given URL
		/// </summary>
		/// <param name="searchResults">The Google search results to parse</param>
		/// <param name="url">The url to return the ranks of</param>
		/// <returns>String of numbers indicating the ranks, e.g. “1, 10, 33” - or a "0" if none found.</returns>
		public string ParseSearchResultForRanks(string searchResults, string url)
		{
			if (string.IsNullOrEmpty(url))
			{
				return "0";
			}

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
