using Cinema_MVVM_PROJECT_WPF.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema_MVVM_PROJECT_WPF.ViewModels
{
    public class ShowMoviesViewModel:BaseViewModel
    {
        public RelayCommand BackCommand { get; set; }

        public ShowMoviesViewModel()
        {
            BackPage = App.MyGrid.Children[0];
            BackCommand = new RelayCommand(d =>
            {
                App.MyGrid.Children.RemoveAt(0);
                App.MyGrid.Children.Add(BackPage);
            });


        }
    }
}
