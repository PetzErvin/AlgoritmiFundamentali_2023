using System;

namespace LeeAlgorithm 
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
        }
        public static void Lee(int xStart, int yStart, int xDest, int yDest)
        {
            Queue<Tuple<int,int>> coada = new Queue<Tuple<int, int>> ();
            int x, y;
            auxMatrice[xStart, yStart] = 0;
            coada.Enqueue(Tuple.Create(xStart, yStart));
            while(coada.Count > 0)
            {
                Tuple<int,int> t = coada.Dequeue();
                x = t.Item1;
                y = t.Item2;
                if(x == xDest && y == yDest)
                {
                    break;
                }

            }
        }
    }
}