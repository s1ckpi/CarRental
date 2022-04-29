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
        Cars item;
        public AdminPage()
        {
            InitializeComponent();
            arrayCars = db.context.Cars.ToList();

            ListAutomobileListView.ItemsSource = arrayCars;

            List<CarcassType> arrayCarcassCars = db.context.CarcassType.ToList();

            List<string> PriceCars = new List<string> { "Все", "от 0 до 50 000", "от 50 000 до 100 000", "от 100 000 до 150 000" };

            List<Brand> arrayBrandCars = db.context.Brand.ToList();

            CarcassComboBox.ItemsSource = arrayCarcassCars;
            CarcassComboBox.DisplayMemberPath = "CarcassName";
            CarcassComboBox.SelectedValuePath = "IdCarcassType";

            PriceComboBox.ItemsSource = PriceCars;

            BrandComboBox.ItemsSource = arrayBrandCars;
            BrandComboBox.DisplayMemberPath = "BrandName";
            BrandComboBox.SelectedValuePath = "IdBrand";
            UpdateServices();
        }

        private void EditButtonClick(object sender, RoutedEventArgs e)
        {
            Button selectedButton = sender as Button;
            Cars item = selectedButton.DataContext as Cars;
            NavigationService.Navigate(new AddEditAutomobilePage(db.context, item));
        }

        private void DeleteButtonClick(object sender, RoutedEventArgs e)
        {
            Button selectedButton = sender as Button;
            Cars item = selectedButton.DataContext as Cars;
            MessageBoxResult result = MessageBox.Show("Вы действительно хотите удалить строку?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                db.context.Cars.Remove(item);
                db.context.SaveChanges();
                MessageBox.Show("Данные удалены");
            }
            //обновление DataGrid
            ListAutomobileListView.ItemsSource = db.context.Cars.ToList();
        }

        private void ChanceStatusButtonClick(object sender, RoutedEventArgs e)
        {
            Button selectedButton = sender as Button;
            item = selectedButton.DataContext as Cars;
            ContextMenu cm = this.FindResource("cmButton") as ContextMenu;
            cm.PlacementTarget = sender as Button;
            cm.IsOpen = true;
        }

        private void AddAutomobileButtonClick(object sender, RoutedEventArgs e)
        {
            Cars item = new Cars();
            db.context.Cars.Add(item);
            NavigationService.Navigate(new AddEditAutomobilePage(db.context, item));
        }

        private void UpdateServices()
        {
            arrayCars = db.context.Cars.ToList();
            ListAutomobileListView.ItemsSource = arrayCars;
            //Сортировка по цене
            if (PriceComboBox.SelectedIndex != 0)
            {
                if (PriceComboBox.SelectedIndex == 1)
                {
                    arrayCars = arrayCars.Where(x => x.CarModels.Price >= 0 && x.CarModels.Price <= 50000).ToList();
                }
                if (PriceComboBox.SelectedIndex == 2)
                {
                    arrayCars = arrayCars.Where(x => x.CarModels.Price >= 50000 && x.CarModels.Price <= 100000).ToList();
                }
                if (PriceComboBox.SelectedIndex == 3)
                {
                    arrayCars = arrayCars.Where(x => x.CarModels.Price >= 100000 && x.CarModels.Price <= 150000).ToList();
                }
            }
            //сортироска по брэнду
            if (BrandComboBox.SelectedItem != null && BrandComboBox.SelectedIndex != 0)
            {
                int activeIdBrand = Convert.ToInt32(BrandComboBox.SelectedValue);
                arrayCars = arrayCars.Where(x => x.IdBrand == activeIdBrand).ToList();
            }
            //сортироска по кузову
            if (CarcassComboBox.SelectedIndex != 0 && CarcassComboBox.SelectedItem != null)
            {
                int activeIdCarcassType = Convert.ToInt32(CarcassComboBox.SelectedValue);
                Console.WriteLine(activeIdCarcassType);
                arrayCars = arrayCars.Where(x => x.IdCarcassType == activeIdCarcassType).ToList();

                foreach (var item in arrayCars)
                {
                    Console.WriteLine(item.CarModels.Model);
                }
            }

            //Поиск по названию (регистронезавимый)
            arrayCars = arrayCars.Where(x => x.CarModels.Model.ToLower().Contains(SearchTextBox.Text.ToLower())).ToList();

            //фильтрация по галочке
            if (FreeCarsCheckBox.IsChecked == true)
            {
                arrayCars = arrayCars.Where(x => x.Availability == 0).ToList();
            }
            else
            {
                ListAutomobileListView.ItemsSource = null;
                ListAutomobileListView.ItemsSource = arrayCars;
            }

            if (BusyCarsCheckBox.IsChecked == true)
            {
                arrayCars = arrayCars.Where(x => x.Availability == 1).ToList();
            }
            else
            {
                ListAutomobileListView.ItemsSource = null;
                ListAutomobileListView.ItemsSource = arrayCars;
            }

            if (UnderRepairCarsCheckBox.IsChecked == true)
            {
                arrayCars = arrayCars.Where(x => x.Availability == 2).ToList();
            }
            else
            {
                ListAutomobileListView.ItemsSource = null;
                ListAutomobileListView.ItemsSource = arrayCars;
            }

            ListAutomobileListView.ItemsSource = null;
            ListAutomobileListView.ItemsSource = arrayCars;
        }

        private void PriceComboBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateServices();
        }

        private void SearchTextBoxSelectionChanged(object sender, RoutedEventArgs e)
        {
            UpdateServices();
        }

        private void CarcassComboBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateServices();
        }

        private void BrandComboBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateServices();
        }

        private void FreeCarsCheckBoxChecked(object sender, RoutedEventArgs e)
        {
            UpdateServices();
        }

        private void BusyCarsCheckBoxChecked(object sender, RoutedEventArgs e)
        {
            UpdateServices();
        }

        private void UnderRepairCarsCheckBoxChecked(object sender, RoutedEventArgs e)
        {
            UpdateServices();
        }

        private void FreeCarsCheckBoxUnchecked(object sender, RoutedEventArgs e)
        {
            UpdateServices();
        }

        private void BusyCarsCheckBoxUnchecked(object sender, RoutedEventArgs e)
        {
            UpdateServices();
        }

        private void UnderRepairCarsCheckBoxUnchecked(object sender, RoutedEventArgs e)
        {

            UpdateServices();
        }

        private void FreeCarsMenuItemClick(object sender, RoutedEventArgs e)
        {
            item.Availability = 0;
            db.context.SaveChanges();
            UpdateServices();
        }

        private void BusyCarsMenuItemClick(object sender, RoutedEventArgs e)
        {
            item.Availability = 1;
            db.context.SaveChanges();
            UpdateServices();
        }

        private void UnderRepairCarsMenuItemClick(object sender, RoutedEventArgs e)
        {
            item.Availability = 2;
            db.context.SaveChanges();
            UpdateServices();
        }
    }
}