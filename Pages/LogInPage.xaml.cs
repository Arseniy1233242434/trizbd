using Pharmacy.Service;
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

namespace Pharmacy.Pages
{
    /// <summary>
    /// Логика взаимодействия для LogInPage.xaml
    /// </summary>
    public partial class LogInPage : Page
    {
        public SellerService SellerService { get; set; }= new SellerService();
        public LogInPage()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < SellerService.Users.Count; i++) 
            {
                if (login.Text == SellerService.Users[i].Login && password.Password == SellerService.Users[i].Password) 
                {
                    if(SellerService.Users[i].IsActive==true && SellerService.Users[i].IsAdmin==true)
                    {
                       NavigationService.Navigate(new MainPage(true));
                        return;
                    }
                    if (SellerService.Users[i].IsActive == true && SellerService.Users[i].IsAdmin == false)
                    {
                        NavigationService.Navigate(new MainPage(false));
                        return;
                    }
                    continue;
                }
            }
            MessageBox.Show("Неправильный логин или пароль!", "Ошибка",
               MessageBoxButton.OK, MessageBoxImage.Error);

        }
    }
}
