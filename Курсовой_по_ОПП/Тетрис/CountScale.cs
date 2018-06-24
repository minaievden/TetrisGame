using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Курсовой_по_ОПП.Тетрис
{
     public static class CountScale
    {
        public static Scale CountNewSkale(int width, int height, int newWidth, int NewHeight, int offsetX, int offsetY)
         {
             float x = (float)(newWidth - offsetX - 100) / (width);
             float y = (float)(NewHeight - offsetY - 50) / (height);

             if (x > y)
             {
                 x = y;
             }
             else
             {
                 y = x;
             }

             return new Scale(offsetX, offsetY, x, y);
         }
    }
}
