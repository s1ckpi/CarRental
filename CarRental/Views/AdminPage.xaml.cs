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
    /// Логика взаимодействия для AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        Core db = new Core();
        List<CarModels> arrayCarModels;
        List<Brand> arrayBrand;
        public AdminPage()
        {
            InitializeComponent();
            arrayCarModels = db.context.CarModels.ToList();
            arrayBrand = db.context.Brand.ToList();
            foreach (var item in arrayBrand)
            {

                Console.WriteLine(item.ImageBrandLogoPath);
            }
            ListAutomobileListView.ItemsSource = arrayCarModels;
        }

        private void ButtonEditClick(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonDeleteClick(object sender, RoutedEventArgs e)
        {

        }

        private void AddAutomobileButtonClick(object sender, RoutedEventArgs e)
        {

        }
    }
}
