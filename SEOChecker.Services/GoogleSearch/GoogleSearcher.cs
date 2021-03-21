using System.Net;
using System.Web;

namespace SEOChecker.Services.GoogleSearch
{
	/// <summary>
	/// Service to perform the search using Google
	/// </summary>
	public class GoogleSearcher : ISearchEngineSearcher
	{
		private const string searchString = @"https://www.google.com.au/search?num=100&q={0}";

		/// <summary>
		/// Gets the search result from Google
		/// </summary>
		/// <param name="keywords">The keywords to use for the Google Search</param>
		/// <returns>The response to the given google search as a string</returns>
		public string GetSearchResult(string keywords)
		{
			string searchURL = string.Format(searchString, HttpUtility.UrlEncode(keywords.Replace(" ", "+")));

			using (WebClient wc = new WebClient())
			{
				return wc.DownloadString(searchURL);
			}
		}
	}
}
