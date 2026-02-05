using Pharmacy.Models;
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
    /// Логика взаимодействия для AddBuyerPage.xaml
    /// </summary>
    public partial class AddBuyerPage : Page
    {
        public static Buyer _group { get; set; } = new();

        bool IsEdit = false;
        public BuyersService service { get; set; } = new();

        //public Models.Type current { get; set; }

        public AddBuyerPage(Buyer? group = null)
        {
            InitializeComponent();

            if (group != null)
            {
                IsEdit = true;
                _group = group;

                DataContext = this;
                return;
            }
            _group = new();
            DataContext = this;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if (false)
            {
                MessageBox.Show("Такая запись уже есть!", "Некорректные данные",
           MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (IsEdit)
            {

                service.Commit();
            }
            else
            {
                service.Add(_group);
            }




            Button_Click_1(sender, e);
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
