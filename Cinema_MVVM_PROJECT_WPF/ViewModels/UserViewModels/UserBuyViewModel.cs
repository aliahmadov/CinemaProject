using Cinema_MVVM_PROJECT_WPF.Commands;
using Cinema_MVVM_PROJECT_WPF.Models;
using Microsoft.Web.WebView2.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using static System.Resources.ResXFileRef;

namespace Cinema_MVVM_PROJECT_WPF.ViewModels.UserViewModels
{
    public class UserBuyViewModel : BaseViewModel
    {
        public ObservableCollection<Button> Buttons { get; set; }

        public Button Button { get; set; }
        public WebView2 WebViewTrailer { get; set; }

        private Movie movie;

        public Movie Movie
        {
            get { return movie; }
            set { movie = value; OnPropertyChanged(); }
        }

        public StackPanel BuyStackPanel { get; set; }
        public StackPanel SeatStackPanel { get; set; }
        public RelayCommand BuyCommand { get; set; }
        public RelayCommand WatchCommand { get; set; }

        public RelayCommand EndCommand { get; set; }

        public RelayCommand ClickCommand { get; set; }

        private TicketItem ticket;

        public TicketItem Ticket
        {
            get { return ticket; }
            set { ticket = value; OnPropertyChanged(); }
        }

        private void ChangeSeatColor(StackPanel stackPanel)
        {
            foreach (var item in stackPanel.Children)
            {
                if (item is StackPanel sP)
                {
                    foreach (var seat in sP.Children)
                    {
                        if (seat is Button button)
                        {
                            var converter = new System.Windows.Media.BrushConverter();
                            button.Background = (Brush)converter.ConvertFromString("#1F1F2B");
                        }
                    }
                }
            }
        }

        public UserBuyViewModel()
        {
            Buttons = new ObservableCollection<Button>();
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


            BuyCommand = new RelayCommand(d =>
            {
                ChangeSeatColor(SeatStackPanel);
                var converter = new System.Windows.Media.BrushConverter();
                BuyStackPanel.Background = (Brush)converter.ConvertFromString("#0F0F1B");
                SeatStackPanel.Visibility = System.Windows.Visibility.Visible;
            });

            ClickCommand = new RelayCommand(d =>
            {
                var converter = new System.Windows.Media.BrushConverter();
                var button = d as Button;
                var brush_dark = (Brush)converter.ConvertFromString("#FF1F1F2B");
                var brush_white = (Brush)converter.ConvertFromString("#FFFFFF");
                if (button.Background.ToString() == brush_dark.ToString())
                    button.Background = Brushes.White;
                else
                    button.Background = (Brush)converter.ConvertFromString("#1F1F2B");

            });


        }

    }
}
