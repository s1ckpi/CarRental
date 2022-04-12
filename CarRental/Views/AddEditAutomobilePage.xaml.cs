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
        public AddEditAutomobilePage()
        {
            InitializeComponent();
            ColorComboBox.SelectedIndex = 0;
            CarcassComboBox.SelectedIndex = 0;
            ImageAutomobole.Visibility = Visibility.Collapsed;
            ImageAutomobileAbove.Visibility = Visibility.Collapsed;
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
                AddServiceButton.Margin = new Thickness(-5, 5, 0, 0);
                ImageAutomobileStackPanel.Margin = new Thickness(1000,-640,0,0);
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
                AddServiceButton.Margin = new Thickness(-5, 5, 0, 0);
                ImageAutomobileAboveStackPanel.Margin = new Thickness(1000, 50, 0, 0);
            }
        }

        private void BackButtonClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AdminPage());
        }
    }
}
