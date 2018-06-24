using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Курсовой_по_ОПП.Тетрис
{
  public   class SomeFigure3:Figure
    {
       int position = 0;

        public SomeFigure3(  Color color,  int positionOnFildX,
        int positionOnFildY)
            : base(  color, positionOnFildX, positionOnFildY)
        {
            matrix = new bool[Figure.SizeMatrix][];
            for (int i = 0; i < Figure.SizeMatrix; i++)
            {
                matrix[i] = new bool[Figure.SizeMatrix];
            }

            matrix[0][1] = true;
            matrix[0][2] = true;
            matrix[1][2] = true;
            matrix[2][2] = true;

            countRectangles = CountRectangles();
            Build(color);
        }

       public override void Rotate()
        {
              SetMatrixToNULL();
            switch (position)
            { 
                case 0:
                    {

                        matrix[1][0] = true;
                        matrix[2][0] = true;
                        matrix[1][1] = true;
                        matrix[1][2] = true;
                        position = 1;
                        break;
                    }

                case 1:
                    {

                        matrix[0][1] = true;
                        matrix[1][1] = true;
                        matrix[2][1] = true;
                        matrix[2][2] = true;
                        position = 2;
                        break;
                    }

                case 2:
                    {

                        matrix[2][0] = true;
                        matrix[2][1] = true;
                        matrix[2][2] = true;
                        matrix[1][2] = true;
                        position = 3;
                        break;
                    }
                case 3:
                    {

                        matrix[0][1] = true;
                        matrix[0][2] = true;
                        matrix[1][2] = true;
                        matrix[2][2] = true;
                        position = 0;
                        break;
                    }
            }
            SetPizition();
        }
    }
}
