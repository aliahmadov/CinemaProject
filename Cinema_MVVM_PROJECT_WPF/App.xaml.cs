using Cinema_MVVM_PROJECT_WPF.Views.UserControls;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Cinema_MVVM_PROJECT_WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static Grid MyGrid;
        public static UIElement BackPage;
        public static Image Image;
        public App()
        {
            //var view = new CinemaHomeUC();
            //var viewModel = new CinemaHomeViewModel();
            //view.DataContext = viewModel;
            //MyGrid.Children.Add(view);
        }

    }
}
