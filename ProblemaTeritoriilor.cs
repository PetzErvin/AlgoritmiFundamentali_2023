using System;

class Program
{
    static void Main()
    {
        char[,] territory = {
            { 'A', 'A', 'A', 'B', 'B' },
            { 'A', 'A', 'A', 'B', 'B' },
            { 'C', 'C', 'C', 'D', 'D' },
            { 'C', 'C', 'C', 'D', 'D' }
        };

        int rows = territory.GetLength(0);
        int cols = territory.GetLength(1);

        int playerACount = 0;
        int playerBCount = 0;
        int playerCCount = 0;
        int playerDCount = 0;

        // Parcurgem fiecare teritoriu și numărăm numărul de teritorii deținute de fiecare jucător
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if (territory[i, j] == 'A')
                    playerACount++;
                else if (territory[i, j] == 'B')
                    playerBCount++;
                else if (territory[i, j] == 'C')
                    playerCCount++;
                else if (territory[i, j] == 'D')
                    playerDCount++;
            }
        }

        // Afișăm rezultatele
        Console.WriteLine("Player A: " + playerACount + " territories");
        Console.WriteLine("Player B: " + playerBCount + " territories");
        Console.WriteLine("Player C: " + playerCCount + " territories");
        Console.WriteLine("Player D: " + playerDCount + " territories");
    }
}