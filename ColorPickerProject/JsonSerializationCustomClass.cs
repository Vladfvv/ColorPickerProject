using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Shapes;

namespace ColorPickerProject
{
    class JsonSerializationCustomClass
    {
        // Метод для сохранения списка объектов в файл JSON
        public static void SaveToJson(List<CustomPolygon> list, string path)
        {
            try
            {
                var options = new JsonSerializerOptions
                {
                    WriteIndented = true // Добавляем отступы для удобочитаемости
                };

                string json = JsonSerializer.Serialize(list, options);
                File.AppendAllTextAsync(path, json);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при сохранении файла JSON: " + ex.Message);
            }
        }


        public static List<CustomPolygon> LoadFromJson(string path)
        {
            try
            {
                string jsonString = File.ReadAllText(path);
                return JsonSerializer.Deserialize<List<CustomPolygon>>(jsonString);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при чтении файла JSON: " + ex.Message);
                return null;
            }
        }
        public static void ClearJsonFile(string filePath)
        {
            File.WriteAllText(filePath, string.Empty);
        }
    }
}
