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
    /// Логика взаимодействия для AddSalePage.xaml
    /// </summary>
    public partial class AddSalePage : Page
    {
        public static Sale _group { get; set; } = new();

        bool IsEdit = false;
        public SaleService service { get; set; } = new();
        public MedicineService service1 { get; set; } = new();
        public SupplierService service2 { get; set; } = new();
        public Arrivalservice service3 { get; set; } = new();
        public BuyersService service4 { get; set; } = new();
        public SellerService service5 { get; set; } = new();

        //public Models.Type current { get; set; }

        public  AddSalePage(Sale? group = null)
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
           _group.Date = DateTime.Now;
            DataContext = this;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _group.OrderNumber = 0;
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
