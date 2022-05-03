using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CarRental.Views
{
    /// <summary>
    /// Логика взаимодействия для AdminMenu.xaml
    /// </summary>
    public partial class AdminMenu : Page
    {
        public AdminMenu()
        {
            InitializeComponent();
        }

        private void ClientsButtonClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ClientsPage());
        }

        private void AutomobileButtonClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AdminPage());
        }

        private void ExtraditionButtonClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Cтраница в разработке", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            //NavigationService.Navigate(new ClientsPage());
        }

        private void RepairButtonClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Cтраница в разработке", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            //NavigationService.Navigate(new ClientsPage());
        }
    }
}
