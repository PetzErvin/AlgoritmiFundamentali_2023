static void MagicSquare()
{
    // | a b c |
    // | d e f |
    // | g h i |
    // 

    // a + b + c = d + e + f = g + h + i = a + d + g = b + e + h = c + f + i = a + e + i = g + e + c

    int[] v = new int[9];
    int[] sel = new int[9];
    int[] multime = new int[9] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

    BackSelectMagic(v, sel, 0, 9, multime);
}
static bool MagicOk(int[] v)
{
    int[,] sq = new int[3, 3];
    for (int i = 0; i < 9; i++)
    {
        sq[i / 3, i % 3] = v[i];
    }
    int check = sq[0, 0] + sq[1, 1] + sq[2, 2];
    for (int i = 0; i < 3; i++)
    {
        int linesum = 0;
        int colsum = 0;
        for (int j = 0; j < 3; j++)
        {
            linesum += sq[i, j];
            colsum += sq[j, i];
        }
        if (linesum != check || colsum != check)
        {
            return false;
        }
    }
    int diag2 = sq[2, 0] + sq[1, 1] + sq[0, 2];
    if (check != diag2)
    {
        return false;
    }

    return true;
}
static void BackSelectMagic(int[] v, int[] selected, int k, int n, int[] elements)
{
    // permutari
    if (k >= n)
    {
        if (MagicOk(v))
        {
            for (int i = 0; i < v.Length; i++)
            {
                if (i % 3 == 0)
                {
                    Console.WriteLine();
                }
                Console.Write(v[i] + " ");

            }
            Console.WriteLine();
        }
    }
    else
    {
        for (int i = 0; i < n; i++)
        {
            if (selected[i] == 0)
            {
                selected[i] = 1;
                v[k] = elements[i];
                BackSelectMagic(v, selected, k + 1, n, elements);
                selected[i] = 0;
            }
        }
    }
}