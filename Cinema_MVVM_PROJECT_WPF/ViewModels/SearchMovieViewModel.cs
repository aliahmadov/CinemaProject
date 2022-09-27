using Cinema_MVVM_PROJECT_WPF.Commands;
using Cinema_MVVM_PROJECT_WPF.Services;
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
    public class SearchMovieViewModel : BaseViewModel
    {
        public WrapPanel WrapPanel { get; set; }

        public TextBox TextBox { get; set; }
        public RelayCommand SearchMovieCommand { get; set; }

        public RelayCommand BackCommand { get; set; }

        public SearchMovieViewModel()
        {
            BackPage = App.MyGrid.Children[0];
            BackCommand = new RelayCommand(c =>
            {
                App.MyGrid.Children.RemoveAt(0);
                App.MyGrid.Children.Add(BackPage);
            });

            SearchMovieCommand = new RelayCommand(c =>
            {
                var movies = MovieService.GetMovies(TextBox.Text);

                if (movies != null)
                {

                    for (int i = 0; i < 5; i++)
                    {
                        
                        var viewModel = new SingleMovieUCViewModel()
                        {
                            Movie = movies[i]
                        };
                        var uc = new SingleMovieUC();
                        uc.DataContext = viewModel;

                        uc.Width = 250;
                        uc.Height = 350;
                        uc.Margin = new System.Windows.Thickness(10,30,10,10);
                        WrapPanel.Children.Add(uc);
                    }
                }
            });
        }
    }
}
