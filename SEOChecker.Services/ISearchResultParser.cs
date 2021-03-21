namespace SEOChecker.Services
{
	/// <summary>
	/// Service to parse the search results
	/// </summary>
	public interface ISearchResultParser
	{
		/// <summary>
		/// Parses the given search results into and returns the ranks of the given URL
		/// </summary>
		/// <param name="searchResults">The search results to parse</param>
		/// <param name="url">The url to return the ranks of</param>
		/// <returns>String of numbers indicating the ranks, e.g. “1, 10, 33” - or a "0" if none found.</returns>
		string ParseSearchResultForRanks(string searchResults, string url);
	}
}
