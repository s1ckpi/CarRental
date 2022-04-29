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
    /// Логика взаимодействия для AddModel.xaml
    /// </summary>
    public partial class AddModel : Page
    {
        Core db = new Core();
        Cars currentCars;
        string fileString;
        private byte[] _mainImageData;
        string ImageAutomobilePath;
        string ImageAboveAutomobilePath;
        public AddModel(CarRentalEntities context, Cars activeCar)
        {
            InitializeComponent();

            List<Brand> arrayBrand = db.context.Brand.ToList();

            BrandComboBox.ItemsSource = arrayBrand;
            BrandComboBox.DisplayMemberPath = "BrandName";
            BrandComboBox.SelectedValuePath = "IdBrand";

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
                ImageAutomobile.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(_mainImageData);
                ImageAutomobile.Visibility = Visibility.Visible;

                string newfilename = "\\Assets\\Images\\Car\\FrontSide\\";
                //путь к проекту
                string appFolderPath = Directory.GetCurrentDirectory();
                //Console.WriteLine(appFolderPath);
                appFolderPath = appFolderPath.Replace("\\bin\\Debug", "");//обрезанный путь

                //Console.WriteLine(appFolderPath);
                string imageName = System.IO.Path.GetFileName(fileString);//имя картинки с расширением
                //Console.WriteLine(imageName);

                newfilename = appFolderPath + newfilename + imageName;
                //Console.WriteLine(newfilename);
                File.Delete(newfilename);
                File.Copy(fileString, newfilename);

                ImageAutomobilePath = "Car\\FrontSide\\" + imageName;
                Console.WriteLine(ImageAutomobilePath);
            }
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

                string newfilename = "\\Assets\\Images\\Car\\AboveSide\\";
                //путь к проекту
                string appFolderPath = Directory.GetCurrentDirectory();
                //Console.WriteLine(appFolderPath);
                appFolderPath = appFolderPath.Replace("\\bin\\Debug", "");//обрезанный путь

                //Console.WriteLine(appFolderPath);
                string imageName = System.IO.Path.GetFileName(fileString);//имя картинки с расширением
                //Console.WriteLine(imageName);

                newfilename = appFolderPath + newfilename + imageName;
                //Console.WriteLine(newfilename);
                File.Delete(newfilename);
                File.Copy(fileString, newfilename);

                ImageAboveAutomobilePath = "Car\\AboveSide\\" + imageName;
                Console.WriteLine(ImageAboveAutomobilePath);
            }
        }

        private void AddModelButtonClick(object sender, RoutedEventArgs e)
        {
            if (currentCars == null)
            {
                CarModels NewModel = new CarModels()
                {
                    //IdBrand = BrandComboBox.Selec,
                    Model = NewModelTextBox.Text,
                    Price = Convert.ToDouble(PriceTextBox.Text),
                    Deposit = Convert.ToDouble(DepositTextBox.Text),
                    Acceleration = Convert.ToDouble(AccelerationTextBox.Text),
                    MaxSpeed = Convert.ToInt32(MaxSpeedTextBox.Text),
                    YearOfIssue = Convert.ToInt32(YearOfIssueTextBox.Text),
                    Image = NewModelTextBox.Text,
                    ImageAbove = NewModelTextBox.Text,
                };
                db.context.CarModels.Add(NewModel);
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
    }
}
