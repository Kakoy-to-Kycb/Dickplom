using Lopushok.Model;
using Lopushok.Pages;
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

namespace Lopushok
{
    /// <summary>
    /// Логика взаимодействия для PageManager.xaml
    /// </summary>
    public partial class PageManager : Page
    {
        public PageManager()
        {
            InitializeComponent();
        }

        private void btnMprod_Click(object sender, RoutedEventArgs e)
        {
            Manager.mainFrame.Navigate(new PageProducts());
        }

        private void btnProdSales_Click(object sender, RoutedEventArgs e)
        {
            Manager.mainFrame.Navigate(new PageProdSale());
        }
    }
}
