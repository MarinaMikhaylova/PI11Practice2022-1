using System;
using System.Threading;

namespace MoonLander
{
    class Program
    {
        static void Print(int y, string s)
        {

            Console.CursorTop = y;
            Console.Write(s);
        }

        static void Main(string[] args)
        {
            //double d = 0;  //текущее ускорение
            double t = 1;  //время
            const double h = 250;  // изночальная высота
            double hnew = h; //высота в текущий момент
            double f = 60;  //топливо
            double v = 0;  //скорость
            const double CRUSH_SPEED = 10;
            const double g = -1.625;  //ускорение падения
            const double a = 2;  //ускорение при работе двигателя
            bool onDrive; //признак работы двигателя
            int y = 1;
            int count = 0;
            //  основной цикл
            while (hnew>=0.0000001)
            {
                //ввод пользователя и корректировка
                Console.Clear();
                Console.WriteLine("Нажмите стрелочку вниз, чтобы полететь вниз, стрелочку вверх для подлета, Enter для  выхода из программы");

                Print(y, "|^|");
                Thread.Sleep(700);

                while (Console.KeyAvailable)
                {
                    ConsoleKeyInfo k1 = Console.ReadKey();
                    if (k1.Key == ConsoleKey.UpArrow)
                    {
                        onDrive = false;            //сбавляем скорость 
                        
                        hnew = hnew + (v * t + (g * t * t) / 2);
                        f = f - t;
                        v = v + g * t;
                        count=+1;
                    }
                    if (k1.Key == ConsoleKey.DownArrow)
                    {
                        onDrive = true;      //летим вниз
                        
                        
                        hnew = hnew - (v * t + (a * t * t) / 2);
                        f = f - t;
                        v = v + a * t;
                        count=+1;
                        if(hnew<=h/1.5 && hnew>=h/1.7)y++;
                        if(hnew<=h/2 && hnew>=h/2.2)y++;
                        if(hnew<=h/3 && hnew>=h/3.2)y++;
                        if(hnew==0)y++;
                    }

                    if (k1.Key == ConsoleKey.Escape) break;
                    t = 2;
                }
                Console.WriteLine($"Высота {hnew} м, Скорость {v} м/с, Топливо {f} сек");

            }

            //поздравления 
            if (Math.Abs(v) > CRUSH_SPEED || f < 0)
                Console.WriteLine("Вы разбились т-т");
            else
                Console.WriteLine($"Успешная посадка, вы сели за {count} секунд");
            Thread.Sleep(11500);
        }
    }
}