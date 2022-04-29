using CarRental.Models;
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
    /// Логика взаимодействия для AddBrand.xaml
    /// </summary>
    public partial class AddBrand : Page
    {
        Core db = new Core();
        public AddBrand()
        {
            InitializeComponent();
        }

        private void AddBrandButtonClick(object sender, RoutedEventArgs e)
        {
            Brand NewBrand = new Brand()
            {
                BrandName = NewBrandTextBox.Text
            };
            db.context.Brand.Add(NewBrand);
            db.context.SaveChanges();

            NavigationService.Navigate(new AdminPage());
        }

        private void BackButtonClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AdminPage());
        }
    }
}
