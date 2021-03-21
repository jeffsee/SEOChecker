using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SEOChecker.Services;
using SEOChecker.ViewModels;

namespace SEOChecker.Tests.ViewModel
{
	[TestClass]
	public class SearchViewModelTests
	{
		[TestMethod]
		public void SearchViewModel_SearchServicePopualtesSearchResult()
		{
			// Arrange
			var service = new Mock<ISearchService>();
			service.Setup(s => s.GetSearchRanks(It.IsAny<string>(), It.IsAny<string>())).Returns("Test Search Results");
			var viewModel = new SearchViewModel(service.Object);

			// Act
			viewModel.RunSearch();

			// Assert
			Assert.AreEqual("Test Search Results", viewModel.SearchResult);
		}
	}
}
