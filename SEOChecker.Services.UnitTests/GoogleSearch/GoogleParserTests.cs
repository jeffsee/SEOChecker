using Microsoft.VisualStudio.TestTools.UnitTesting;
using SEOChecker.Services.GoogleSearch;

namespace SEOChecker.Services.Tests.GoogleSearch
{
	[TestClass]
	public class GoogleParserTests
	{
		[TestMethod]
		public void ParseSearchResultForRanks_EmptyResult_Returns0()
		{
			// Arrange
			var searchResult = "";
			var url = "www.smokeball.com.au";
			var service = new GoogleParser();

			// Act
			var result = service.ParseSearchResultForRanks(searchResult, url);

			// Assert
			Assert.AreEqual("0", result);
		}

		[TestMethod]
		public void ParseSearchResultForRanks_EmptyURL_Returns0()
		{
			// Arrange
			var searchResult = TestHelper.GetTextFromFile("GoogleSearchResultForConveyancingSoftware.txt");
			var url = "";
			var service = new GoogleParser();

			// Act
			var result = service.ParseSearchResultForRanks(searchResult, url);

			// Assert
			Assert.AreEqual("0", result);
		}

		[TestMethod]
		public void ParseSearchResultForRanks_NoRanksFound_Returns0()
		{
			// Arrange
			var searchResult = TestHelper.GetTextFromFile("GoogleSearchResultForConveyancingSoftware.txt");
			var url = "www.yahoo.com";
			var service = new GoogleParser();

			// Act
			var result = service.ParseSearchResultForRanks(searchResult, url);

			// Assert
			Assert.AreEqual("0", result);
		}

		[TestMethod]
		public void ParseSearchResultForRanks_SingleRankFound_ReturnsCorrectly()
		{
			// Arrange
			var searchResult = TestHelper.GetTextFromFile("GoogleSearchResultForConveyancingSoftware.txt");
			var url = "www.smokeball.com.au";
			var service = new GoogleParser();

			// Act
			var result = service.ParseSearchResultForRanks(searchResult, url);

			// Assert
			Assert.AreEqual("3", result);
		}

		[TestMethod]
		public void ParseSearchResultForRanks_MultipleRanksFound_ReturnsCorrectly()
		{
			// Arrange
			var searchResult = TestHelper.GetTextFromFile("GoogleSearchResultForConveyancingSoftware.txt");
			var url = "globalx.com.au";
			var service = new GoogleParser();

			// Act
			var result = service.ParseSearchResultForRanks(searchResult, url);

			// Assert
			Assert.AreEqual("6, 7", result);
		}

	}
}
