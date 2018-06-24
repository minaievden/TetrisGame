using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Курсовой_по_ОПП.Тетрис
{
    public static class DrowingField
    {
        private static bool drow=true;
        private static Graphics drowArea;
        private static Pen wipePen = new Pen(Color.White, 2);
        private static Pen pen = new Pen(Color.Black, 2);
        private static SolidBrush wipeBrush = new SolidBrush(Color.White);
        private static SolidBrush brush = new SolidBrush(Color.Black);
        private static Font font =new Font ("Times New Roman",10);

        private static int staticWidth = 228;
        private static int staticHeight = 454;
        private static int staticSizeOfFigure = 15;

        public static int StaticSizeOfFigure
        {
            get { return staticSizeOfFigure; }
            set { staticSizeOfFigure = value; }
        }

        public static int StaticWidth 
        {
            get { return staticWidth; }
            set { staticWidth = value; }
        }

        public static int StaticHeight
        {
            get { return staticHeight; }
            set { staticHeight = value; }
        }


        private static float offsetX;
        private static float offsetY;
        private static float scaleX;
        private static float scaleY;
        private static int width;
        private static int height;

        public static Graphics ThisGraphics
        {
            get { return drowArea; }
            set { drowArea = value; }
        }

        public static void Line (int x1, int y1 , int x2,int y2)
        {
            drowArea.DrawLine(pen, x1 * scaleX + offsetX+2, y1 * scaleY + offsetY, x2 * scaleX + offsetX+2, y2 * scaleY + offsetY);
        }

        public static void SetArea(Graphics gr, Color beckgroungKolor, int width1, int height1, int offsetX1, int offsetY1, float penWidth = 2)
        {
            if (drowArea != null)
                Clear();

            Scale scale = CountScale.CountNewSkale(staticWidth, staticHeight, width1, height1, offsetX1, offsetY1);
            width=width1;
            height = height1;
            offsetX = (int)scale.OffsetX;
            offsetY = (int) scale.OffsetY;
            scaleX = scale.ScaleX;
            scaleY = scale.ScaleY;
            drowArea = gr;
            wipePen.Color = beckgroungKolor;
            wipePen.Width = penWidth;
            wipeBrush.Color = beckgroungKolor;
        }


        public static void FillRectangle(int x, int y, int height, int width, Brush brush, Pen pen)
        {
            try
            {
                drowArea.FillRectangle(brush, +x * width * scaleX+2 + offsetX+1, y * height * scaleY + offsetY+1, width * scaleX-2, height * scaleY-1);
              //  drowArea.DrawRectangle(pen, +x * width * scaleX +2+ offsetX, y * height * scaleY +2  + offsetY, width * scaleX, height * scaleY);
            }
            catch (Exception ex)
            {
            }
        }
        public static void VipeOffRectangle(int x, int y, int height, int width, int widthPen)
        {
            try
            {
                drowArea.FillRectangle(wipeBrush, +x * width * scaleX+2 + offsetX+1, y * height * scaleY + offsetY+1, width * scaleX-2 + widthPen, height * scaleY-1 );
            }
            catch (Exception ex)
            {
            }
        }

        public static void OutText(int x, int y, string str, int staticSizeOfFigure)
        {
            try
            {
                drowArea.FillRectangle(wipeBrush, x * staticSizeOfFigure * scaleX+2, y * staticSizeOfFigure * scaleY, x * scaleX * str.Length , y * staticSizeOfFigure/2 * scaleY+10);
                drowArea.DrawString(str, font, brush, x * staticSizeOfFigure *scaleX+2, y * staticSizeOfFigure*scaleY);
            }
            catch (Exception ex)
            {
            }
        }

        public static void OutText(int x, int y, string str, int staticSizeOfFigure, int size )
        {
            try
            {
               // drowArea.FillRectangle(wipeBrush, x * staticSizeOfFigure * scaleX, y * staticSizeOfFigure * scaleY, x * staticSizeOfFigure * scaleX * str.Length * 5, y * staticSizeOfFigure * scaleY + 10);
                drowArea.DrawString(str,  new Font ("Times New Roman",size), brush, x * staticSizeOfFigure * scaleX, y * staticSizeOfFigure * scaleY);
            }
            catch (Exception ex)
            {
            }
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

        public static Coordinate Translate(float X, float Y)
        {
            return new Coordinate((X-offsetX) / scaleX, (Y-offsetY) / scaleY);
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
           // get { drowArea = value; }
            set { drowArea = value; }
        }
    }
}

