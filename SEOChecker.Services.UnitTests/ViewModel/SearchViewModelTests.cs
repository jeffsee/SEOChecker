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
		public void SearchViewModel_SearchServicePopulatesSearchResult()
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

		[DataTestMethod]
		[DataRow("conveyancing software", "")]
		[DataRow("", "Keywords cannot be blank")]
		public void SearchViewModel_Validation_Keywords(string keywords, string expected)
		{
			// Arrange
			var service = new Mock<ISearchService>();
			service.Setup(s => s.GetSearchRanks(It.IsAny<string>(), It.IsAny<string>())).Returns("Test Search Results");
			var viewModel = new SearchViewModel(service.Object);

			// Act
			viewModel.Keywords = keywords;

			// Assert
			Assert.AreEqual(expected, viewModel["Keywords"]);
		}

		[DataTestMethod]
		[DataRow("www.smokeball.com.au", "")]
		[DataRow("", "URL cannot be blank")]
		public void SearchViewModel_Validation_URL(string url, string expected)
		{
			// Arrange
			var service = new Mock<ISearchService>();
			service.Setup(s => s.GetSearchRanks(It.IsAny<string>(), It.IsAny<string>())).Returns("Test Search Results");
			var viewModel = new SearchViewModel(service.Object);

			// Act
			viewModel.URL = url;

			// Assert
			Assert.AreEqual(expected, viewModel["URL"]);
		}
	}
}
