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
    /// Логика взаимодействия для AddMedicinePage.xaml
    /// </summary>
    public partial class AddMedicinePage : Page
    {
        public static Medicine _group { get; set; } = new();
       
        bool IsEdit = false;
        public MedicineService service { get; set; } = new();
        public TypeService service1 { get; set; } = new();
        public CategoryService service2 { get; set; } = new();
        public ManufacturerService service3 { get; set; } = new();
        public UnitService service4 { get; set; } = new();
        public ConditionService service5 { get; set; } = new();
        //public Models.Type current { get; set; }

        public AddMedicinePage(Medicine? group = null)
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
    public class IsPriceCorrect : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo
        cultureInfo)
        {
            string h = (string)value;

            if (!decimal.TryParse(h, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal a))
            {
                string modified = h.Replace(',', '.');
                if (!decimal.TryParse(h, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal a1))
                    return new ValidationResult(false, "Неправильный формат дозировки!");
            }
            if (a <= 0)
            {
                return new ValidationResult(false, "Неправильный формат дозировки!");
            }
            return ValidationResult.ValidResult;
        }
    }
    public class IsStockCorrect : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo
        cultureInfo)
        {
            string h = (string)value;

            if (!int.TryParse(h, NumberStyles.Any, CultureInfo.InvariantCulture, out int a))
            {

                return new ValidationResult(false, "Неправильный формат количества!");
            }
            if (a <= 0)
            {
                return new ValidationResult(false, "Неправильный формат количества!");
            }
            return ValidationResult.ValidResult;
        }
    }
}
