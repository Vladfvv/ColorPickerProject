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
    /// Interaction logic for ColorPickerBackground.xaml
    /// </summary>
    public partial class ColorPickerBackground : Window
    {
        public ColorPickerBackground()
        {
            InitializeComponent();
        }

        private void ClrPcker_Background_SelectedColorChanged_Shape(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            if (e.NewValue != null)
            {
                // Сохраняем выбранный цвет в статическую переменную
                MyColor.MyBackgroundColor = new SolidColorBrush(e.NewValue.Value);
            }
            
        }

        private void Select_Click123(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
       
    }
}
