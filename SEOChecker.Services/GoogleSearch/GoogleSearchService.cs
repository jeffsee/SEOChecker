using System;

namespace SEOChecker.Services.GoogleSearch
{
	/// <summary>
	/// Google Search Service to check Google for the search engine rankings of the url for the given keywords
	/// </summary>
	public class GoogleSearchService : ISearchService
	{
		private ISearchEngineSearcher _searcher;
		private ISearchResultParser _parser;

		public GoogleSearchService()
		{
			_searcher = new GoogleSearcher();
			_parser = new GoogleParser();
		}

		public string GetSearchRanks(string keywords, string url)
		{
			try
			{
				string searchResult = _searcher.GetSearchResult(keywords);
				string parsedResult = _parser.ParseSearchResultForRanks(searchResult, url);

				return parsedResult;
			}
			catch (Exception ex)
			{
				return string.Format("Error with Google Search results: {0}", ex.Message);
			}
		}
	}
}
