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
    /// Логика взаимодействия для ManufacturerPage.xaml
    /// </summary>
    public partial class ManufacturerPage : Page
    {
        public ManufacturerService service { get; set; } = new();
        public Models.Manufacturer current { get; set; } = null;
        public ManufacturerPage()
        {
            InitializeComponent();
            DataContext = this;
        }
        private void ListView_MouseDoubleClick_1(object sender, MouseButtonEventArgs e)
        {
            if (current != null)
            {
               NavigationService.Navigate(new AddManufacturerPage(current));
            }
            else
            {
                MessageBox.Show("Выберите группу");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddManufacturerPage());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (current != null)
            {
                if (MessageBox.Show("Вы действительно хотите удалить запись?",
                "Удалить запись?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    service.Remove(current);
                }
            }
            else
            {
                MessageBox.Show("Выберите запись для удаления", "Выберите запись",
                MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
