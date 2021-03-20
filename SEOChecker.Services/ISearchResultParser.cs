namespace SEOChecker.Services
{
	public interface ISearchResultParser
	{
		string ParseSearchResultForRanks(string searchResults, string url);
	}
}
