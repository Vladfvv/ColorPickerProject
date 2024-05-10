using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ColorPickerProject
{
    public static class MyColor
    {
        public static SolidColorBrush MyLineColor = new SolidColorBrush(Colors.Black);//for line color
        public static double SelectedLineThickness { get; set; } = 1.0;
        public static SolidColorBrush MyBackgroundColor = new SolidColorBrush(Colors.Coral); ///for background color

    }
}
