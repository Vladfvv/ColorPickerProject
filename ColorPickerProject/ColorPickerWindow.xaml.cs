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
        List<FontFamily> fontFamily;
        int i = 0;

        // public static SolidColorBrush SelectedColor { get; private set; }
        // Статическая переменная для хранения выбранного цвета
        // public static SolidColorBrush SelectedColor { get; set; }
        public ColorPickerWindow()
        {
            InitializeComponent();
            fontFamily = Fonts.SystemFontFamilies.ToList();
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
            // MyColor.myColor2 = color_items.SelectedItem[0];
            //MyColor.myColor2 = color_items.GetValue();
            // MyColor.myColor2 = (ClrPcker_Background.SelectedColorChanged());
            /* if (e.NewValue != null)
             {
                 // Сохраняем выбранный цвет в статическую переменную
                 SelectedColor = new SolidColorBrush(e.NewValue.Value);
             }*/
            // MyColor.MyColor2 = SelectedColor;//Второй раз на всякий случай, но все равно статическая переменная пропадает
            this.Close();
        }
    }
}
