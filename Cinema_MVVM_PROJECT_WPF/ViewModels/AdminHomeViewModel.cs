using Cinema_MVVM_PROJECT_WPF.Commands;
using Cinema_MVVM_PROJECT_WPF.Views.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Cinema_MVVM_PROJECT_WPF.ViewModels
{
    public class AdminHomeViewModel : BaseViewModel
    {
        
        public RelayCommand BackCommand { get; set; }

        public RelayCommand SearchMoviesCommand { get; set; }

        public RelayCommand ShowMoviesCommand { get; set; }

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
                view.DataContext=viewModel;
                App.MyGrid.Children.RemoveAt(0);
                App.MyGrid.Children.Add(view);
            });

            ShowMoviesCommand = new RelayCommand(c =>
            {
                var viewModel = new ShowMoviesViewModel();
                ShowView.DataContext = viewModel;
                App.MyGrid.Children.RemoveAt(0);
                App.MyGrid.Children.Add(ShowView);
            });
        }

       

       
    }
}
