using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SEOChecker.Services.GoogleSearch;
using System;

namespace SEOChecker.Services.Tests.GoogleSearch
{
	[TestClass]
	public class GoogleSearchServiceTests
	{
		[TestMethod]
		public void GoogleSearchService_ReturnsError_BlankKeywords()
		{
			// Arrange
			var keywords = "";
			var url = "www.smokeball.com.au";
			var service = new GoogleSearchService();

			// Act
			var result = service.GetSearchRanks(keywords, url);

			// Assert
			Assert.AreEqual("Keywords cannot be blank", result);
		}

		[TestMethod]
		public void GoogleSearchService_ReturnsError_BlankURL()
		{
			// Arrange
			var keywords = "conveyancing software";
			var url = "";
			var service = new GoogleSearchService();

			// Act
			var result = service.GetSearchRanks(keywords, url);

			// Assert
			Assert.AreEqual("URL cannot be blank", result);
		}

		[TestMethod]
		public void GoogleSearchService_ReturnsError_BlankKeywordsAndURL()
		{
			// Arrange
			var keywords = "";
			var url = "";
			var service = new GoogleSearchService();

			// Act
			var result = service.GetSearchRanks(keywords, url);

			// Assert
			Assert.AreEqual("Keywords cannot be blank" + Environment.NewLine + "URL cannot be blank", result);
		}

		[TestMethod]
		public void GoogleSearchService_ReturnsOK_ValidData()
		{
			// Arrange
			var keywords = "conveyancing software";
			var url = "www.smokeball.com.au";

			var searcher = new Mock<ISearchEngineSearcher>();
			searcher.Setup(s => s.GetSearchResult(It.IsAny<string>())).Returns(TestHelper.GetTextFromFile("GoogleSearchResultForConveyancingSoftware.txt"));

			var parser = new GoogleParser();

			var service = new GoogleSearchService(searcher.Object, parser);

			// Act
			var result = service.GetSearchRanks(keywords, url);

			// Assert
			Assert.AreEqual("3", result);
		}
	}
}
