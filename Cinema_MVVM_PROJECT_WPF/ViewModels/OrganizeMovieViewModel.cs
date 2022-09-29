using Cinema_MVVM_PROJECT_WPF.Commands;
using Cinema_MVVM_PROJECT_WPF.Models;
using Cinema_MVVM_PROJECT_WPF.Views.UserControls;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Cinema_MVVM_PROJECT_WPF.ViewModels
{
    public class OrganizeMovieViewModel : BaseViewModel
    {

        public ComboBox ComboBox { get; set; }
        public WrapPanel WrapPanel { get; set; }
        public DatePicker DatePicker { get; set; }

        public TimePicker TimePicker { get; set; }

        public RelayCommand PlusCommand { get; set; }

        public RelayCommand MinusCommand { get; set; }

        private int count;

        public int Count
        {
            get { return count; }
            set { count = value; OnPropertyChanged(); }
        }

        public TextBox PriceTxtBox { get; set; }

        private double price;

        public double Price
        {
            get { return price; }
            set { price = value; OnPropertyChanged(); }
        }

        public ObservableCollection<Movie> Movies { get; set; }
        public RelayCommand DoneCommand { get; set; }

        public RelayCommand BackCommand { get; set; }

        public RelayCommand GetMoviesCommand { get; set; }
        private ObservableCollection<Movie> GetMovies()
        {
            foreach (var item in WrapPanel.Children)
            {
                if (item is SingleMovieForShowUC uC)
                {
                    Movie movie = new Movie();
                    movie.Name = uC.title_label.Content.ToString();
                    movie.Genre = uC.genre_label.Content.ToString();
                    movie.Rating = uC.rating_label.Content.ToString();
                    movie.ImagePath = uC.image.Source.ToString();
                    Movies.Add(movie);
                }
            }
            return Movies;
        }
        public OrganizeMovieViewModel()
        {
            Movies = new ObservableCollection<Movie>();
            BackPage = App.MyGrid.Children[0];
            BackCommand = new RelayCommand(c =>
            {
                App.MyGrid.Children.RemoveAt(0);
                App.MyGrid.Children.Add(BackPage);
            });


            GetMoviesCommand = new RelayCommand(d =>
            {

                if (WrapPanel.Children.Count != 0)
                {
                    Movies = GetMovies();
                    MessageBox.Show("Movies successfully added\nCheck movie box again!");
                }
                else
                {
                    MessageBox.Show("No movies exist in movie list!");
                }

            });

        }

    }
}
