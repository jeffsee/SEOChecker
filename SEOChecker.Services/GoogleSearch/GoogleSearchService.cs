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

		/// <summary>
		/// Constructor
		/// </summary>
		public GoogleSearchService()
		{
			_searcher = new GoogleSearcher();
			_parser = new GoogleParser();
		}

		/// <summary>
		/// Constructor passing in the search and parse services, primarily for unit testing purposes
		/// </summary>
		/// <param name="searcher"></param>
		/// <param name="parser"></param>
		public GoogleSearchService(ISearchEngineSearcher searcher, ISearchResultParser parser)
		{
			_searcher = searcher;
			_parser = parser;
		}

		/// <summary>
		/// Performs a Google search using the given keywords, then returns the ranks that contain the given URL
		/// </summary>
		/// <param name="keywords">The keywords to search for</param>
		/// <param name="url">The URL to find the ranks of</param>
		/// <returns>String of numbers indicating the ranks, e.g. “1, 10, 33” - or a "0" if none found. Any error encountered is also returned here</returns>
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

		/// <summary>
		/// Performs the required validations on the inputs
		/// Currently checks that neither keywords or url are blank
		/// Possible improvements - ensure that the URL is a URL (if that is something required?) using a regex
		/// </summary>
		/// <param name="keywords">The keywords to validate</param>
		/// <param name="url">The url to validate</param>
		/// <returns>A list of errors encountered</returns>
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
