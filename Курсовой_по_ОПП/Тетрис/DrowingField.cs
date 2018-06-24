using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Курсовой_по_ОПП.Тетрис
{
    public static class DrowingField
    {
        private static Graphics drowArea;//площадь в которой рисуется поле для игры
        private static Pen pen = new Pen(Color.Black, 2);//рисует линии
        private static SolidBrush wipeBrush = new SolidBrush(Color.White);//закрашивает прямоугольники
        private static SolidBrush brush = new SolidBrush(Color.Black);//рисует текст
        private static Font font = new Font("Times New Roman", 12);

        private static int staticWidth ;//ширина матрицы для рисования тетриса
        private static int staticHeight ;
        private static int staticSizeOfFigure = 15;// статический размер блока нужен для высчитывания длинны и ширины поля для вывода (виртуальных)

        private static float offsetX;//смещение по коорди нате Х
        private static float offsetY;
        private static float scaleX;//масштабирование по Х
        private static float scaleY;
        private static int width;//ширина всего окна
        private static int height;

        public static int StaticSizeOfFigure
        {
            get { return staticSizeOfFigure; }
            set { staticSizeOfFigure = value; }
        }

        public static Graphics ThisGraphics
        {
            get { return drowArea; }
            set { drowArea = value; }
        }

        public static void Line(int x1, int y1, int x2, int y2)
        {
            drowArea.DrawLine(pen, x1 * scaleX + offsetX+1 , y1 * scaleY + offsetY, x2 * scaleX + offsetX+1 , y2 * scaleY + offsetY);
        }

        public static void SetArea(Graphics gr, Color beckgroungKolor, int width1, int height1, int offsetX1, int offsetY1, float penWidth = 2)
        {
            if (drowArea != null)
                Clear();

            Scale scale = CountScale.CountNewSkale(staticWidth, staticHeight, width1, height1, offsetX1, offsetY1);
            width = width1;
            height = height1;
            offsetX = (int)scale.OffsetX;
            offsetY = (int)scale.OffsetY;
            scaleX = scale.ScaleX;
            scaleY = scale.ScaleY;
            drowArea = gr;
            wipeBrush.Color = beckgroungKolor;
        }


        public static void FillRectangle(float x, float y, Brush brush)//рисуем прямоугольник для фигуры
        {
            try
            {
                drowArea.FillRectangle(brush, x * staticSizeOfFigure * scaleX + 3 + offsetX , y * staticSizeOfFigure * scaleY + offsetY + 1, staticSizeOfFigure * scaleX - 2, staticSizeOfFigure * scaleY - 1);//масштабирование и вывод на экран прямоугольника
            }
            catch (Exception ex)
            { }
        }
        public static void VipeOffRectangle(float x, float y)//стираем прямоугольник
        {
            try
            {
                drowArea.FillRectangle(wipeBrush, x * staticSizeOfFigure * scaleX + 3 + offsetX , y * staticSizeOfFigure * scaleY + offsetY + 1, staticSizeOfFigure * scaleX - 2, staticSizeOfFigure * scaleY - 1);//закрашиваем в цвет фона
            }
            catch (Exception ex)
            {}
        }

        public static void OutText(int x, int y, string str, int staticSizeOfFigure)
        {
            try
            {
                drowArea.FillRectangle(wipeBrush, x * staticSizeOfFigure * scaleX + 2, y * staticSizeOfFigure * scaleY, x * scaleX * str.Length, y * staticSizeOfFigure / 2 * scaleY + 10);
                drowArea.DrawString(str, font, brush, x * staticSizeOfFigure * scaleX + 2, y * staticSizeOfFigure * scaleY);
            }
            catch (Exception ex)
            { }
        }

        public static void OutText(int x, int y, string str, int staticSizeOfFigure, int size)
        {
            try
            {
                drowArea.DrawString(str, new Font("Times New Roman", size), brush, x * staticSizeOfFigure * scaleX, y * staticSizeOfFigure * scaleY);
            }
            catch (Exception ex)
            { }
        }

        public static Scale AreaScale
        {
            get { return new Scale(offsetX, offsetY, scaleX, scaleY); }
            set
            {
                offsetX = value.OffsetX;
                offsetY = value.OffsetY;
                scaleX = value.ScaleX;
                scaleY = value.ScaleY;
            }
        }

        public static void Clear()
        {
            drowArea.Clear(wipeBrush.Color);
        }
        public static int Width
        {
            get { return width; }
        }
        public static Graphics DrowArea
        {
            set { drowArea = value; }
        }

        public static int StaticWidth
        {
            get { return staticWidth; }
            set { staticWidth = value + 4; }
        }

        public static int StaticHeight
        {
            get { return staticHeight; }
            set { staticHeight = value + 4; }
        }

    }
}