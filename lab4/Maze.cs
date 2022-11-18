class Maze
{
    //данные
    int playerx = 1;
    int coincount = 0;
    public int Count{
        get {return coincount;}
    }
    int playery = 1;
    int[,] maze = new int[,]
    {
        {1,1,1,1,1,1,1,1,1,1},
        {1,0,1,0,2,1,0,0,0,1},
        {1,2,1,0,1,1,2,1,0,1},
        {1,0,0,2,1,1,1,1,0,1},
        {1,1,1,0,1,0,0,0,2,1},
        {1,2,1,0,0,2,1,1,0,1},
        {1,0,0,0,1,0,1,1,0,1},
        {1,1,1,1,1,0,1,1,0,1},
        {1,2,0,0,2,0,1,2,0,1},
        {1,1,1,1,1,1,1,1,1,1}
    };
    ConsoleColor ink;
    ConsoleColor paper;

    public Maze(ConsoleColor i, ConsoleColor p)
    {
        ink = i;
        paper = p;
    }

    //методы
    public void MoveandCoinTaker(int dx, int dy)
    {
        int nx = playerx + dx;
        int ny = playery + dy;
        if (maze[ny, nx] == 0 || maze[ny, nx] == 2)
        {
            playerx = nx;
            playery = ny;
            if (maze[ny, nx] == 2)
            {
                coincount++;
                maze[ny, nx] = 0;
                playerx = nx;
                playery = ny;
            }
        }
    }

    public void Print(int shiftx, int shifty)
    {
        for (int y = 0; y < 10; y++)
            for (int x = 0; x < 10; x++)
            {
                double dist = Math.Sqrt((playerx - x) * (playerx - x) + (playery - y) * (playery - y));
                if (dist > 3.7)
                {
                    Print(shiftx + x, shifty + y, " ", ConsoleColor.Gray, ConsoleColor.DarkGray);
                }
                else
                {
                    if (maze[y, x] == 0) Print(shiftx + x, shifty + y, " ");
                    else if (maze[y, x] == 1) Print(shiftx + x, shifty + y, "||", ink, paper);
                    else if (maze[y, x] == 2) Print(shiftx + x, shifty + y, "O", ConsoleColor.Yellow);
                }
            }

        Print(shiftx + playerx, shifty + playery, "@");

    }
    public void CoinCount(int x, int y, string s)
    {
        Console.CursorLeft = x;
        Console.CursorTop = y;
        Console.Write(s);
    }

    void Print(int x, int y, string s, ConsoleColor ink = ConsoleColor.White, ConsoleColor paper = ConsoleColor.Black)
    {
        Console.ForegroundColor = ink;
        Console.BackgroundColor = paper;
        Console.CursorLeft = x;
        Console.CursorTop = y;
        Console.Write(s); 
    }
}