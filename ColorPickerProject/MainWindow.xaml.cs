using Microsoft.Win32;
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

using System.Printing;
using System;
using System.Text.Json.Serialization;
using System.Xml.Serialization;
using System.Net.Http.Json;
using System.Collections.ObjectModel;
using Xceed.Wpf.AvalonDock.Controls;
using System.Reflection;
using System.Runtime.Serialization.Json;

namespace ColorPickerProject
{

    public partial class MainWindow : Window
    {
        string path = "myShapesFile.json";
        private ObservableCollection<CustomPolygon> listPolygons = new ObservableCollection<CustomPolygon>();
        ObservableCollection<CustomPolygon> deserializableListShapes = new ObservableCollection<CustomPolygon>();


        private bool isDrawing = false;
        private Point startPoint;
        private List<CustomPolygon> shapes = new List<CustomPolygon>();
        private CustomPolygon customPolygon = new CustomPolygon();

        // private string currentFileName = null;
        public Color myColorPicker;



        private Point currentMousePosition;

        private Color lineColor;
        private Color bgColor = Colors.White;
        private double lineThickness = 1.0;
        private bool fileExists = false;
        private string fileName = "";
        //CustomPolygon myPolygon;

        public MainWindow()
        {
            InitializeComponent();

            /* CommandBinding saveCommandBinding = new CommandBinding(ApplicationCommands.Save);
             saveCommandBinding.Executed += Save_Executed;
             saveCommandBinding.CanExecute += Save_CanExecute;
             CommandBindings.Add(saveCommandBinding);*/
            /* MySelectColor mySelectColor;*/
            //listPolygons = new ObservableCollection<CustomPolygon>();
            deserializableListShapes = new ObservableCollection<CustomPolygon>();

        }



        private void Canvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Point clickPoint = e.GetPosition(myCanvas);
            Console.Write(myColorPicker.R);
            DrawStar(clickPoint);
            UpdateStatusBarText(clickPoint);
            UpdateBottomStatusBar(clickPoint);
            //myStatusBar.DataContext = clickPoint;
        }

        private void DrawStar(Point startPoint)
        {
            CustomPolygon myCustomPolygon = new CustomPolygon();

            // Создаем экземпляр класса Polygon (наследника Shape)
            Polygon myPolygon = new Polygon();
            myPolygon.Points = new PointCollection() {
            new Point(startPoint.X, startPoint.Y + 10),
            new Point(startPoint.X + 10, startPoint.Y),
            new Point(startPoint.X, startPoint.Y - 10),
            new Point(startPoint.X - 10, startPoint.Y)};

            if (MyColor.SelectedLineThickness == 0)
                myPolygon.StrokeThickness = lineThickness;
            else
            {
                myPolygon.StrokeThickness = MyColor.SelectedLineThickness;
                myCustomPolygon.strokeThickness = MyColor.SelectedLineThickness;
            }
            if (MyColor.MyLineColor.Color == Colors.White)//если не задан - присвоим цвет по умолчанию
            {
                SolidColorBrush brush = new SolidColorBrush(Colors.Black);
                myPolygon.Stroke = brush;
                myCustomPolygon.strokeColor = brush;
                myCustomPolygon.SerializedColorLine = brush.Color.ToString();
            }
            else
            {
                myPolygon.Stroke = MyColor.MyLineColor;
                myCustomPolygon.strokeColor = MyColor.MyLineColor;
                myCustomPolygon.SerializedColorLine = MyColor.MyLineColor.Color.ToString();
            }
            if (MyColor.MyBackgroundColor.Color == Colors.White)
            {
                SolidColorBrush brush = new SolidColorBrush(Colors.Green);
                myPolygon.Fill = brush;
                myCustomPolygon.SerializedColorFill = brush.Color.ToString();
            }//если не задан - присвоим цвет по умолчанию
            else
            {
                myPolygon.Fill = MyColor.MyBackgroundColor;
                myCustomPolygon.fill = MyColor.MyBackgroundColor;
                myCustomPolygon.SerializedColorFill = MyColor.MyBackgroundColor.Color.ToString();
            }
            myCustomPolygon.points = startPoint;
            listPolygons.Add(myCustomPolygon);

            myCanvas.Children.Add(myPolygon);
            // startPoint = new Point(0, 0);

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

            //  if (listPolygons.Count == 0)
            // {
            //      System.Windows.MessageBox.Show("There are no shapes for saving.");
            //      return;
            // }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text files (*.json)|*.json|All files (*.*)|*.*";

            if (saveFileDialog.ShowDialog() == true)
            {
                // Сериализация списка объектов в JSON
                // string json = Serialize(listPolygons);

                // Запись JSON в файл
                //File.WriteAllText(path, json);

     //           System.Windows.MessageBox.Show("Список сохранен в файл polygons.json");

                try
                {
                    if (listPolygons.Count > 0)//если список в файле не пуст
                    {
                        List<CustomPolygon> polygonsFromList = JsonSerializationCustomClass.LoadFromJson(path);//читаем из json-файла

                        if (polygonsFromList != null)//если в json файле есть объекты
                        {
                            // Добавляем новые объекты к существующему списку                   

                            foreach (CustomPolygon p in listPolygons)//проходим по объектам listBox-a  и добавляем его в список для последующей сериализации
                            {
                                polygonsFromList.Add(p);//добавляем каждый объект
                            }
                            //чистим файл
                            JsonSerializationCustomClass.ClearJsonFile(path);
                            // Сохраняем обновленный список объектов обратно в файл
                            JsonSerializationCustomClass.SaveToJson(polygonsFromList, path);
                        }
                        else
                        {
                            //чистим файл
                            JsonSerializationCustomClass.ClearJsonFile(path);
                            JsonSerializationCustomClass.SaveToJson(listPolygons.ToList(), path);// Сохраняем список объектов в файл
                        }

                        System.Windows.MessageBox.Show("Список объектов успешно сохранен в файл JSON.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        System.Windows.MessageBox.Show("Список пуст. Добавьте в список", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
                catch (Exception ex)
                {
                    System.Windows.MessageBox.Show(ex.Message);
                }
            }

        }



        /*
        private void savePolygon(Polygon myPolygon)
        {
            if (File.Exists("File1.txt"))
            {
                try
                {
                    using (StreamWriter writer = new StreamWriter("File1.txt"))
                    {

                        // Записываем параметры квадрата в файл
                        writer.WriteLine($"Id:{myPolygon.Uid}, " +
                    $"Width:{myPolygon.ActualWidth}, " +
                    $"Height:{myPolygon.ActualHeight}, " +
                    $"Thickness:{((Polygon)myPolygon).StrokeThickness}, " +
                    $"Stroke:{((SolidColorBrush)((Polygon)myPolygon).Stroke).Color}, " +
                    $"Background{myPolygon.Fill}");

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
        }*/



        private void NewCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void NewCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            System.Windows.MessageBox.Show("Open new window");
        }



        private void Button_Load(object sender, RoutedEventArgs e)
        {
            myCanvas.Children.Clear();

            // Диалоговое окно для выбора файла
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
            openFileDialog.Filter = "JSON Files (*.json)|*.json|All files (*.*)|*.*";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    // Чтение JSON файла
                    string json = File.ReadAllText(openFileDialog.FileName);

                    // Десериализация JSON в список объектов CustomPolygon
                    List<CustomPolygon> loadedPolygons;
                    using (MemoryStream ms = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(json)))
                    {
                        DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(List<CustomPolygon>));
                        loadedPolygons = (List<CustomPolygon>)serializer.ReadObject(ms);
                    }

                    // Обработка загруженного списка объектов, например, вывод информации или дальнейшая обработка
                    foreach (var polygon in loadedPolygons)
                    {

                        Polygon myP = new Polygon();
                        myP.Points = new PointCollection() {
                             new Point(startPoint.X, startPoint.Y + 10),
                             new Point(startPoint.X + 10, startPoint.Y),
                             new Point(startPoint.X, startPoint.Y - 10),
                             new Point(startPoint.X - 10, startPoint.Y)};

                        
                            myP.StrokeThickness = polygon.strokeThickness;                        
                       
                            SolidColorBrush brush1 = new SolidColorBrush(Colors.Black);
                            myP.Stroke = polygon.strokeColor;                           
                                                     
                      
                       
                            myP.Fill = polygon.fill;                           
                       
                        //myCustomPolygon.points = startPoint;
                       // listPolygons.Add(myCustomPolygon);





                        myCanvas.Children.Add(myP);
                        System.Windows.MessageBox.Show($"Loaded Polygon: Points={polygon.points}, StrokeThickness={polygon.strokeThickness}, StrokeColor={polygon.strokeColor.Color}, FillColor={polygon.fill.Color}");
                    }
                }
                catch (Exception ex)
                {
                    System.Windows.MessageBox.Show($"An error occurred while loading polygons: {ex.Message}");
                }
            }
        }


    }
}











