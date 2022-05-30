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
using Lopushok.Model;
using Lopushok.Pages;

namespace Lopushok
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Manager.mainFrame = MainFrame;
            MainFrame.Navigate(new PageWelcome());
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            if (MainFrame.CanGoBack)
            {
                MainFrame.GoBack();
            }
        }

        private void MainFrame_Navigated(object sender, NavigationEventArgs e)
        {
            if (!MainFrame.CanGoBack)
            {
                btnBack.Visibility = Visibility.Hidden;
                btnExit.Visibility = Visibility.Hidden;
            }
            else
            {
                btnBack.Visibility = Visibility.Visible;
                btnExit.Visibility = Visibility.Visible;
            }
                
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new PageWelcome());
        }
    }
}
