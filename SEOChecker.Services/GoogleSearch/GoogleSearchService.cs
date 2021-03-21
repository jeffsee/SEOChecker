using System;
using System.Collections.Generic;

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

		public GoogleSearchService(ISearchEngineSearcher searcher, ISearchResultParser parser)
		{
			_searcher = searcher;
			_parser = parser;
		}

		public string GetSearchRanks(string keywords, string url)
		{
			try
			{
				var errors = ValidateSearchInput(keywords, url);

				if (errors.Count == 0)
				{
					string searchResult = _searcher.GetSearchResult(keywords);
					string parsedResult = _parser.ParseSearchResultForRanks(searchResult, url);

					return parsedResult;
				}
				else
				{
					return string.Join(Environment.NewLine, errors);
				}
			}
			catch (Exception ex)
			{
				return string.Format("Error with Google Search results: {0}", ex.Message);
			}
		}

		private List<string> ValidateSearchInput(string keywords, string url)
		{
			List<string> errors = new List<string>();

			if (string.IsNullOrWhiteSpace(keywords))
			{
				errors.Add("Keywords cannot be blank");
			}

			if (string.IsNullOrWhiteSpace(url))
			{
				errors.Add("URL cannot be blank");
			}

			return errors;
		}
	}
}
