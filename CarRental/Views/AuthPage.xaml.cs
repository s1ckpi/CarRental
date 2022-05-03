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
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {

        Core db = new Core();
        public AuthPage() 
        {
            InitializeComponent();
        }

        private void CreateAccountTextBlockMouseDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new RegPage());
        }

        private void SingInButtonClick(object sender, RoutedEventArgs e)
        {
            ////считаем количество записей в таблице с заданными параметрами (логин, пароль)
            //int count = db.context.Users.Where(x => x.Login == AuthLoginTextBox.Text && x.Password == AuthPasswordTextBox.Text).Count();

            //Console.WriteLine(count);

            //if ()
            //{

            //}
            //if (count == 0)
            //{
            //    MessageBox.Show("Такой пользователь отсутствует!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            //}
            //else
            //{
            //    NavigationService.Navigate(new AutomobilePage());
            //    AuthMenuGrid.Margin = new Thickness(40, 20, 20, 20);
            //}

            List<Users> arrUser = db.context.Users.Where(x => x.Login == AuthLoginTextBox.Text && x.Password == AuthPasswordTextBox.Text).ToList();
            int countUsers = arrUser.Count();

            if (countUsers == 0)
            {
                MessageBox.Show("Сбой", "Такого пользователь нет", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (arrUser.First().Role.IdRole == 1)
                {
                    Properties.Settings.Default.currentUser = AuthLoginTextBox.Text;
                    Properties.Settings.Default.Save();
                    NavigationService.Navigate(new AdminMenu());
                }
                else
                {
                    Properties.Settings.Default.currentUser = AuthLoginTextBox.Text;
                    Properties.Settings.Default.Save();
                    NavigationService.Navigate(new AutomobilePage());
                }
            }
        }
    }
}
