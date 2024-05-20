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
    /// Interaction logic for SelectLineWindow1.xaml
    /// </summary>
    public partial class SelectLineWindow1 : Window
    {
        public SelectLineWindow1()
        {
            InitializeComponent();
        }

        private void Select_Click12(object sender, RoutedEventArgs e)
        {
            MyColor.SelectedLineThickness = slider_Line_thickness12.Value;
            SelectBackgroundWindow2 selectBackgroundWindow2 = new SelectBackgroundWindow2();           
            selectBackgroundWindow2.Show();
            this.Close();
        }
    }
}
