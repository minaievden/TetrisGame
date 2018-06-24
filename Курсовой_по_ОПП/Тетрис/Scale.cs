using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Курсовой_по_ОПП.Тетрис
{
   public class Scale
    {
        
            private float offsetX;
            private float offsetY;
            private float scaleX;
            private float scaleY;

            public Scale()
            { }
            public Scale(float offsetX, float offsetY, float scaleX, float scaleY)
            {
                this.offsetX = offsetX;
                this.offsetY = offsetY;

                this.scaleX = scaleX;
                this.scaleY = scaleY;
            }

            public float OffsetX
            {
                get { return offsetX; }
                set { offsetX = value; }
            }

            public float OffsetY
            {
                get { return offsetY; }
                set { offsetY = value; }
            }
            public float ScaleX
            {
                get { return scaleX; }
                set { scaleX = value; }
            }

            public float ScaleY
            {
                get { return scaleY; }
                set { scaleY = value; }
            }
        }
}
