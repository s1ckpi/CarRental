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
    /// Логика взаимодействия для DetailsAutomobilePage.xaml
    /// </summary>
    public partial class DetailsAutomobilePage : Page
    {
        Core db = new Core();
        Cars currentCars;
        List<Cars> arrayCars;
        public DetailsAutomobilePage(CarRentalEntities context, Cars activeCar)
        {
            InitializeComponent();

            currentCars = activeCar;
            this.db.context = context;
            this.DataContext = currentCars;
        }

        private void BackButtonClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AutomobilePage());
        }

        private void RentalButtonClick(object sender, RoutedEventArgs e)
        {
            BeetwenCarsClients newBeetwenCarsClients = new BeetwenCarsClients()
            {
                RegistrationNumber = currentCars.RegistrationNumber,
                DateStart = DateTime.Today,
                DateEnd = Convert.ToDateTime(DateEndDatePicker.SelectedDate),
            };
        }
    }
}
