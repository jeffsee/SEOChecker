using SEOChecker.Services;
using SEOChecker.Services.GoogleSearch;
using System;
using System.ComponentModel;
using System.Windows.Input;

namespace SEOChecker.ViewModels
{
	/// <summary>
	/// View Model for the search
	/// </summary>
	public class SearchViewModel : INotifyPropertyChanged, IDataErrorInfo
	{
		private ISearchService searchService;
		public ICommand SearchCommand { get; set; }

		public event PropertyChangedEventHandler PropertyChanged;

		#region Constructors

		/// <summary>
		/// Constructor - passing in a new instance of the Google Search Service
		/// </summary>
		public SearchViewModel(): this(new GoogleSearchService()) { }

		/// <summary>
		/// Constructor - accepts a search service (primarily to allow for mocking for unit testing)
		/// Sets up the default values for the search and the commands to bind
		/// </summary>
		/// <param name="search"></param>
		public SearchViewModel(ISearchService search)
		{
			keywords = "conveyancing software";
			url = "www.smokeball.com.au";

			SearchCommand = new RelayCommand(p => CanRunSearch(), p => RunSearch());

			searchService = search;
		}

		#endregion

		#region Properties
		private string keywords;
		public string Keywords
		{
			get { return keywords; }
			set
			{
				keywords = value;
				NotifyPropertyChanged("Keywords");
			}
		}

		private string url;
		public string URL
		{
			get { return url; }
			set
			{
				url = value;
				NotifyPropertyChanged("URL");
			}
		}

		private string searchResult;
		public string SearchResult
		{
			get { return searchResult; }
			set
			{
				searchResult = value;
				NotifyPropertyChanged("SearchResult");
			}
		}
		#endregion

		public string Error => throw new NotImplementedException();

		public string this[string columnName]
		{
			get
			{
				string errorMessage = String.Empty;

				switch (columnName)
				{
					case "Keywords":
						if (string.IsNullOrWhiteSpace(keywords)) { errorMessage = "Keywords cannot be blank"; }
						break;

					case "URL":
						if (string.IsNullOrWhiteSpace(url)) { errorMessage = "URL cannot be blank"; }
						break;

					default:
						throw new ApplicationException("Unknown property");
				}

				return errorMessage;
			}
		}

		private void NotifyPropertyChanged(string propertyName = "")
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}

		/// <summary>
		/// Validation to enable/disable search button as required
		/// </summary>
		/// <returns></returns>
		public bool CanRunSearch()
		{
			if (string.IsNullOrEmpty(keywords) || string.IsNullOrEmpty(url))
			{
				return false;
			}
			else
			{
				return true;
			}
		}

		/// <summary>
		/// Runs the search and populates the SearchResult property
		/// </summary>
		public void RunSearch()
		{
			SearchResult = "";
			Mouse.OverrideCursor = Cursors.Wait;

			SearchResult = searchService.GetSearchRanks(Keywords, URL);

			Mouse.OverrideCursor = Cursors.Arrow;
		}
	}
}
