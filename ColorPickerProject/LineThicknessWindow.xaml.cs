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
    /// Interaction logic for LineThicknessWindow.xaml
    /// </summary>
    public partial class LineThicknessWindow : Window
    {
        public LineThicknessWindow()
        {
            InitializeComponent();
        }

        private void Select_Click(object sender, RoutedEventArgs e)
        {
            if (MyColor.SelectedLineThickness != 0) slider_Line_thickness.Value = MyColor.SelectedLineThickness;    
            MyColor.SelectedLineThickness = slider_Line_thickness.Value;
            this.Close();
        }
    }
}
