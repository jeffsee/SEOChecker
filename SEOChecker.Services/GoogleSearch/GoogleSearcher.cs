using System.Net;
using System.Web;

namespace SEOChecker.Services.GoogleSearch
{
	public class GoogleSearcher : ISearchEngineSearcher
	{
		private const string searchString = @"https://www.google.com.au/search?num=100&q={0}";

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
