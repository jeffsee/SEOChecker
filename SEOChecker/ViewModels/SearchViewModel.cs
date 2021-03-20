using SEOChecker.Services.GoogleSearch;
using System;
using System.ComponentModel;
using System.Windows.Input;

namespace SEOChecker.ViewModels
{
	public class SearchViewModel : INotifyPropertyChanged
	{
		public SearchViewModel()
		{
			keywords = "conveyancing software";
			url = "www.smokeball.com.au";

			SearchCommand = new RelayCommand(p => true, p => RunSearch());
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

		public ICommand SearchCommand { get; set; }

		public event PropertyChangedEventHandler PropertyChanged;

		private void NotifyPropertyChanged(string propertyName = "")
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}

		private void RunSearch()
		{
			SearchResult = "";
			Mouse.OverrideCursor = Cursors.Wait;

			var searchService = new GoogleSearchService();

			SearchResult = searchService.GetSearchRanks(Keywords, URL);
			Mouse.OverrideCursor = Cursors.Arrow;
		}
	}
}
