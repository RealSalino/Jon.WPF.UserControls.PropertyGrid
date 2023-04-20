using PropertyGridApp.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;

using System.ComponentModel;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace PropertyGridApp.Controls
{
    public partial class PropertyGridControl : UserControl
    {
        public bool CategorizedView
        {
            get => (bool)GetValue(CategorizedViewProperty);
            set => SetValue(CategorizedViewProperty, value);
        }
        public IEnumerable PropertyEntries
        {
            get => (IEnumerable)GetValue(PropertyEntriesProperty);
            set => SetValue(PropertyEntriesProperty, value);
        }
        public object SelectedObject
        {
            get => GetValue(SelectedObjectProperty);
            set => SetValue(SelectedObjectProperty, value);
        }
        public PropertyGridControl()
        {
            InitializeComponent();
            DataContext = new PropertyGridControlViewModel();
        }

        public static readonly DependencyProperty PropertyEntriesProperty =
        DependencyProperty.Register("PropertyEntries", typeof(IEnumerable), typeof(PropertyGridControl));
        public static readonly DependencyProperty CategorizedViewProperty =
        DependencyProperty.Register("CategorizedView", typeof(bool), typeof(PropertyGridControl), new PropertyMetadata(true, OnCategorizedViewChanged));
        public static readonly DependencyProperty SelectedObjectProperty =
        DependencyProperty.Register("SelectedObject", typeof(object), typeof(PropertyGridControl), new PropertyMetadata(null, OnSelectedObjectChanged));
        private static void OnCategorizedViewChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as PropertyGridControl;
            control?.UpdateGroupDescriptions();
        }

        private static void OnSelectedObjectChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as PropertyGridControl;
            control?.UpdatePropertyEntries(); // Corrected method name
        }
        private void UpdateGroupDescriptions()
        {
            var collectionViewSource = (CollectionViewSource)this.Resources["GroupedPropertyEntries"];
            var collectionView = collectionViewSource.View;

            collectionView.GroupDescriptions.Clear();
            collectionView.SortDescriptions.Clear();

            if (CategorizedView)
            {
                collectionView.GroupDescriptions.Add(new PropertyGroupDescription("Category"));
            }
            else
            {
                collectionView.SortDescriptions.Add(new SortDescription("Name", ListSortDirection.Ascending));
            }
        }
        private void UpdatePropertyEntries()
        {
            if (SelectedObject != null)
            {
                var properties = TypeDescriptor.GetProperties(SelectedObject);
                var propertyEntries = new List<PropertyEntry>();

                foreach (PropertyDescriptor property in properties)
                {
                    if (property.IsBrowsable)
                    {
                        propertyEntries.Add(new PropertyEntry(property, SelectedObject));
                    }
                }

                PropertyEntries = propertyEntries;
            }
            else
            {
                PropertyEntries = null;
            }
        }

        private void PropertyDataGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            var dataGrid = sender as DataGrid;

            if (dataGrid.SelectedItem is PropertyEntry selectedPropertyEntry && !selectedPropertyEntry.IsCategory)
            {
                TextBlockSelectedProperty.Text = selectedPropertyEntry.Name;
                TextBlockSelectedPropertyDescription.Text = selectedPropertyEntry.Description;
            }
            else
            {
                TextBlockSelectedProperty.Text = string.Empty;
                TextBlockSelectedPropertyDescription.Text = string.Empty;
            }
        }
    }

    public class PropertyEntry
    {
        public PropertyDescriptor PropertyDescriptor { get; }
        public object Instance { get; }
        public bool IsCategory { get; set; }
        public string Category { get; set; }
        public string Name { get; set; }

        public string Description
        {
            get { return PropertyDescriptor != null ? PropertyDescriptor.Description : string.Empty; }
        }
        public object Value
        {
            get { return PropertyDescriptor?.GetValue(Instance); }
            set { PropertyDescriptor?.SetValue(Instance, value); }
        }
        public PropertyEntry()
        { }

        public PropertyEntry(PropertyDescriptor propertyDescriptor, object instance, string category = null)
        {
            PropertyDescriptor = propertyDescriptor;
            Instance = instance;
            Category = category;
            Name = propertyDescriptor.Name;
        }
    }

    public class PropertyNameConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var propertyName = value as string;
            return string.IsNullOrEmpty(propertyName) ? string.Empty : propertyName.Replace('_', ' ');
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }

}