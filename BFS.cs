using System;
using System.Collections.Generic;

public class Class1
{
    public class GraphNode
    {
        public int Value { get; set; }
        public List<GraphNode> Neighbors { get; set; }

        public GraphNode(int value)
        {
            Value = value;
            Neighbors = new List<GraphNode>();
        }
    }

    static void Main(string[] args)
    {
        // Defining a simple graph
        GraphNode node1 = new GraphNode(1);
        GraphNode node2 = new GraphNode(2);
        GraphNode node3 = new GraphNode(3);
        GraphNode node4 = new GraphNode(4);
        GraphNode node5 = new GraphNode(5);
        GraphNode node6 = new GraphNode(6);
        GraphNode node7 = new GraphNode(7);

        node1.Neighbors.AddRange(new[] { node2, node3 });
        node2.Neighbors.AddRange(new[] { node4, node5 });
        node3.Neighbors.Add(node6);
        node5.Neighbors.Add(node7);

        // Breadth-first search traversal starting from node 1
        Console.WriteLine("Breadth-first search (BFS) traversal:");
        BFS(node1);
    }

    static void BFS(GraphNode startNode)
    {
        Queue<GraphNode> queue = new Queue<GraphNode>();
        HashSet<GraphNode> visited = new HashSet<GraphNode>();

        queue.Enqueue(startNode);
        visited.Add(startNode);

        while (queue.Count > 0)
        {
            GraphNode currentNode = queue.Dequeue();
            Console.WriteLine(currentNode.Value);

            foreach (GraphNode neighbor in currentNode.Neighbors)
            {
                if (!visited.Contains(neighbor))
                {
                    queue.Enqueue(neighbor);
                    visited.Add(neighbor);
                }
            }
        }
    }
}
