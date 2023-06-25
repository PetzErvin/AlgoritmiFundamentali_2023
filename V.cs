using System;
using System.Collections.Generic;

public class CoadaStiva<T>
{
    private List<T> buffer; // Buffer pentru elemente
    private List<T> stack; // Lista pentru stivă
    private List<T> queue; // Lista pentru coadă

    public CoadaStiva()
    {
        buffer = new List<T>();
        stack = new List<T>();
        queue = new List<T>();
    }

    public void Push(T item)
    {
        buffer.Add(item); // Adăugăm elementul în buffer

        // Dacă probabilitatea este 1:1, selectăm aleator între stivă și coadă
        bool useStack = (new Random().Next(2) == 0);

        if (useStack)
        {
            while (buffer.Count > 0)
            {
                T bufferItem = buffer[0];
                buffer.RemoveAt(0);
                stack.Add(bufferItem);
            }
        }
        else
        {
            while (buffer.Count > 0)
            {
                T bufferItem = buffer[buffer.Count - 1];
                buffer.RemoveAt(buffer.Count - 1);
                queue.Insert(0, bufferItem);
            }
        }
    }

    public T Pop()
    {
        if (stack.Count > 0)
        {
            T item = stack[stack.Count - 1];
            stack.RemoveAt(stack.Count - 1);
            return item;
        }
        else if (queue.Count > 0)
        {
            T item = queue[queue.Count - 1];
            queue.RemoveAt(queue.Count - 1);
            return item;
        }
        else
        {
            throw new InvalidOperationException("CoadaStiva este goală.");
        }
    }
}

//CoadaStiva<int> coadaStiva = new CoadaStiva<int>();
//coadaStiva.Push(1);
//coadaStiva.Push(2);
//coadaStiva.Push(3);

//int item1 = coadaStiva.Pop(); // Se comportă ca o stivă: se elimină ultimul element adăugat (3)
//int item2 = coadaStiva.Pop(); // Se comportă ca o coadă: se elimină primul element adăugat (1)

//Console.WriteLine(item1); // Afișează 3
//Console.WriteLine(item2); // Afișează 1
