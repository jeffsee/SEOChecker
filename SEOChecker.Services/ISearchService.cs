namespace SEOChecker.Services
{
	/// <summary>
	/// Service to perform the SEO check
	/// </summary>
	public interface ISearchService
	{
		/// <summary>
		/// Performs a search using the given keywords, then returns the ranks that contain the given URL
		/// </summary>
		/// <param name="keywords">The keywords to search for</param>
		/// <param name="url">The URL to find the ranks of</param>
		/// <returns>String of numbers indicating the ranks, e.g. “1, 10, 33” - or a "0" if none found. Any error encountered is also returned here</returns>
		string GetSearchRanks(string keywords, string url);
	}
}
