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

            List<string> CarcassCars = new List<string> {"Все", "Седан", "Хэтчбек", "Универсал", "Лифтбэк", "Купе", "Кабриолет", "Родстер",
            "Тарга", "Лимузин", "Стретч", "Внедорожник", "Кроссовер", "Пикап", "Фургон", "Минивэн", "Микроавтобус", "Автобус"};

            List<string> PriceCars = new List<string> {"Все", "от 0 до 50 000", "от 50 000 до 100 000", "от 100 000 до 150 000"};

            List<string> BrandCars = new List<string> {"Все", "от 0 до 50 000", "от 50 000 до 100 000", "от 100 000 до 150 000"};

            CarcassComboBox.ItemsSource = CarcassCars;
            PriceComboBox.ItemsSource = PriceCars;
            BrandComboBox.ItemsSource = BrandCars;
            arrayCars = db.context.Cars.ToList();
            ListAutomobileListView.ItemsSource = arrayCars;
            UpdateServices();
        }

        private void ButtonEditClick(object sender, RoutedEventArgs e)
        {
            Button selectedButton = sender as Button;
            Cars item = selectedButton.DataContext as Cars;
            NavigationService.Navigate(new AddEditAutomobilePage(db.context, item));
        }

        private void ButtonDeleteClick(object sender, RoutedEventArgs e)
        {

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
            //Фильтрация по кузову
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

            //Поиск по названию (регистронезавимый)
            arrayCars = arrayCars.Where(x => x.CarModels.Model.ToLower().Contains(SearchTextBox.Text.ToLower())).ToList();

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
    }
}