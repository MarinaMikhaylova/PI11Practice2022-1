using System.Threading;

Console.Clear();

Maze m = new Maze(ConsoleColor.Magenta, ConsoleColor.Black);
Maze n = new Maze(ConsoleColor.Blue, ConsoleColor.Black);

while (m.Count < 10 && n.Count < 10)
{
    m.Print(3, 3);
    n.Print(23, 3);

    ConsoleKeyInfo k1 = Console.ReadKey(true);


    if (k1.Key == ConsoleKey.A) m.MoveandCoinTaker(-1, 0);
    if (k1.Key == ConsoleKey.D) m.MoveandCoinTaker(1, 0);
    if (k1.Key == ConsoleKey.W) m.MoveandCoinTaker(0, -1);
    if (k1.Key == ConsoleKey.S) m.MoveandCoinTaker(0, 1);

    if (k1.Key == ConsoleKey.LeftArrow) n.MoveandCoinTaker(-1, 0);
    if (k1.Key == ConsoleKey.RightArrow) n.MoveandCoinTaker(1, 0);
    if (k1.Key == ConsoleKey.UpArrow) n.MoveandCoinTaker(0, -1);
    if (k1.Key == ConsoleKey.DownArrow) n.MoveandCoinTaker(0, 1);

    if (m.Count < 10 && n.Count < 10)
    {
        
        Console.SetCursorPosition(2, 1);
        Console.WriteLine($"Счётчик монет: {m.Count}");
        Console.SetCursorPosition(22, 1);
        Console.WriteLine($"Счётчик монет: {n.Count}");
        
    }
    else if(m.Count == 10){
        Console.Clear();
        Console.SetCursorPosition(12, 5);
        Console.WriteLine($"Поздравляю, первый игрок! Вы собрали все {m.Count} монет!");
        Console.SetCursorPosition(12, 10);
        Console.WriteLine();
    }
    else if(n.Count == 10){
        Console.Clear();
        Console.SetCursorPosition(12, 5);
        Console.WriteLine($"Поздравляю, второй игрок! Вы собрали все {n.Count} монет!");
        Console.SetCursorPosition(12, 10);
        Console.WriteLine();
    }
    
}
Thread.Sleep(700);
