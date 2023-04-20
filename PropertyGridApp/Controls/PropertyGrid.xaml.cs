using PropertyGridApp.ViewModels;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace PropertyGridApp.Controls
{
    public partial class PropertyGrid : UserControl
    {
        private readonly PropertyGridControlViewModel _propertyGridControlModel;

        public PropertyGrid()
        {
            InitializeComponent();
            _propertyGridControlModel = new PropertyGridControlViewModel();
            DataContext = _propertyGridControlModel;
            propertyGridControl.DataContext = _propertyGridControlModel;
        }



        public static readonly DependencyProperty SelectedObjectProperty =
            DependencyProperty.Register("SelectedObject", typeof(object), typeof(PropertyGrid), new PropertyMetadata(null, OnSelectedObjectChanged));

        public object SelectedObject
        {
            get { return GetValue(SelectedObjectProperty); }
            set { SetValue(SelectedObjectProperty, value); }
        }

        private static void OnSelectedObjectChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            PropertyGrid propertyGrid = d as PropertyGrid;
            propertyGrid?.UpdateSelectedObject(e.NewValue);
        }

        private void UpdateSelectedObject(object obj)
        {
            _propertyGridControlModel.PropertyEntries.Clear();
            TextBlockObjectTypeName.Text = obj?.GetType().Name ?? "None";
            Type objectType = obj?.GetType();
            DescriptionAttribute descriptionAttribute = (DescriptionAttribute)Attribute.GetCustomAttribute(objectType, typeof(DescriptionAttribute));
            TextBlockDescription.Text = descriptionAttribute?.Description ?? "No description available";

            if (obj != null)
            {
                PropertyDescriptorCollection propertyDescriptors = TypeDescriptor.GetProperties(obj);

                foreach (PropertyDescriptor propertyDescriptor in propertyDescriptors)
                {
                    string category = propertyDescriptor.Category ?? "Other";
                    _propertyGridControlModel.PropertyEntries.Add(new PropertyEntry(propertyDescriptor, obj, category));
                }
            }
        }

    }
}
