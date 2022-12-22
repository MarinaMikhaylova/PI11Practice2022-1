using System;

namespace moon_lander
{
    class Program
    {
        static void Main(string[] args)
        {
            //данные
            double h=1000; //начальная высота в метрах
            double f=30; //на сколько времени хватит топлива в секундах
            double v=0; //скорость корабля в м/с
            double t=0; // время в секундах
            int engine=0; //0-двигатель выключен, 1-включен
            const double g=-1.62; //ускорение свободного падения на луне в м/с^2
            const double a=2; //ускорение корабля в м/с^2
            const double vMax=10; //скорость в м/с, при которой корабль разбивается
            
            //основной алгоритм
            while (h>=0.0000001 && f>0) 
            {
                Console.WriteLine($"Текущие показатели: высота {h:F2} м, скорость {Math.Abs(v):F2} м/с, топлива {f:F2} сек"); 
                engine = GetIntFromList("(1 - включить двигатель, 0 - выключить двигатель): ", 0, 1);
                double currenta = engine == 0 ? g : a;
                t = 1;

                if (t<0) t=0;
                if (t>f) t=f;

                int n;
                double t1,t2;
                SolveSquareRoot(currenta/2,v,h, out n, out t1, out t2);

                if (n>0 && t1>0 && t>t1) t = t1;
                if (n>0 && t2>0 && t>t2) t = t2;

                if (engine == 1) f -= t;
                h = h + v*t + currenta/2*t*t;
                v = v + currenta*t;
            }

            Console.WriteLine($"Текущие показатели: высота {Math.Abs(h):F2} м, скорость {Math.Abs(v):F2} м/с, топлива {f:F2} сек"); 
            if(f==0){
                Console.WriteLine("Как же так, топливо уже закончилось, а вы и не заметили..упс");}
            else if (Math.Abs(v) > vMax){
                Console.WriteLine("О нет, кажется кто-то не расчитал скорость..Вы разбились :с");}
            else{
                Console.WriteLine("Поздравляю, Вы приземлились!");}
        }

        static int GetIntFromList(string msg, int x1, int x2)
        {
            bool valid = false;
            int input = 0;

            do
            {
                Console.Write(msg);
                valid = int.TryParse(Console.ReadLine(), out input);
            } while (!valid || (input != x1 && input != x2));

            return input;
        }

        static void SolveSquareRoot(double A, double B, double C, out int n, out double x1, out double x2)
        {
            //todo - проверка A
            n=0;
            x1=0;
            x2=0;

            double d = B*B - 4*A*C;

            if (d<0) return;
            if (d==0) n = 1;
            if (d>0) n = 2;

            x1 = (-B + Math.Sqrt(d))/(2*A);
            x2 = (-B - Math.Sqrt(d))/(2*A);
        }
    }
}
