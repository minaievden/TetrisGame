using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Курсовой_по_ОПП.Тетрис
{
    class Field
    {
      List<MyRectangle> rectangle;

      protected int staticCountRectX = 15;//количество прямоугольников помещающихся
      protected int staticCountRectY = 30;//по x y в большой матрице 
      protected int countOfLines = 0;//количество собраних линий
      protected int prevCountOfLine = 0;//количество до обнуления
      protected int distanceXForOutData = 2;
      protected int distanceYForOutData = 2;
      protected bool[][] matrix;


      public Field()
      {
          matrix = new bool[staticCountRectX][];
          for (int i = 0; i < staticCountRectX; i++)
              matrix[i] = new bool[staticCountRectY];
          rectangle = new List<MyRectangle>(0);
      }

      public bool GetFiveLines//проверяет было ли собрано 5 линий
      {
          get { if (countOfLines - prevCountOfLine >= 5) return true;
              return false; }
          set { if (value == false) prevCountOfLine = countOfLines; }
      }

      public void DrowNextFigure(Figure figure, int level)//рисует следующую фигуру справа и упровни
      {
          int x = figure.PositionOnFildX, y = figure.PositionOnFildY;
          figure.PositionOnFildX = (staticCountRectX + distanceXForOutData);
          figure.PositionOnFildY = (distanceYForOutData);
          figure.Draw();
          figure.PositionOnFildX = x; figure.PositionOnFildY = y;
          DrowingField.OutText(staticCountRectX + distanceXForOutData+1, distanceYForOutData + 12, "Линии: " + countOfLines.ToString(), DrowingField.StaticSizeOfFigure);
          DrowingField.OutText(staticCountRectX + distanceXForOutData + 1, distanceYForOutData + 14, "Уровень: " + level.ToString(), DrowingField.StaticSizeOfFigure);
      }

      public void ShowGameIsOver()
      {
          DrowingField.OutText(3, staticCountRectY / 2+4, "Game is over! ", DrowingField.StaticSizeOfFigure, 20);
      }

      public void WipeOffNextFigure(Figure figure)//стирает фигуру нарисованную справа
      {
          int x = figure.PositionOnFildX, y = figure.PositionOnFildY;
          figure.PositionOnFildX = (staticCountRectX + distanceXForOutData);
          figure.PositionOnFildY = (distanceYForOutData);
          figure.WipeOff();
          figure.PositionOnFildX = x; figure.PositionOnFildY = y;
      }
     
           public void DrowBorders()
        {
            DrowingField.Line(DrowingField.StaticWidth, 0, DrowingField.StaticWidth, DrowingField.StaticHeight);
            DrowingField.Line(0, DrowingField.StaticHeight, DrowingField.StaticWidth, DrowingField.StaticHeight);
            DrowingField.Line(0, 0, DrowingField.StaticWidth, 0);
            DrowingField.Line(0, 0, 0, DrowingField.StaticHeight);
          
        }

      public int StaticSizeOfFigure
      {
          get { return DrowingField.StaticSizeOfFigure; }
      }

        public void AddFigure(Figure figure)//забираем у фигуры прямоугольники и передаем их полю
        {
            figure.Draw();
            MyRectangle [] rect=figure.Rectangles;
            int i=0, countRect=rect.Length;
            for(i=0;i<countRect;i++)
            {
                rectangle.Add(rect[i]);
                matrix[rect[i].PositionOnFildX][rect[i].PositionOnFildY] = true;
            }
            rect=null;
        }

     
        public void Draw()//прорисовка прямоугольников принадлежащих полю 
        {
            for (int i = 0; i < rectangle.Count; i++)
            {
                rectangle[i].Draw();
            }
        }

        public void CheckLine()//проверка заполненых линих
        {
            bool flag = false;
            bool ollRectangles = true;
           // int countInLine = 0;
            for (int i = 0; i < staticCountRectY; i++)
            {
                for (int j = 0; j < staticCountRectX; j++)
                {
                    ollRectangles = true;
                    if (matrix[j][i] == false)
                    {
                        ollRectangles = false;
                        break;
                    }
                    
                }
                if (ollRectangles == true)
                {
                    DeleteLine(i);
                    flag = true;   
                    countOfLines++;
                }
            }
            if (flag == true)
            {
                this.Cliear();
                this.DrowBorders();
               this.Draw(); 
            }
           
        }

         void DeleteLine(int y)//удаление линий которые заполнены
         {
             int i = 0, j = 0;
             for( j=y;j>1;j-- )
             {
               for (i = 0; i < staticCountRectX; i++)
               {
                   matrix[i][j] = matrix[i][j - 1];//то что было выше приравниваем тому, что ниже в матрице где хранятся прямоугольники
               }
             }
             for (i = 0; i < staticCountRectX; i++)
             {
                 matrix[i][0] = false;//самую верхнюю строку делаем false
             }

             for (j = 0; j < rectangle.Count*2; j++)
                 for (i = 0; i < rectangle.Count; i++)
                 {
                     if (rectangle[i].PositionOnFildY == y)
                     {
                         rectangle.RemoveAt(i);//удаление прямоугольников принадлежащих удаляемой линии из массива прямоугольников
                         i = 0;
                     }
                 }

                 for (i = 0; i < rectangle.Count; i++)
                 {
                     if (rectangle[i].PositionOnFildY<y)
                    rectangle[i].PositionOnFildY = rectangle[i].PositionOnFildY + 1;//смещение прямоугольнико стоящих в массиве выше удаляемых на 1 вниз
                 }

         }

         public void RotateFigure( ref Figure figure)
         {
             int x = figure.PositionOnFildX;
             int lenght = figure.Rectangles.Length;
             bool[][] m = new bool [Figure.SizeMatrix][];

             for (int i = 0; i < Figure.SizeMatrix; i++)
             {
                 m[i] = new bool[Figure.SizeMatrix];
             }
             for (int i = 0; i < Figure.SizeMatrix; i++)
                 for (int j = 0; j < Figure.SizeMatrix; j++)
                     m[i][j] = figure.Matrix[i][j];

         
             figure.Rotate();

                 for (int i = 0; i < lenght; i++)
                 {
                     
                    if (figure.Rectangles[i].PositionOnFildX > staticCountRectX - 1)//если фигура при повороте выходит за пределы правого края
                     {
                        /* if (KanToLeft(figure))
                         {
                             figure.PositionOnFildX -= 1;
                             flag = true;
                             break;
                         }
                         else
                         {
                             figure.Matrix = m;
                             figure.PositionOnFildX = x;
                             flag = false;
                             break;
                         }*/
                         figure.PositionOnFildX += staticCountRectX - 1 - figure.Rectangles[i].PositionOnFildX;//сдвигаем ее влево на стольно, на сколько она выступает
                    
                     }

                     if (figure.Rectangles[i].PositionOnFildX < 0)//аналогично
                     {
                        /* if (KanToRight(figure))
                         {
                             figure.PositionOnFildX += 1;
                             flag = true;
                             break;
                         }
                         else
                         {
                             figure.Matrix = m;
                             figure.PositionOnFildX = x;
                             flag = false;
                             break;
                         }*/
                         figure.PositionOnFildX -= figure.Rectangles[i].PositionOnFildX;
                     }
                 }

             if (KanToDrow(figure) == false||figure.PositionOnFildY>staticCountRectY)//если фигура не быть нарисованна
             {
                 figure.Matrix = m;//возвращаем все
                 figure.PositionOnFildX = x;//как было
             }

         }
       

         public bool KanToMuve(Figure figure, int mode)
         {
             switch (mode)
             {
                 case 1:
                     { 
                         return KanToLeft(figure); }
                 case 2:
                     { return KanToRight(figure); }
                 case 3:
                     { return !IsStop(figure); }//если не остановилась, то можно двигать фигуру вниз
                 default: { throw new Exception(); }
             }
         }

         bool KanToLeft(Figure figure)
         {
          //   bool isStop = true ;
             MyRectangle[] rec = figure.Rectangles;
             int countRec = rec.Length;
             for (int i = 1; i < staticCountRectX; i++)
                 for (int j = 0; j < staticCountRectY - 1; j++)
                     for (int k = 0; k < countRec; k++)
                     {
                         try
                         {
                            // if (rec[k].PositionOnFildX >= staticCountRectX)
                            // {
                              //   if (rec[k].PositionOnFildX <= 0 || matrix[rec[k].PositionOnFildX - 1 - (rec[k].PositionOnFildX-staticCountRectX)][rec[k].PositionOnFildY] == true)//если фигура вышла или равна краю и левее от нее есть фигура
                              //   {
                                 //    return false; // isStop = false;
                                    // break;
                              //   }
                           //  }
                            // else
                                 if (rec[k].PositionOnFildX <= 0 || matrix[rec[k].PositionOnFildX - 1][rec[k].PositionOnFildY] == true)
                                 {
                                   //  isStop = false;
                                   //  break;
                                     return false;
                                 }
                         }
                         catch (Exception ex)
                         {
                             return false;
                         }
                     }
             return true;
         }
         bool KanToRight(Figure figure)
         {
             MyRectangle[] rec = figure.Rectangles;
             int countRec = rec.Length;
             for (int i = 0; i < staticCountRectX-1; i++)
                 for (int j = 0; j < staticCountRectY - 1; j++)
                     for (int k = 0; k < countRec; k++)

                      //   if (rec[k].PositionOnFildX <=0)
                      //   {
                                //        if ( rec[k].PositionOnFildX >= staticCountRectX - 1 || matrix[-rec[k].PositionOnFildX+1][rec[k].PositionOnFildY] == true )
                               //  {
                                //     isStop = false;
                                  //   break;
                                // }
                       //  }
                        // else
                         if ( rec[k].PositionOnFildX >= staticCountRectX - 1 || matrix[rec[k].PositionOnFildX+1][rec[k].PositionOnFildY] == true )//если фигура  не выходит за правый край и не надходится в крайней позиции и справа от фигуры нет других фигур
                         {
                             //trueisStop = false ;
                             return false;
                            // break;
                         }
                     
             return true;
         }



         public bool IsStop(Figure figure)//проверка на движение фигуры вниз
         { 
             //bool isStop=false;
             MyRectangle [] rec= figure.Rectangles;
             int countRec = rec.Length;
             for (int i = 0; i < staticCountRectX;i++ )
                 for (int j = 0; j < staticCountRectY-1; j++)
                     for (int k = 0; k < countRec; k++)
                     {
                         if ( rec[k].PositionOnFildY == staticCountRectY - 1 ||matrix[ rec[k].PositionOnFildX] [ rec[k].PositionOnFildY+1]==true)//если фигура не не находится в крайней позиции и внизу ее нет других фигур
                         {
                            // isStop = true;
                             return true;
                           //  break;
                         }
                     }
                 return false;
         }

         public void SetAreaSize()//установка области для вывода
         {
             DrowingField.StaticHeight = staticCountRectY * DrowingField.StaticSizeOfFigure-1;
             DrowingField.StaticWidth = staticCountRectX * DrowingField.StaticSizeOfFigure-2;
         }

         public void Cliear()
         {
             DrowingField.Clear();
         }

         public int CountOfLines
         {
             get { return countOfLines; }
             set { countOfLines = value; }
         }

         public int StaticCountRectX
         {
             get { return staticCountRectX; }
             set { staticCountRectX = value; }
         }

         public bool KanToDrow(Figure figure)//проверяет можно ли нарисовать фигуру
         { 
            MyRectangle [] rect=figure.Rectangles ;
             int k=0,size=rect.Length;
                    for (k = 0; k < size; k++)
                    {
                        try
                        {
                            if (matrix[rect[k].PositionOnFildX][rect[k].PositionOnFildY])
                            {
                                return false;
                            }
                        }
                        catch (Exception ex)
                        {
                            return false;
                        }
                    }
                    return true;
         }

    }
}
