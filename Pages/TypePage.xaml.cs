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
    /// Логика взаимодействия для TypePage.xaml
    /// </summary>
    /// 
   
    public partial class TypePage : Page
    {
        public TypeService service { get; set; } = new();
        public Models.Type current { get; set; } = null;
        public TypePage()
        {
            InitializeComponent();
            DataContext = this;
        }
        private void ListView_MouseDoubleClick_1(object sender, MouseButtonEventArgs e)
        {
            if (current != null)
            {
                NavigationService.Navigate(new AddPage(current, true));
            }
            else
            {
                MessageBox.Show("Выберите группу");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddPage(current, false));
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
