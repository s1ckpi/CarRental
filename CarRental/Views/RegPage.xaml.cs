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
    /// Логика взаимодействия для RegPage.xaml
    /// </summary>
    public partial class RegPage : Page
    {
        Core db = new Core();
        public RegPage()
        {
            InitializeComponent();
        }

        private void SingUpTextBlockMouseDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new AuthPage());
        }

        private void RegButtonClick(object sender, RoutedEventArgs e)
        {
            if (RegPasswordTextBox.Text == RegConfirmPasswordTextBox.Text)
            {
                Users newUser = new Users()
                {
                    Login = RegLoginTextBox.Text,
                    Password = RegPasswordTextBox.Text,
                    Email = RegEmailTextBox.Text,
                };
                db.context.Users.Add(newUser);
                db.context.SaveChanges();
            }
            

            Clients newClient = new Clients()
            {
                DriverLicenseNumber = DriverLicenseNumberTextBox.Text,
                Login = RegLoginTextBox.Text,
                LastName = RegLastNameTextBox.Text,
                FirstName = RegFirstNameTextBox.Text,
                PatronymicName = RegPatronymicNameTextBox.Text,
            };
            db.context.Clients.Add(newClient);

            db.context.SaveChanges();

            NavigationService.Navigate(new AuthPage());
        }
    }
}
