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

namespace Lopushok.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageWelcome.xaml
    /// </summary>
    public partial class PageWelcome : Page
    {
        public PageWelcome()
        {
            InitializeComponent();
            
        }


        private void btnProducts_Click(object sender, RoutedEventArgs e)
        {
            //Manager.mainFrame.Navigate(new PageProducts());
            try
            {
                var userLog = DB.db.Users.FirstOrDefault(x => x.UserLogin == tbUserLogin.Text && x.UserPassword == pbPassword.Password);
                if (userLog == null)
                {
                    MessageBox.Show("Такого пользователя не существует", "Внимание!",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    switch (userLog.UserRole)
                    {
                        case 1:
                            Properties.Settings.Default.glodalRole = "admin";
                            MessageBox.Show("Здравствуйте, Администратор " + userLog.UserName + "!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                            Manager.mainFrame.Navigate(new PageProducts());
                            break;

                        case 2:
                            Properties.Settings.Default.glodalRole = "manager";
                            MessageBox.Show("Здравствуйте, Менеджер " + userLog.UserName + "!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                            Manager.mainFrame.Navigate(new PageManager());
                            
                            break;

                        case 3:
                            Properties.Settings.Default.glodalRole = "guest";
                            MessageBox.Show("Здравствуйте, Клиент " + userLog.UserName + "!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                            Manager.mainFrame.Navigate(new PageProducts());
                            break;

                        default:
                            MessageBox.Show("Проверьте введеные данные!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
                            Manager.mainFrame.Navigate(new PageProducts());
                            break;
                    }
                    /*MessageBox.Show("Здравствуйте, " + userLog.UserName + "!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                    Manager.mainFrame.Navigate(new PageProducts());*/
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка " + ex.Message.ToString() + "Критическая работа приложения!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
