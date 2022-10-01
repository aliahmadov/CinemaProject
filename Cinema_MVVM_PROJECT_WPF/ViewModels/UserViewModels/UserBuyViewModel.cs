using Cinema_MVVM_PROJECT_WPF.Commands;
using Cinema_MVVM_PROJECT_WPF.Models;
using Microsoft.Web.WebView2.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Cinema_MVVM_PROJECT_WPF.ViewModels.UserViewModels
{
    public class UserBuyViewModel:BaseViewModel
    {

        public Button Button { get; set; }
        public WebView2 WebViewTrailer { get; set; }

        private Movie movie;

        public Movie Movie
        {
            get { return movie; }
            set { movie = value; OnPropertyChanged(); }
        }

        public RelayCommand BuyCommand { get; set; }
        public RelayCommand WatchCommand { get; set; }

        public RelayCommand EndCommand { get; set; }

        public UserBuyViewModel()
        {
            WatchCommand = new RelayCommand(d =>
            {
                Button.Visibility = System.Windows.Visibility.Visible;
                WebViewTrailer.Visibility = System.Windows.Visibility.Visible;
                WebViewTrailer.CoreWebView2.Navigate($"https://www.imdb.com/title/{Movie.VideoID}/");
            });

            EndCommand = new RelayCommand(d =>
            {
                Button.Visibility = System.Windows.Visibility.Hidden;
                WebViewTrailer.CoreWebView2.Navigate($"https://www.microsoft.com");
                WebViewTrailer.Visibility = System.Windows.Visibility.Hidden;
            });

        }

    }
}
