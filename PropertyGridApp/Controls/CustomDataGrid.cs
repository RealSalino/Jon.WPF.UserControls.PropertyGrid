using System.Windows;
using System.Windows.Controls;

namespace PropertyGridApp.Controls
{
    public class CustomDataGrid : DataGrid
    {
        static CustomDataGrid()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CustomDataGrid), new FrameworkPropertyMetadata(typeof(CustomDataGrid)));
        }
    }
}
