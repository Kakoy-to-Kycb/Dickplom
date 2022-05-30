using Lopushok.Model;
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

namespace Lopushok.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageOrderAdd.xaml
    /// </summary>
    public partial class PageOrderAdd : Page
    {
        Order order = new Order();

        public PageOrderAdd(Order selectedOrder)
        {
            InitializeComponent();
            cbAgentOrder.ItemsSource = DB.db.Agent.ToList();
            cbProdOrder.ItemsSource = DB.db.Product.ToList();
            cbStatusOrder.ItemsSource = DB.db.Status.ToList();
            
            if(selectedOrder != null)
                order = selectedOrder;

            DataContext = order;

            cbStatusOrder.DisplayMemberPath = "Title";
            cbStatusOrder.SelectedValuePath = "StatusID";

            if(order.OrderID == 0)
            {
                btnDeleteOrder.Visibility = Visibility.Hidden;
            }

        }

        private void tbCountOrder_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text[0]))
            {
                e.Handled = true;
            }
        }

        private void btnSaveOrder_Click(object sender, RoutedEventArgs e)
        {
            if (order.OrderID == 0)
            {
                DB.db.Order.Add(order);

            }

            try
            {
                DB.db.SaveChanges();
                MessageBox.Show("Информация сохранена", "Уведомление");
                Manager.mainFrame.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }


        }

        private void btnDeleteOrder_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите удалить запись?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    DB.db.Order.Remove(order);
                    DB.db.SaveChanges();
                    MessageBox.Show("Запись удалена", "Уведомление");
                    Manager.mainFrame.GoBack();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.ToString());
                }
            }
        }
    }
}
