using System;
using System.Collections.Generic;
using System.Text;

namespace SEOChecker.Services
{
	/// <summary>
	/// Service to perform the SEO check
	/// </summary>
	public interface ISearchService
	{
		/// <summary>
		/// Returns the ranks found (if any)
		/// </summary>
		/// <returns>String of numbers indicating the ranks, e.g. “1, 10, 33”</returns>
		string GetSearchRanks(string keywords, string url);
	}
}
