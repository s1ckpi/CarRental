using CarRental.Views;
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

namespace CarRental
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new AuthPage());
        }

        private void MinimizeButtonMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void CloseButtonMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void ToolBarMouseDown(object sender, MouseButtonEventArgs e)
        {
        }

        private void MiniProfileFrameContentRendered(object sender, EventArgs e)
        {
            
        }

        private void MainFrameContentRendered(object sender, EventArgs e)
        {

        }

        private void SidePanelFrameContentRendered(object sender, EventArgs e)
        {

        }
    }
}
