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
    /// Interaction logic for SelectBackgroundWindow2.xaml
    /// </summary>
    public partial class SelectBackgroundWindow2 : Window
    {
        public SelectBackgroundWindow2()
        {
            InitializeComponent();
        }

        private void colorPicker13_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            if (e.NewValue != null)
            {
                // Сохраняем выбранный цвет в статическую переменную
                MyColor.MyBackgroundColor = new SolidColorBrush(e.NewValue.Value);
            }
        }

        private void Button_Click13(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
