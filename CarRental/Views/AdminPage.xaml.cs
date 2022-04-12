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
        List<Cars> arrayCars;
        List<CarModels> arrayCarModels;
        public AdminPage()
        {
            InitializeComponent();
            arrayCars = db.context.Cars.ToList();
            ListAutomobileListView.ItemsSource = arrayCars;
            UpdateServices();
        }

        private void ButtonEditClick(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonDeleteClick(object sender, RoutedEventArgs e)
        {

        }

        private void AddAutomobileButtonClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddEditAutomobilePage());
        }

        private void UpdateServices()
        {
            ListAutomobileListView.ItemsSource = null;
            arrayCars = db.context.Cars.ToList();

            //Фильтрация по кузову
            if (SortComboBox.SelectedIndex == 1)
            {
                arrayCars = arrayCars.Where(x => x.CarModels.Price >= 0 && x.CarModels.Price <= 50000).ToList();
            }
            if (SortComboBox.SelectedIndex == 2)
            {
                arrayCars = arrayCars.Where(x => x.CarModels.Price >= 50000 && x.CarModels.Price <= 100000).ToList();
            }
            if (SortComboBox.SelectedIndex == 3)
            {
                arrayCars = arrayCars.Where(x => x.CarModels.Price >= 100000 && x.CarModels.Price <= 150000).ToList();
            }

            //Поиск по названию (регистронезавимый)
            arrayCars = arrayCars.Where(x => x.Brand.BrandName.ToLower().Contains(SearchTextBox.Text.ToLower())).ToList();

            ListAutomobileListView.ItemsSource = arrayCars;
        }
    }
}