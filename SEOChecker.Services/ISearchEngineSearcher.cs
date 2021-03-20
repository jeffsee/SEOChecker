using System;
using System.Collections.Generic;
using System.Text;

namespace SEOChecker.Services
{
	/// <summary>
	/// 
	/// </summary>
	public interface ISearchEngineSearcher
	{
		string GetSearchResult(string keywords);
	}
}
