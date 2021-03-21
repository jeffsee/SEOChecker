namespace SEOChecker.Services
{
	/// <summary>
	/// Service to perform the search engine query
	/// </summary>
	public interface ISearchEngineSearcher
	{
		/// <summary>
		/// Gets the search result
		/// </summary>
		/// <param name="keywords">The keywords to use for the Search</param>
		/// <returns>The response to the given search as a string</returns>
		string GetSearchResult(string keywords);
	}
}
