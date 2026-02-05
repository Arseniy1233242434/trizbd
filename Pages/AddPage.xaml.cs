using Pharmacy.Models;
using Pharmacy.Service;
using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// Логика взаимодействия для AddPage.xaml
    /// </summary>
    public partial class AddPage : Page
    {
        public static Category _group;
        public static Category _group0;
        public static Models.Type _group1 ;
        public static Models.Type _group11;
        public static Models.Unit _group2;
        public static Models.Unit _group22;
        public static Models.Condition _group3;
        public static Models.Condition _group33;
        public CategoryService service { get; set; } = new();
        public TypeService service1 { get; set; } = new();
        public UnitService service2 { get; set; } = new();
        public ConditionService service3 { get; set; } = new();
        bool IsEdit = false;
        public AddPage(Category group, bool edit)
        {
            InitializeComponent();
            if (edit == true)
            {
                IsEdit = true;
                _group = group;
                _group0=new Category();
                _group0.Name =_group.Name;
                DataContext = _group0;
                return;
            }
            _group = new Category();
            DataContext = _group;
        }
        public AddPage(Models.Type group, bool edit)
        {
            InitializeComponent();
            if (edit == true)
            {
                IsEdit = true;
                _group1 = group;
                _group11=new Models.Type();
                _group11.Name =_group1.Name;
                DataContext = _group11;
                return;
            }
            _group1 = new Models.Type();
            DataContext = _group1;
        }
        public AddPage(Models.Unit group, bool edit)
        {
            InitializeComponent();
            if (edit == true)
            {
                IsEdit = true;
                _group2 = group;
                _group22=new Unit();
                _group22.Name =_group2.Name;
                DataContext = _group22;
                return;
            }
            _group2 = new Models.Unit();
            DataContext = _group2;
        }
        public AddPage(Models.Condition group, bool edit)
        {
            InitializeComponent();
            if (edit == true)
            {
                IsEdit = true;
                _group3 = group;
                _group33 = new Models.Condition();
                _group33.Name = _group3.Name;
                DataContext = _group33;
                return;
            }
            _group3 = new Models.Condition();
            DataContext = _group3;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (_group != null)
            {
                if (Validation.GetHasError(t))
                {
                    MessageBox.Show("Такая запись уже есть!", "Неккоректные данные",
               MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                if (IsEdit)
                {
                    _group.Name = _group0.Name;
                    service.Commit();
                }
                else
                {
                    service.Add(_group);
                }
            }
            if (_group1 != null)
            {
                if (Validation.GetHasError(t))
                {
                    MessageBox.Show("Такая запись уже есть!", "Неккоректные данные",
               MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                if (IsEdit)
                {
                    _group1.Name = _group11.Name;
                    service1.Commit();
                }
                else
                {
                    service1.Add(_group1);
                }
            }
            if (_group2 != null)
            {
                if (Validation.GetHasError(t))
                {
                    MessageBox.Show("Такая запись уже есть!", "Неккоректные данные",
               MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                if (IsEdit)
                {
                    _group2.Name = _group22.Name;
                    service2.Commit();
                }
                else
                {
                    service2.Add(_group2);
                }
            }
            if (_group3 != null)
            {
                if (Validation.GetHasError(t))
                {
                    MessageBox.Show("Такая запись уже есть!", "Неккоректные данные",
               MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                if (IsEdit)
                {
                    _group3.Name = _group33.Name;
                    service3.Commit();
                }
                else
                {
                    service3.Add(_group3);
                }
            }


            Button_Click_1(sender, e);
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

    }

    public class IsTitleCorrect2 : ValidationRule
    {

        public override ValidationResult Validate(object value, CultureInfo
        cultureInfo)
        {
            var input = (value ?? "").ToString().Trim();
            if (AddPage._group != null)
            {



                CategoryService service = new CategoryService();

                for (int i = 0; i < CategoryService.Users.Count; i++)
                {
                    if (CategoryService.Users[i].Name == input && AddPage._group.Name != input)
                    {
                        return new ValidationResult(false, "Такая запись уже есть!");
                    }
                }


                return ValidationResult.ValidResult;

            }
            if (AddPage._group1 != null)
            {



                TypeService service = new TypeService();

                for (int i = 0; i < TypeService.Users.Count; i++)
                {
                    if (TypeService.Users[i].Name == input && AddPage._group1.Name != input)
                    {
                        return new ValidationResult(false, "Такая запись уже есть!");
                    }
                }


                return ValidationResult.ValidResult;

            }
            if (AddPage._group2 != null)
            {



                UnitService service = new UnitService();

                for (int i = 0; i < UnitService.Users.Count; i++)
                {
                    if (UnitService.Users[i].Name == input && AddPage._group2.Name != input)
                    {
                        return new ValidationResult(false, "Такая запись уже есть!");
                    }
                }


                return ValidationResult.ValidResult;

            }
            if (AddPage._group3 != null)
            {



               ConditionService service = new ConditionService();

                for (int i = 0; i < ConditionService.Users.Count; i++)
                {
                    if (ConditionService.Users[i].Name == input && AddPage._group3.Name != input)
                    {
                        return new ValidationResult(false, "Такая запись уже есть!");
                    }
                }


                return ValidationResult.ValidResult;

            }
            return ValidationResult.ValidResult;
        }
    }
}
