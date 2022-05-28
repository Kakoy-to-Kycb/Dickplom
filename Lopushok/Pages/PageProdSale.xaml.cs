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
    /// Логика взаимодействия для PageProdSale.xaml
    /// </summary>
    public partial class PageProdSale : Page
    {
        public PageProdSale()
        {
            InitializeComponent();
            dgOrder.ItemsSource = DB.db.Order.ToList();
           
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            Manager.mainFrame.Navigate(new PageOrderAdd((sender as Button).DataContext as Order));
        }

        private void btnAddOrder_Click(object sender, RoutedEventArgs e)
        {
            Manager.mainFrame.Navigate(new PageOrderAdd(null));
        }
    }
}
