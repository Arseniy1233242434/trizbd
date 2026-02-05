using Pharmacy.Models;
using Pharmacy.Service;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для AddManufacturerPage.xaml
    /// </summary>
    public partial class AddManufacturerPage : Page
    {
        public static Manufacturer _group;
        public static Manufacturer _group0;
        bool IsEdit = false;
        public ManufacturerService service { get; set; } = new();

       
        public AddManufacturerPage(Manufacturer? group=null)
        {
            InitializeComponent();
          
            if (group != null)
            {
                IsEdit = true;
                _group = group;
                _group0 = new Manufacturer();
                _group0.Name = _group.Name;
                _group0.Country = _group.Country;
                DataContext = _group0;
                return;
            }
            _group = new Manufacturer();
            DataContext = _group;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if (Validation.GetHasError(t))
            {
                MessageBox.Show("Такая запись уже есть!", "Некорректные данные",
           MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (IsEdit)
            {
                _group.Name = _group0.Name;
                _group.Country = _group0.Country;
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
    public class IsTitleCorrect3 : ValidationRule
    {

        public override ValidationResult Validate(object value, CultureInfo
        cultureInfo)
        {
            var input = (value ?? "").ToString().Trim();


            ManufacturerService service = new ManufacturerService();

                for (int i = 0; i < ManufacturerService.Users.Count; i++)
                {
                    if (ManufacturerService.Users[i].Name == input && AddManufacturerPage._group.Name != input)
                    {
                        return new ValidationResult(false, "Такая запись уже есть!");
                    }
                }


                return ValidationResult.ValidResult;

            

        }
    }
}
