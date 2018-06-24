using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Курсовой_по_ОПП.Тетрис
{
   public class Line:Figure
    {
         int position = 0;

        static Line()
        {
          
        }
        public Line(  Color color,  int positionOnFildX,
        int positionOnFildY)
            : base(  color, positionOnFildX, positionOnFildY)
        {
            matrix = new bool[Figure.SizeMatrix][];
            for (int i = 0; i < Figure.SizeMatrix; i++)
            {
                matrix[i] = new bool[Figure.SizeMatrix];
            }

            matrix[0][0] = true;
            matrix[0][1] = true;
            matrix[0][2] = true;
            matrix[0][3] = true;

            matrix = matrix;
            countRectangles = CountRectangles();
            Build(color);
        }

       public override void Rotate()
        {
            switch (position)
            {
                case 0:
                    {
                        matrix[0][0] = false;
                        matrix[0][1] = false;
                        matrix[0][2] = false;
                        matrix[0][3] = false;

                        matrix[0][2] = true;
                        matrix[1][2] = true;
                        matrix[2][2] = true;
                        matrix[3][2] = true;
                        position = 1;
                        break;
                    }
                case 1:
                    {
                        matrix[0][2] = false;
                        matrix[1][2] = false;
                        matrix[2][2] = false;
                        matrix[3][2] = false;

                        matrix[0][0] = true;
                        matrix[0][1] = true;
                        matrix[0][2] = true;
                        matrix[0][3] = true;
                        position = 0;
                        break;
                    }
            }
            SetPizition();
        }


    }
}
