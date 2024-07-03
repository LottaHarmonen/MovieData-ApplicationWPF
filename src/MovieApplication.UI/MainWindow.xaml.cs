using MovieApplication.UI.ViewModels;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MovieApplication.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void Sidebar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DataContext is MainViewModel mainViewModel)
            {
                if (Sidebar.SelectedItem is ListBoxItem selectedItem && selectedItem.Tag is Type viewModelType)
                {
                    if (viewModelType == typeof(AllMoviesViewModel))
                    {
                        mainViewModel.CurrentViewModel = mainViewModel.AllMoviesViewModel;
                    }
                    else if (viewModelType == typeof(MovieDetailViewModel))
                    {
                        mainViewModel.CurrentViewModel = mainViewModel.MovieDetailViewModel;
                    }
                }
            }
        }
    }
}