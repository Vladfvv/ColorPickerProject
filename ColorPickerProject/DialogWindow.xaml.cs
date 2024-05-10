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
using System.Windows.Shapes;

namespace ColorPickerProject
{
    /// <summary>
    /// Interaction logic for DialogWindow.xaml
    /// </summary>
    public partial class DialogWindow : Window
    {
        public DialogWindow()
        {
            InitializeComponent();
        }


        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            MyColor.SelectedLineThickness = slider_Line_thickness1.Value;
            this.Close();
        }

        private void colorPickerSelectColorLine_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            if (e.NewValue != null)
            {
                MyColor.MyLineColor = new SolidColorBrush(e.NewValue.Value);
            }
        }

        private void colorPickerSelectColorBackground_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            if (e.NewValue != null)
            {
                MyColor.MyBackgroundColor = new SolidColorBrush(e.NewValue.Value);
            }
        }
    }
}
