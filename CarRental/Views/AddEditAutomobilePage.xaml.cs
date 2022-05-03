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
        string ImageAutomobilePath;
        string ImageAboveAutomobilePath;
        public AddEditAutomobilePage(CarRentalEntities context, Cars activeCar)
        {
            InitializeComponent();

            List<CarModels> arrayCarModels = db.context.CarModels.ToList();

            List<Brand> arrayBrand = db.context.Brand.ToList();

            List<string> colorCars = new List<string> { "Белый", "Чёрынй", "Серый", "Фиолетовый", "Красный", "Жёлтый", "Зелёный", "Голубой", "Синий", "Серебрянный",
            "Золотой", "Оранжевый", "Розовый", "Малиновый", "Тёмно синий", "Тёмно зелёный", "Тёмно красный", "Тёмно фиолетовый", "Тёмно голубой", "Тёмно оранжевый" };

            List<string> CarcassCars = new List<string> { "Седан", "Хэтчбек", "Универсал", "Лифтбэк", "Купе", "Кабриолет", "Родстер",
            "Тарга", "Лимузин", "Стретч", "Внедорожник", "Кроссовер", "Пикап", "Фургон", "Минивэн", "Микроавтобус", "Автобус"};

            ModelComboBox.ItemsSource = arrayCarModels;
            ModelComboBox.DisplayMemberPath = "Model";
            ModelComboBox.SelectedValuePath = "IdCarModels";

            BrandComboBox.ItemsSource = arrayBrand;
            BrandComboBox.DisplayMemberPath = "BrandName";
            BrandComboBox.SelectedValuePath = "IdBrand";

            ColorComboBox.ItemsSource = colorCars;

            CarcassComboBox.ItemsSource = CarcassCars;

            currentCars = activeCar;
            this.db.context = context;
            this.DataContext = currentCars;
        }

        private void AddServiceButtonClick(object sender, RoutedEventArgs e)
        {
            //if (!String.IsNullOrEmpty("fh"))
            //{
            //    int activeIdModel = Convert.ToInt32(currentCars.IdCarModels);
            //    CarModels activeModel = db.context.CarModels.Where(x => x.IdCarModels == activeIdModel).FirstOrDefault();
            //    if (activeModel != null)
            //    {
            //        db.context.SaveChanges();
            //        NavigationService.Navigate(new AdminPage());
            //    }
            //    else
            //    {

            //    }
            //}
            if (currentCars == null)
            {
                Cars newCars = new Cars()
                {
                    IdBrand = Convert.ToInt32(BrandComboBox.SelectedValuePath),
                    IdCarModels = Convert.ToInt32(ModelComboBox.SelectedValuePath),
                    IdColor = Convert.ToInt32(ColorComboBox.SelectedValuePath),
                    IdCarcassType = Convert.ToInt32(CarcassComboBox.SelectedValuePath),
                    Availability = 2,
                };
                db.context.Cars.Add(newCars);
                db.context.SaveChanges();

                NavigationService.Navigate(new AdminPage());
            }
            else
            {
                db.context.SaveChanges();

                NavigationService.Navigate(new AdminPage());
            }
            
        }

        private void BackButtonClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AdminPage());
        }

        private void AddBrandClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddBrand());
        }

        private void AddModelClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddModel(db.context,currentCars));
        }
    }
}
