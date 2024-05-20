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
    /// Interaction logic for ColorPickerWindow.xaml
    /// </summary>
    public partial class ColorPickerWindow : Window
    {
       

        // public static SolidColorBrush SelectedColor { get; private set; }
        // Статическая переменная для хранения выбранного цвета
        // public static SolidColorBrush SelectedColor { get; set; }
        public ColorPickerWindow()
        {
            InitializeComponent();          
            ClrPcker_Background.SelectedColor = MyColor.MyLineColor.Color;
        }

        private void ClrPcker_Background_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            if (e.NewValue != null)
            {
                // Сохраняем выбранный цвет в статическую переменную
                MyColor.MyLineColor = new SolidColorBrush(e.NewValue.Value);
            }      
            
        }

       
        private void Select_Click(object sender, RoutedEventArgs e)
        {           
            this.Close();
        }
    }
}
