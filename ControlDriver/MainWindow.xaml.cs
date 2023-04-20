using Jon.WPF.Data.Models.General;
using Jon.WPF.Data.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

namespace ControlDriver
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Create some test data
            var person1 = new Person
            {
                First = "John",
                Last = "Doe",
                Middle = "A",
                DOB = new DateTime(1985, 3, 15),
                Address = new Address
                {
                    Street = "123 Main St.",
                    City = "Anytown",
                    State = "CA",
                    Postal = "12345"
                },
                ContactInfoList = new List<ContactInfo>
    {
        new ContactInfo { Type = ContactInfoType.Email, Value = "johndoe@example.com" },
        new ContactInfo { Type = ContactInfoType.Phone, Value = "555-123-4567" }
    }
            };

            PropertyGridMain.SelectedObject = person1;
        }

        private void ColorPickerHeaderBackgroundBrus_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            PropertyGridMain.HeaderBackground = new SolidColorBrush(ColorPickerHeaderBackgroundBrus.SelectedColor.Value);
        }

        private void ColorPickerCategoryBackground_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            PropertyGridMain.CategoryBackground = new SolidColorBrush(ColorPickerCategoryBackground.SelectedColor.Value);
        }

        private void ColorPickerCategoryForeground_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            PropertyGridMain.CategoryForeground = new SolidColorBrush(ColorPickerCategoryForeground.SelectedColor.Value);
        }

        private void ColorPickerCategoryColor_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            PropertyGridMain.CategoryColor = new SolidColorBrush(ColorPickerCategoryColor.SelectedColor.Value);
        }
    }
}
