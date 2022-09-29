using Cinema_MVVM_PROJECT_WPF.Commands;
using Cinema_MVVM_PROJECT_WPF.Views.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace Cinema_MVVM_PROJECT_WPF.ViewModels
{
    public class AdminHomeViewModel : BaseViewModel
    {

        public RelayCommand BackCommand { get; set; }

        public RelayCommand SearchMoviesCommand { get; set; }

        public RelayCommand ShowMoviesCommand { get; set; }

        public RelayCommand OrganizeMoviesCommand { get; set; }

        public WrapPanel ShowMoviesWrapPanel { get; set; }
        public AdminHomeViewModel()
        {
            BackPage = App.MyGrid.Children[0];
            var ShowView = new ShowMoviesUC();
            BackCommand = new RelayCommand(c =>
            {

                App.MyGrid.Children.RemoveAt(0);
                App.MyGrid.Children.Add(BackPage);

            });

            SearchMoviesCommand = new RelayCommand(c =>
            {
                var view = new SearchMovieUC();
                var viewModel = new SearchMovieViewModel();
                viewModel.WrapPanel = view.moviesPanel;
                viewModel.TextBox = view.movieTxtb;
                viewModel.ShowMoviesWrapPanel = ShowView.moviesPanel;
                view.DataContext = viewModel;
                App.MyGrid.Children.RemoveAt(0);
                App.MyGrid.Children.Add(view);
            });

            ShowMoviesCommand = new RelayCommand(c =>
            {
                var viewModel = new ShowMoviesViewModel();
                ShowView.DataContext = viewModel;
                viewModel.TextBox = ShowView.movieTxtb;

                viewModel.WrapPanel = ShowView.moviesPanel;
                App.MyGrid.Children.RemoveAt(0);
                App.MyGrid.Children.Add(ShowView);
            });

            OrganizeMoviesCommand = new RelayCommand(c =>
            {
                var timeUC = new TimePickerUC();
                var timeUCviewModel = new TimePickerViewModel();
                timeUC.Width = 50;
                timeUC.DataContext = timeUCviewModel;

                var viewModel = new OrganizeMovieViewModel();
                var view = new OrganizeMovieUC();

                view.timePicker_StackPanel.Children.Add(timeUC);
                var ticketView = new TicketUC();
                var ticketViewModel = new TicketUCViewModel();
                ticketView.DataContext = ticketViewModel;

                view.DataContext = viewModel;

                viewModel.DatePicker = view.datePicker;
                viewModel.PriceTxtBox= view.priceTxtbox;
                viewModel.WrapPanel = ShowView.moviesPanel;
                viewModel.ComboBox = view.movieComboBox;


                viewModel.TicketViewModel = ticketViewModel;
                view.ticket_panel.Children.Add(ticketView);
                App.MyGrid.Children.RemoveAt(0);
                App.MyGrid.Children.Add(view);
            });
        }




    }
}
