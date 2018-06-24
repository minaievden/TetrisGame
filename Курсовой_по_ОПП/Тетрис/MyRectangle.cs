using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Курсовой_по_ОПП.Тетрис
{
   public class MyRectangle
    {
        SolidBrush brush;
        int positionOnFildX;
        int positionOnFildY;

       public int  PositionOnFildX
       {
           get { return positionOnFildX; }
           set { positionOnFildX = value; }
       }

       public int PositionOnFildY
       {
           get { return positionOnFildY; }
           set { positionOnFildY = value; }
       }

        public MyRectangle(Color color,int positionOnFildX,
        int positionOnFildY)
        {
            this.positionOnFildX = positionOnFildX;
            this.positionOnFildY = positionOnFildY;
            this.brush = new SolidBrush(color);
        }

        public void Draw()
        {
            DrowingField.FillRectangle(positionOnFildX, positionOnFildY, brush);
        }

        public void WipeOff()
        {
            DrowingField.VipeOffRectangle(positionOnFildX, positionOnFildY);
        }


      public Color color
      {
          get { return brush.Color; }
          set { brush.Color = value; }
      }


    }
}
