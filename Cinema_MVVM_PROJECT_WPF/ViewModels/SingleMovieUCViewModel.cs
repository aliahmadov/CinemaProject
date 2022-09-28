using Cinema_MVVM_PROJECT_WPF.Commands;
using Cinema_MVVM_PROJECT_WPF.Models;
using Cinema_MVVM_PROJECT_WPF.Views.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Cinema_MVVM_PROJECT_WPF.ViewModels
{
    public class SingleMovieUCViewModel : BaseViewModel
    {
        public WrapPanel ShowMoviesWrapPanel { get; set; }

        private Movie movie;

        public Movie Movie
        {
            get { return movie; }
            set { movie = value; OnPropertyChanged(); }
        }

        public RelayCommand AddMovieCommand { get; set; }

        public SingleMovieUCViewModel()
        {
            AddMovieCommand = new RelayCommand(c =>
            {
                var singleMovieForShowUC = new SingleMovieForShowUC();
                var viewModel = new SingleMovieForShowViewModel();
                singleMovieForShowUC.DataContext = viewModel;

                viewModel.Movie = Movie;

                singleMovieForShowUC.Height = 350;
                singleMovieForShowUC.Width = 250;
                singleMovieForShowUC.Margin = new System.Windows.Thickness(10,40,10,10);
                ShowMoviesWrapPanel.Children.Add(singleMovieForShowUC);

                MessageBox.Show($"{Movie.Name} added successfully");


            });
        }

    }
}
