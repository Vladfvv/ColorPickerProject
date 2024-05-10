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
    /// Interaction logic for SelectColorLineWindow0.xaml
    /// </summary>
    public partial class SelectColorLineWindow0 : Window
    {
        public SelectColorLineWindow0()
        {
            InitializeComponent();
        }

        private void colorPicker11_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            if (e.NewValue != null)
            {
                // Сохраняем выбранный цвет в статическую переменную
                MyColor.MyLineColor = new SolidColorBrush(e.NewValue.Value);
            }
        }

        private void Button_Click11(object sender, RoutedEventArgs e)
        {
            SelectLineWindow1 selectLineWindow1 = new SelectLineWindow1();  
            selectLineWindow1.Show();
            this.Close();
        }
    }
}
