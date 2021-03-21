using SEOChecker.Services;
using SEOChecker.Services.GoogleSearch;
using System;
using System.ComponentModel;
using System.Windows.Input;

namespace SEOChecker.ViewModels
{
	public class SearchViewModel : INotifyPropertyChanged
	{
		private ISearchService searchService;
		public ICommand SearchCommand { get; set; }

		public event PropertyChangedEventHandler PropertyChanged;

		public SearchViewModel(): this(new GoogleSearchService()) { }

		public SearchViewModel(ISearchService search)
		{
			keywords = "conveyancing software";
			url = "www.smokeball.com.au";

			SearchCommand = new RelayCommand(p => true, p => RunSearch());

			searchService = search;
		}

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

		private void NotifyPropertyChanged(string propertyName = "")
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}

		public void RunSearch()
		{
			SearchResult = "";
			Mouse.OverrideCursor = Cursors.Wait;

			SearchResult = searchService.GetSearchRanks(Keywords, URL);

			Mouse.OverrideCursor = Cursors.Arrow;
		}
	}
}
