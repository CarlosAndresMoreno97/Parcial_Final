using System;

class Program
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
