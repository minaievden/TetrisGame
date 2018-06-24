using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Курсовой_по_ОПП.Тетрис
{
   public class Square : Figure
    {
        public Square  (  Color color,  int positionOnFildX,
        int positionOnFildY)
            : base(  color, positionOnFildX, positionOnFildY)
        {
            matrix = new bool[Figure.SizeMatrix][];
            for (int i = 0; i < Figure.SizeMatrix; i++)
            {
                matrix[i] = new bool[Figure.SizeMatrix];
            }

            matrix[1][1] = true;
            matrix[2][1] = true;
            matrix[1][2] = true;
            matrix[2][2] = true;

            countRectangles = CountRectangles();
            Build(color);
        }

       public override void Rotate()
        {
        }


    }
}
