using Pharmacy.Models;
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
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        
        public MainPage(bool a)
        {
            InitializeComponent();
            if (a)
            {
                MainFrame.Navigate(new TypePage());
                return;
            }

            s1.IsEnabled = false;
            s2.IsEnabled = false;
            s3.IsEnabled = false;
            s4.IsEnabled = false;
            s5.IsEnabled = false;
            s6.IsEnabled = false;
            s7.IsEnabled = false;
            s8.IsEnabled = false;
            s9.IsEnabled = false;
            MainFrame.Navigate(new ArrivalPage());

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new CategoryPage());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new TypePage());
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new EdIsmPage());
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ConditionPage());
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ManufacturerPage());
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new MedicinePage());
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new SuppliersPage());
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new BuyerPage());
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new SellerPage());
        }

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ArrivalPage());
        }

        private void Button_Click_10(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new SalePage());
        }
    }
}
