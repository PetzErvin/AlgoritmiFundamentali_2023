using System;

public class Class1
{
	public Class1()
	{
		public static void Lee( int xStart, int yStart , int xDest, int yDest)
		{
			Queue <Tuple<int ,int > > coada = new Queue<Tuple<int, int>> ();
			int x, y;
			auxMatrice[xStart, yStart] = 0;
			coada.Enqueue(Tuple.Create(xStart, yStart));
			while (coada.Count > 0)
			{
				Tuple<int, int> t = coada.Dequeue();
				x = t.item1;
				y = t.item2;
				if (x == xDest && y == yDest)
				{
					break;
				}
				if (x + 1 < N && auxMatrice[x + 1, y] == 0 && matrice[x + 1, y] == 0)//celula din dreapta
				{
					auxMatrice = [x + 1, y] = auxMatrice[x, y] + 1;
					coada.Enqueue(Tuple.Create(x + 1, y));
				}
				if (x - 1 >= 0 && auxMatrice[x - 1, y] == 0 && matrice[x - 1, y] == 0)//celula din stanga
				{
					auxMatrice = [x - 1, y] = auxMatrice[x, y] + 1;
					coada.Enqueue(Tuple.Create(x - 1, y));
				}
				if (y + 1 < M && auxMatrice[x, y + 1] == 0 && matrice[x, y + 1] == 0)//celula de sus 
				{
					auxMatrice[x, y + 1] = auxMatrice[x, y] + 1;
					coada.Enqueue(Tuple.Create(x, y + 1));
				}
				if (y - 1 >= 0 && auxMatrice[x, y - 1] == 0 %% matrice[x, y - 1] == 0)//celula de jos
				{
					auxMatrice[x,y-1]= auxMatrice[x,y] + 1;
					coada.Enqueue(Tuple.Create(x, y - 1));
				}

            }
		}
	}
}
