using CarRental.Models;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для AddEditAutomobilePage.xaml
    /// </summary>
    public partial class AddEditAutomobilePage : Page
    {
        Core db = new Core();
        Cars currentCars;
        string fileString;
        private byte[] _mainImageData;
        public AddEditAutomobilePage(CarRentalEntities context, Cars activeCar)
        {
            InitializeComponent(); 
            List<string> colorCars = new List<string> { "Белый", "Чёрынй", "Серый", "Фиолетовый", "Красный", "Жёлтый", "Зелёный", "Голубой", "Синий", "Серебрянный", 
            "Золотой", "Оранжевый", "Розовый", "Малиновый", "Тёмно синий", "Тёмно зелёный", "Тёмно красный", "Тёмно фиолетовый", "Тёмно голубой", "Тёмно оранжевый" };
            
            List<string> CarcassCars = new List<string> { "Седан", "Хэтчбек", "Универсал", "Лифтбэк", "Купе", "Кабриолет", "Родстер",
            "Тарга", "Лимузин", "Стретч", "Внедорожник", "Кроссовер", "Пикап", "Фургон", "Минивэн", "Микроавтобус", "Автобус"};

            ColorComboBox.ItemsSource = colorCars;
            ColorComboBox.SelectedIndex = 0;
            CarcassComboBox.ItemsSource = CarcassCars;
            CarcassComboBox.SelectedIndex = 0;

            currentCars = activeCar;
            this.db.context = context;
            this.DataContext = currentCars;
        }

        private void SelectImageAutomoboleButtonClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image |*.png; *.jpg, *.jpeg";
            if (ofd.ShowDialog() == true)
            {
                _mainImageData = File.ReadAllBytes(ofd.FileName);
                fileString = ofd.FileName;
                ImageAutomobole.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(_mainImageData);
                ImageAutomobole.Visibility = Visibility.Visible;
            }
        }

        private void AddServiceButtonClick(object sender, RoutedEventArgs e)
        {

        }

        private void SelectImageAutomobileAboveButtonClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image |*.png; *.jpg, *.jpeg";
            if (ofd.ShowDialog() == true)
            {
                _mainImageData = File.ReadAllBytes(ofd.FileName);
                fileString = ofd.FileName;
                ImageAutomobileAbove.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(_mainImageData);
                ImageAutomobileAbove.Visibility = Visibility.Visible;
            }
        }

        private void BackButtonClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AdminPage());
        }
    }
}
