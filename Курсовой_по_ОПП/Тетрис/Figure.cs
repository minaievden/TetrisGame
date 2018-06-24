using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Курсовой_по_ОПП.Тетрис
{
   public class Figure
    {
       protected static byte sizeMatrix = 4;

       protected bool[][] matrix;
       protected MyRectangle[] rectangles;
       protected int countRectangles;
       int positionOnFildX;
       int positionOnFildY;

       public int PositionOnFildX
       {
           get { return positionOnFildX; }
           set { positionOnFildX = value;
           SetPizition();
           }
       }

       public int PositionOnFildY
       {
           get { return positionOnFildY; }
           set { positionOnFildY = value;
           SetPizition();
           }
       }

       public MyRectangle[] Rectangles
       {
           get { return rectangles; }
       }
       public Figure( bool[][] matrix, Color color,  int positionOnFildX,
        int positionOnFildY)
       {
           this.positionOnFildX = positionOnFildX;
           this.positionOnFildY = positionOnFildY;
           this.matrix = matrix;
           countRectangles = CountRectangles();
           Build( color); 
       }

       public Figure( Color color, int positionOnFildX,
     int positionOnFildY)
       {
           this.positionOnFildX = positionOnFildX;
           this.positionOnFildY = positionOnFildY;
       }
     protected void Build( Color color)//построение прямоугольников
       {
           rectangles = new MyRectangle[countRectangles];
           int i = 0, j=0, numberRectangl=0;
           for (i = 0; i < sizeMatrix; i++)
           {
               for (j = 0; j < sizeMatrix; j++)
               {
                   if (matrix[i][j] == true)
                   {
                       rectangles[numberRectangl] = new MyRectangle(color, i + positionOnFildX, j + positionOnFildY);//определяем место прямоугольника висчитивая его относительно 2х матриц
                       numberRectangl++;
                   }
               }
           }
       }

     protected void SetMatrixToNULL()
     {
         int i,j;
         for (i = 0; i < sizeMatrix; i++)
         {
             for (j = 0; j < sizeMatrix; j++)
             {
                 matrix[i][j] = false;
             }
         }
     }

       protected void SetPizition()//изменение положения прямоугольников внутри матрици после изменения матрици
       {
           int i = 0, j = 0, numberRectangl = 0;
           for (i = 0; i < sizeMatrix; i++)
           {
               for (j = 0; j < sizeMatrix; j++)
               {
                   if (matrix[i][j] == true)
                   {
                       rectangles[numberRectangl].PositionOnFildX = i + positionOnFildX;
                       rectangles[numberRectangl].PositionOnFildY = j + positionOnFildY;
                       numberRectangl++;
                   }
               }
           } 
       }

      protected int CountRectangles()
       {
            int countRectangles = 0;
           int i = 0, j = 0;

           for (i = 0; i < sizeMatrix; i++)
           {
               for (j = 0; j < sizeMatrix; j++)
               {
                   if (matrix[i][j] == true)
                   {
                        countRectangles++;

                   }
               }
           }
           return countRectangles;
       }

       public void Draw()
       {
           for (int i = 0; i < countRectangles; i++)
           {
               rectangles[i].Draw();
           }
       }

       public void WipeOff()
       {
           for (int i = 0; i < countRectangles; i++)
           {
               rectangles[i].WipeOff();
           }
       }

        public bool[][] Matrix
        {
            get { return matrix; }
            set { matrix = (bool [][])value.Clone(); SetPizition(); }
        }

        public virtual void Rotate()
        { 
           
        }

        public static byte SizeMatrix
        {
            get { return sizeMatrix; }
        }

    }
}
