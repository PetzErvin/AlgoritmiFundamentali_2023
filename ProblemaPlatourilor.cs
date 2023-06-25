static void ProblemaPlatouri2()
{
    int[,] mat;
    using (StreamReader sr = new StreamReader(@"..\..\..\platou2.txt"))
    {
        List<string> buffers = new List<string>();
        while (!sr.EndOfStream)
        {
            buffers.Add(sr.ReadLine()!);
        }
        mat = new int[buffers.Count, buffers[0].Length];
        for (int i = 0; i < buffers.Count; i++)
        {
            for (int j = 0; j < buffers[i].Length; j++)
            {
                mat[i, j] = buffers[i][j] - '0';
            }
        }
    }
    int n = mat.GetLength(0);
    int m = mat.GetLength(1);
    int maxamount = 0;
    List<int[]> coords = new List<int[]>();
    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < m; j++)
        {
            if (mat[i, j] != 0)
            {
                List<int[]> check = new List<int[]>();
                NeighborsList(i, j, mat[i, j], mat, check);
                if (check.Count > maxamount)
                {
                    coords = check;
                    maxamount = check.Count;
                }
            }
        }
    }
    foreach (int[] v in coords)
    {
        Console.Write($"[{v[0]},{v[1]}] ");
    }
}
static void NeighborsList(int i, int j, int value, int[,] mat, List<int[]> list)
{
    if (i >= mat.GetLength(0) || j >= mat.GetLength(1) || i < 0 || j < 0)
    {
        return;
    }
    if (mat[i, j] != value)
    {
        return;
    }
    mat[i, j] = 0;
    list.Add(new int[] { i, j });
    NeighborsList(i + 1, j, value, mat, list);
    NeighborsList(i - 1, j, value, mat, list);
    NeighborsList(i, j + 1, value, mat, list);
    NeighborsList(i, j - 1, value, mat, list);
}