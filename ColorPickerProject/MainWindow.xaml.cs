﻿using Microsoft.Win32;
using System;

using System.IO;
using System.Text;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Xceed.Wpf.Toolkit;

namespace ColorPickerProject
{

    public partial class MainWindow : Window
    {

        private bool isDrawing = false;
        private Point startPoint;
        private List<Shape> shapes = new List<Shape>();
        // private string currentFileName = null;
        public Color myColorPicker { get; set; }
        /* MySelectColor mySelectColor;
         MySelectColor selectedBrush = MySelectColor.SelectedColor;*/

        private Point currentMousePosition;

        private Color lineColor;
        private Color bgColor = Colors.White;
        private double lineThickness = 1.0;
        private bool fileExists = false;
        private string fileName = "";
        // ObservableCollection<ColorItem> ColorList;
        public MainWindow()
        {
            InitializeComponent();

            /* CommandBinding saveCommandBinding = new CommandBinding(ApplicationCommands.Save);
             saveCommandBinding.Executed += Save_Executed;
             saveCommandBinding.CanExecute += Save_CanExecute;
             CommandBindings.Add(saveCommandBinding);*/
            /* MySelectColor mySelectColor;*/
        }



        private void Canvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Point clickPoint = e.GetPosition(myCanvas);
            Console.Write(myColorPicker.R);
            DrawStar(clickPoint, myColorPicker);
            UpdateStatusBarText(clickPoint);
            UpdateBottomStatusBar(clickPoint);
            //myStatusBar.DataContext = clickPoint;
        }

        private void DrawStar(Point startPoint, Color colorPicker)
        {


            // Реализация рисования звезды            
            //startPoint = e.GetPosition(myCanvas);
            Polygon myPolygon = new Polygon();
            myPolygon.Points = new PointCollection();
            myPolygon.Points.Add(new Point(startPoint.X, startPoint.Y - 10));
            myPolygon.Points.Add(new Point(startPoint.X + 10, startPoint.Y));
            myPolygon.Points.Add(new Point(startPoint.X, startPoint.Y + 10));
            myPolygon.Points.Add(new Point(startPoint.X - 10, startPoint.Y));
            if (myPolygon.StrokeThickness == 0) myPolygon.StrokeThickness = lineThickness;
            else myPolygon.StrokeThickness = MyColor.SelectedLineThickness;

            if (MyColor.MyLineColor.Color.R == 0 && MyColor.MyLineColor.Color.G == 0 && MyColor.MyLineColor.Color.B == 0)//если не задан - присвоим цвет по умолчанию
            {
                SolidColorBrush brush = new SolidColorBrush(Colors.Black);
                myPolygon.Stroke = brush;
            }
            else myPolygon.Stroke = MyColor.MyLineColor;


            if (MyColor.MyBackgroundColor.Color.R == 0 && MyColor.MyBackgroundColor.Color.G == 0 && MyColor.MyBackgroundColor.Color.B == 0)
            {
                SolidColorBrush brush = new SolidColorBrush(Colors.Green);
                myPolygon.Fill = brush;
                myPolygon.Fill = MyColor.MyBackgroundColor;
            }

            else//если не задан - присвоим цвет по умолчанию
                myPolygon.Fill = MyColor.MyBackgroundColor;



            //myPolygon.Fill = Brushes.Yellow;
            myCanvas.Children.Add(myPolygon);
            shapes.Add(myPolygon);
           // savePolygon(myPolygon);
            startPoint = new Point(0, 0);
        }

        private void UpdateStatusBarText(Point mousePosition)
        {
            // myStatusBar.Content = $"Mouse Position: X={mousePosition.X}, Y={mousePosition.Y}";
            myKoordinates.Content = "X:" + (int)mousePosition.X + "\tY:" + (int)mousePosition.Y;
            infoColor.Content = "Color:" + MyColor.MyLineColor.ToString();
            infoLineThickness.Content = "\nLineThickness: " + MyColor.SelectedLineThickness.ToString();
            infoBackgroundColor.Content = "BackgroundColor:" + MyColor.MyBackgroundColor.ToString();
        }

        private void UpdateBottomStatusBar(Point mousePosition)
        {
            // myStatusBar.Content = $"Mouse Position: X={mousePosition.X}, Y={mousePosition.Y}";
            statusTest.Text = "X:" + (int)mousePosition.X + "\tY:" + (int)mousePosition.Y;
        }








        private void Button_Select_LineThickness_Click(object sender, RoutedEventArgs e)
        {
            LineThicknessWindow lineThicknessWindow = new LineThicknessWindow();
            if (lineThicknessWindow.ShowDialog() == true)
            {
                infoLineThickness.Content = MyColor.SelectedLineThickness.ToString();
            }

        }



        private void Button_Select_Line_Color(object sender, RoutedEventArgs e)
        {
            ColorPickerWindow colorPickerWindow = new ColorPickerWindow();
            // Открываем окно как диалоговое
            if (colorPickerWindow.ShowDialog() == true)
            {
                // Получаем выбранный цвет из окна выбора цвета                
                //SolidColorBrush mySolidColorBrush = new SolidColorBrush(myColorPicker);
                // System.Drawing.Color mySelectColor1 = System.Drawing.Color.FromArgb(myColorPicker.A, myColorPicker.R, myColorPicker.G, myColorPicker.B);
                //System.Windows.MessageBox.Show("Selected Color: " + myColorPicker.A);
            }
            infoColor.Content = "Color:" + MyColor.MyLineColor.ToString();
        }

        private void Button_Select_Background_Click(object sender, RoutedEventArgs e)
        {
            ColorPickerBackground colorPickerBackground = new ColorPickerBackground();
            if (colorPickerBackground.ShowDialog() == true)
            {

            }
            infoBackgroundColor.Content = "BackgroundColor:" + MyColor.MyBackgroundColor.ToString();
        }


        private void Button_Edit_Shape(object sender, RoutedEventArgs e)
        {
            //DialogWindow dialogWindow = new DialogWindow();
            // dialogWindow.ShowDialog();
            SelectColorLineWindow0 selectColorLineWindow0 = new SelectColorLineWindow0();
            selectColorLineWindow0.ShowDialog();
        }


        private void MenuItem_About_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.MessageBox.Show("First Mini Designer\nVersion 1.0\nCreated by Vlad/&Co");
        }

        private void Button_Save(object sender, RoutedEventArgs e)
        {
            /*SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Data Files (*.dat)|*.dat|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog() == true)
            {               
            }*/

            if (shapes.Count == 0)
            {
                System.Windows.MessageBox.Show("There are no shapes for saving.");
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

            if (saveFileDialog.ShowDialog() == true)
            {
                using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName))
                {
                    foreach (Shape shape in shapes)
                    {
                        writer.WriteLine($"Id:{shape.Uid}, " +
                            $"Width:{shape.ActualWidth}, " +
                            $"Height:{shape.ActualHeight}, " +
                            $"Thickness:{((Polygon)shape).StrokeThickness}, " +
                            $"Stroke:{((SolidColorBrush)((Polygon)shape).Stroke).Color}, " +
                            $"Background{shape.Fill}, " +
                            $"Point:{shape.PointFromScreen} ");
                    }
                }
                fileName = saveFileDialog.FileName;
                //UpdateWindowTitle();
            }
        }
     /*   private void savePolygon(Polygon myPolygon)
        {
            if (File.Exists("D:\\Vlad\\СВПП\\20240427\\ColorPickerProject\\ColorPickerProject\\ColorPickerProject\\File1.txt"))
            {
                try
                {
                    using (StreamWriter writer = new StreamWriter("D:\\Vlad\\СВПП\\20240427\\ColorPickerProject\\ColorPickerProject\\ColorPickerProject\\File1.txt"))
                    {
                        foreach (var child in myCanvas.Children)
                        {
                            if (child is Rectangle square)
                            {
                                // Получаем параметры квадрата
                                double x = Canvas.GetLeft(square);
                                double y = Canvas.GetTop(square);
                                double size = square.Width;
                                double thickness = square.StrokeThickness;
                                Color strokeColor = ((SolidColorBrush)square.Stroke).Color;
                                Color fillColor = ((SolidColorBrush)square.Fill).Color;

                                // Записываем параметры квадрата в файл
                                writer.WriteLine($"Id:{myPolygon.Uid}, " +
                            $"Width:{myPolygon.ActualWidth}, " +
                            $"Height:{myPolygon.ActualHeight}, " +
                            $"Thickness:{((Polygon)myPolygon).StrokeThickness}, " +
                            $"Stroke:{((SolidColorBrush)((Polygon)myPolygon).Stroke).Color}, " +
                            $"Background{myPolygon.Fill}, " +
                            $"Point:{myPolygon.PointFromScreen} ");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    System.Windows.MessageBox.Show($"Ошибка при сохранении в файл: {ex.Message}");
                }
            }
            else
            {
                System.Windows.MessageBox.Show("Файла не существует:");
            }
        }

        */

        private void NewCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void NewCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            System.Windows.MessageBox.Show("Open new window");
        }


        /*
        

        private void SavePolygonList_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            List<Polygon> polygons = new List<Polygon>(); // Assume you have a list of polygons
            //polygons = shapes
            string filePath = "polygons.txt"; // Path to save the polygons

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var polygon in shapes)
                {
                    writer.WriteLine($"Polygon: {polygon.Name}, Points: {polygon.PointFromScreen() Points.Count}");
                    foreach (var point in polygon.PointFromScreen)
                    {
                        writer.WriteLine($"X: {point.X}, Y: {point.Y}");
                    }
                    writer.WriteLine(); // Add a blank line to separate polygons
                }
            }

            System.Windows.MessageBox.Show("Polygon list saved successfully.");
        }
        */

    }




}




