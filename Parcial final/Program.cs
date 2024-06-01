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