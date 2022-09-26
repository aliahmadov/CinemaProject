using Cinema_MVVM_PROJECT_WPF.Commands;
using Cinema_MVVM_PROJECT_WPF.Views.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema_MVVM_PROJECT_WPF.ViewModels
{
    public class CinemaHomeUCViewModel:BaseViewModel
    {

        public RelayCommand AdminCommand { get; set; }

        public CinemaHomeUCViewModel()
        {
            AdminCommand = new RelayCommand(c =>
            {
                var uc = new AdminSignUpUC();
                var viewModel = new AdminSignViewModel();
                uc.DataContext = viewModel;
                
                App.BackPage = App.MyGrid.Children[0];
                App.MyGrid.Children.RemoveAt(0);
                App.MyGrid.Children.Add(uc);
            });
        }
    }
}
