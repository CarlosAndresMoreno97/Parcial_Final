using System;

public class Program
{
    static int[,] board;
    static int score;
    static int playerRow;
    static int playerCol;
    static int size;

    static void Main(string[] args)
    {


        InitializeGame();
        while (true)
        {
            DisplayBoard();
            DisplayScore();
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            HandleKey(keyInfo.Key);
        }
    }
    static void InitializeGame()
    {
        Console.WriteLine("Ingrese el tamaño del tablero (N): ");
        size = Convert.ToInt32(Console.ReadLine());
        board = new int[size, size];
        Random rand = new Random();
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                board[i, j] = rand.Next(1, 9);
            }
        }
        playerRow = 0;
        playerCol = 0;
        board[playerRow, playerCol] = 0;
        score = 0;
    }
    static void DisplayBoard()
    {
        Console.Clear();
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                if (i == playerRow && j == playerCol)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("[P] ");
                    Console.ResetColor();
                }
                else
                {
                    Console.Write($"[{board[i, j]}] ");
                }
            }
            Console.WriteLine();
        }
    }

    static void DisplayScore()
    {
        Console.WriteLine($"Puntaje: {score}");
    }

    static void HandleKey(ConsoleKey key)
    {
        switch (key)
        {
            case ConsoleKey.UpArrow:
            case ConsoleKey.W:
                MovePlayer(-1, 0);
                break;
            case ConsoleKey.DownArrow:
            case ConsoleKey.S:
                MovePlayer(1, 0);
                break;
            case ConsoleKey.LeftArrow:
            case ConsoleKey.A:
                MovePlayer(0, -1);
                break;
            case ConsoleKey.RightArrow:
            case ConsoleKey.D:
                MovePlayer(0, 1);
                break;
            case ConsoleKey.Escape:
                Environment.Exit(0);
                break;
        }
    }
    static void MovePlayer(int dRow, int dCol)
    {
        int newRow = playerRow + dRow;
        int newCol = playerCol + dCol;
        if (newRow >= 0 && newRow < size && newCol >= 0 && newCol < size)
        {
            score += board[newRow, newCol];
            playerRow = newRow;
            playerCol = newCol;
            board[newRow, newCol] = 0;
        }
    }
}


