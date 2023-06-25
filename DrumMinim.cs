using System;

class Program
{
    static int[,] matrix = new int[,]
    {
        { 0, 4, 0, 0, 0, 0, 0, 8, 0 },
        { 4, 0, 8, 0, 0, 0, 0, 11, 0 },
        { 0, 8, 0, 7, 0, 4, 0, 0, 2 },
        { 0, 0, 7, 0, 9, 14, 0, 0, 0 },
        { 0, 0, 0, 9, 0, 10, 0, 0, 0 },
        { 0, 0, 4, 14, 10, 0, 2, 0, 0 },
        { 0, 0, 0, 0, 0, 2, 0, 1, 6 },
        { 8, 11, 0, 0, 0, 0, 1, 0, 7 },
        { 0, 0, 2, 0, 0, 0, 6, 7, 0 }
    };

    static int V = 9;

    static int FindMinimumDistance(int[] distances, bool[] visited)
    {
        int minDistance = int.MaxValue;
        int minIndex = -1;

        for (int i = 0; i < V; i++)
        {
            if (!visited[i] && distances[i] <= minDistance)
            {
                minDistance = distances[i];
                minIndex = i;
            }
        }

        return minIndex;
    }

    static void Dijkstra(int[,] graph, int source)
    {
        int[] distances = new int[V];
        bool[] visited = new bool[V];

        for (int i = 0; i < V; i++)
        {
            distances[i] = int.MaxValue;
            visited[i] = false;
        }

        distances[source] = 0;

        for (int count = 0; count < V - 1; count++)
        {
            int u = FindMinimumDistance(distances, visited);
            visited[u] = true;

            for (int v = 0; v < V; v++)
            {
                if (!visited[v] && graph[u, v] != 0 && distances[u] != int.MaxValue &&
                    distances[u] + graph[u, v] < distances[v])
                {
                    distances[v] = distances[u] + graph[u, v];
                }
            }
        }

        Console.WriteLine("Nod\t\tDistanță față de sursă");
        for (int i = 0; i < V; i++)
        {
            Console.WriteLine($"{i}\t\t{distances[i]}");
        }
    }

    static void Main()
    {
        int source = 0;
        Dijkstra(matrix, source);
    }
}