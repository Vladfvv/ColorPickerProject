using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace ColorPickerProject
{
    class ClassForSerialize
    {
       
            public Point points { get; set; }
            public double strokeThickness { get; internal set; } = 1.0;
            // public Point Points { get; internal set; }
            [NonSerialized] // Помечаем, чтобы это поле не сериализовалось
            public SolidColorBrush strokeColor = new SolidColorBrush(Colors.Black);//for line color   
            [NonSerialized] // Помечаем, чтобы это поле не сериализовалось
            public SolidColorBrush fill = new SolidColorBrush(Colors.Coral); ///for background color

            public string SerializedColorLine { get; set; }
            public string SerializedColorFill { get; set; }





            public ClassForSerialize()
            {
                strokeColor = new SolidColorBrush(Colors.Black);
                fill = new SolidColorBrush(Colors.OrangeRed);
            }

            [OnSerializing]
            internal void OnSerializingMethod(StreamingContext context)
            {
                SerializedColorLine = strokeColor.Color.ToString();
                SerializedColorFill = fill.Color.ToString();
            }

            [OnDeserialized]
            internal void OnDeserializedMethod(StreamingContext context)
            {
                strokeColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString(SerializedColorLine));
                fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString(SerializedColorFill));
            }

        }


    }

