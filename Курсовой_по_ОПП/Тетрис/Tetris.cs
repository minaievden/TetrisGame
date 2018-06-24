using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Timers;

namespace Курсовой_по_ОПП.Тетрис
{
    class Tetris
    {
      protected  System.Windows.Forms.Timer timer;
      protected int interval = 500;
      protected Field field;
      protected Figure figure;
      protected Figure nextFigure;
      protected bool GameIsOver = false;
      protected static Color[] colors = { Color.DodgerBlue, Color.DeepPink, Color.LimeGreen, 
                                    Color.DarkOrchid, Color.Tomato, Color.OrangeRed, 
                                    Color.Crimson, Color.MediumSpringGreen, Color.SlateBlue };
      protected static Random rand;
      protected int level = 1;

        static Tetris()
        {
            rand = new Random();
        }

        public bool gameIsOver
        {
             get {return GameIsOver;}
        }

        public int CountOfLines
        {
            get { return field.CountOfLines; }
        }
       public Tetris(int level)
        {
            field =new Field ();
            field.SetAreaSize();
            figure = null ;

            this.timer = new System.Windows.Forms.Timer();
            this.timer.Tick += new System.EventHandler(this.TimerTic);
            Level = level;
           
        }

       public void Stop()
       {
           timer.Stop();
       }

       public void Start()
       {
           timer.Start();
       }

       private void TimerTic(object sender, EventArgs e)//сработал таймер
       {
         //  if(gameIsOver==f)
               WipeOffFigure();//стираем фигуру
               MuveFigure();//двигаем фиру вниз
               DrowFigure();//рисуем фигуру
       }

        public void SetArea(Graphics gr, Color beckgroungKolor, int width1, int height1, int offsetX, int offsetY)//определяет параметры для вывода
        {
            DrowingField.SetArea(gr, beckgroungKolor, width1, height1, offsetX, offsetY);
        }

        public void DrawOllField()
        {
            field.Draw();
            field.DrowBorders();
            figure.Draw();
            field.DrowNextFigure(nextFigure, level);

            if (gameIsOver == true)
                field.ShowGameIsOver();
        }
        public void GenerateFigure ()
        {
            if (GameIsOver == false)
            {
                if (figure == null)//первая фигура всегда линия
                {
                    figure = new Line(colors[rand.Next(0,colors.Length-1)], field.StaticCountRectX / 2, 0);
                }
                else
                {
                    field.WipeOffNextFigure(nextFigure);//стирает фигуру нарисованную справа
                    figure = null; figure = nextFigure;//текущая фигура = следующая
                    if (field.IsStop(figure))//если созданная фигура только что созданная останавливается, то конец игры
                    {
                        GameIsOver = true;
                        field.ShowGameIsOver();
                        timer.Stop();
                    }
                }
                nextFigure = null;
                switch(rand.Next(0,6))
                {

                    case 0: { nextFigure = new SomeFigure1(colors[rand.Next(0, colors.Length - 1)], field.StaticCountRectX / 2, 0); break; }
                    case 1: { nextFigure = new SomeFigure2(colors[rand.Next(0, colors.Length - 1)], field.StaticCountRectX / 2, 0); break; }
                    case 2: { nextFigure = new SomeFigure3(colors[rand.Next(0, colors.Length - 1)], field.StaticCountRectX / 2, 0); break; }
                    case 6: { nextFigure = new SomeFigure4(colors[rand.Next(0, colors.Length - 1)], field.StaticCountRectX / 2, 0); break; }
                    case 4: { nextFigure = new SomeFigure5(colors[rand.Next(0, colors.Length - 1)], field.StaticCountRectX / 2, 0); break; }
                    case 5: { nextFigure = new Line (colors[rand.Next(0, colors.Length - 1)], field.StaticCountRectX / 2, 0); break; }
                    case 3: { nextFigure = new Square (colors[rand.Next(0, colors.Length - 1)], field.StaticCountRectX / 2, 0); break; } 
               }
                if (field.GetFiveLines == true && level < 4)//наращиваем уровень если можно
                { Level += 1; field.GetFiveLines = false; }
                field.DrowNextFigure(nextFigure,level);//рисуем следующую фигуру
                
            }
        }

        public bool MuveFigure()//функция движения фигуры
        {
           bool rez =  field.IsStop(figure);
           if (!rez)//если фигура может двигаться вниз
           {
               figure.PositionOnFildY = figure.PositionOnFildY + 1;//двигаем
           }
           else
           {
               field.AddFigure(figure);//иначе передаем ее полю для расформирования
               field.CheckLine();//проверяем заполненные линии
               GenerateFigure();//создаем следующую фигуру
           }
           return rez;
        }

        public void Muve(int mode)//функция вызывается по нажатию клавиш управления
        {
            if (field.KanToMuve(figure,mode))//можно ли сдвинуть фигуру
            {
                figure.WipeOff();
                switch (mode)
                {
                    case 1: {figure.PositionOnFildX -= 1;break;}
                    case 2: {figure.PositionOnFildX += 1; break;}
                    case 3: { figure.PositionOnFildY += 1; break; }
                }
                figure.Draw();
            }
        }

        public void WipeOffFeeld()
        {
            field.Cliear();
        }

        public void Rotate()
        {
           field.RotateFigure( ref figure);
        }

        public void DrowFigure()
        {
                figure.Draw();
        }

        public void WipeOffFigure()
        {
          figure.WipeOff();
        }

      public  int Level
        {

            get { return level; }
            set
            {
                if (value > 4 && value < 0) throw new Exception();
                level = value;
                timer.Interval = interval - level * 100;
            }
        }
        public void Dispose()//удаление тетриса
        {
            timer.Stop();
            field = null;
            timer.Dispose();
            figure = null;
        }
    }
}
