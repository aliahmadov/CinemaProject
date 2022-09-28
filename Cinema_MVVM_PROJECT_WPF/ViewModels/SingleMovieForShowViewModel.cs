using Cinema_MVVM_PROJECT_WPF.Commands;
using Cinema_MVVM_PROJECT_WPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema_MVVM_PROJECT_WPF.ViewModels
{
    public class SingleMovieForShowViewModel:BaseViewModel
    {
        public RelayCommand RemoveMovieCommand { get; set; }

        private Movie movie;

        public Movie Movie
        {
            get { return movie; }
            set { movie = value;OnPropertyChanged(); }
        }


    }
}
