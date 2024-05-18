using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows;

namespace ColorPickerProject
{
   // Пользовательский элемент, который наследуется от System.Windows.UIElement и реализует логику отображения полигона
    public class CustomPolygonElement : UIElement
    {
        private CustomPolygon customPolygon;

        public CustomPolygonElement(CustomPolygon polygon)
        {
            customPolygon = polygon;
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);

           // if (customPolygon.pointsCollection.Count < 2)
           //     return;
           /*
            Point startPoint = customPolygon.points;
            StreamGeometry streamGeometry = new StreamGeometry();
            List<Point> listPoints = new List<Point>();
            listPoints.Add(new Point(startPoint.X, startPoint.Y + 10));
            listPoints.Add(new Point(startPoint.X + 10, startPoint.Y));
            listPoints.Add(new Point(startPoint.X, startPoint.Y - 10));
            listPoints.Add(new Point(startPoint.X-10, startPoint.Y));     




            using (StreamGeometryContext geometryContext = streamGeometry.Open())
            {
                geometryContext.BeginFigure(startPoint, true, true);

                for (int i = 0; i < listPoints.Count; i++)
                {
                    geometryContext.LineTo(listPoints[i], true, true);
                }
            }
            

            //drawingContext.DrawGeometry(Brushes.Black, new Pen(Brushes.Black, 1), streamGeometry);
            drawingContext.DrawGeometry(MyColor.MyBackgroundColor, new Pen(MyColor.MyLineColor, MyColor.SelectedLineThickness), streamGeometry);*/
        }











        /*
        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);

            if (customPolygon.pointsCollection.Count < 2)
                return;

            Point startPoint = customPolygon.pointsCollection[0];
            StreamGeometry streamGeometry = new StreamGeometry();

            using (StreamGeometryContext geometryContext = streamGeometry.Open())
            {
                geometryContext.BeginFigure(startPoint, true, true);

                for (int i = 1; i < customPolygon.pointsCollection.Count; i++)
                {
                    geometryContext.LineTo(customPolygon.pointsCollection[i], true, true);
                }
            }


            //drawingContext.DrawGeometry(Brushes.Black, new Pen(Brushes.Black, 1), streamGeometry);
            drawingContext.DrawGeometry(MyColor.MyBackgroundColor, new Pen(MyColor.MyLineColor, MyColor.SelectedLineThickness), streamGeometry);
        }

        */

























    }
}
