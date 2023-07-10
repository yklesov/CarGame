namespace CarGame
{
    internal class Program
    {
        static int playerX = 1;
        static int playerY = 1;
        static int wallX = 0;
        static int wallY = 2;
        static int lives = 3;
        static void Main(string[] args)
        {
            Console.WriteLine("Use W, A, S, D keys to control the object. Hit a wall to lose a life.");

            while (lives > 0)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                Console.Clear();
                if (keyInfo.Key == ConsoleKey.W && playerY > 0)
                    playerY--;
                else if (keyInfo.Key == ConsoleKey.S && playerY < Console.WindowHeight - 1)
                    playerY++;
                else if (keyInfo.Key == ConsoleKey.A && playerX > 0)
                    playerX--;
                else if (keyInfo.Key == ConsoleKey.D && playerX < Console.WindowWidth - 1)
                    playerX++;
                for (int i = 0; i < Console.WindowWidth; i++)
                {
                    if ((playerX == wallX + i && playerY == wallY) || (playerX == wallX + i && playerY == wallY - 2))
                    {
                        Console.SetCursorPosition(0, Console.WindowHeight - 3);
                        Console.WriteLine("You hit the wall! -1 life");
                        lives--;
                        if (lives == 0)
                        {
                            Console.WriteLine("No more lives! Game Over!");
                            break;
                        }
                    }
                }
                DrawObject();
                DrawWall();
                DrawLives();
            }
        }

        static void DrawObject()
        {
            Console.SetCursorPosition(playerX, playerY);
            Console.Write("O");
        }

        static void DrawWall()
        {
            for (int i = 0; i < Console.WindowWidth; i++)
            {
                Console.SetCursorPosition(wallX + i, wallY);
                Console.Write("X");
                Console.SetCursorPosition(wallX + i, wallY - 2);
                Console.Write("X");
            }

        }

        static void DrawLives()
        {
            Console.SetCursorPosition(0, Console.WindowHeight - 1);
            Console.Write("Lives: " + lives);
        }
    }
}