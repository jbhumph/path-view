using System.Collections.Generic;
using System.Linq;

namespace path_view.Models;



public class Algos
{
    private static int _width = 10;
    private static int _height = 10;
    private static Node[,] _grid = new Node[_width, _height];

    static void BFS(Node start, Node end)
    // Breadth-First search for grid
    {
        var queue = new Queue<Node>();
        queue.Enqueue(start);
        start.IsVisited = true;

        while (queue.Count > 0)
        {
            var current = queue.Dequeue();
            if (current == end) return;

            foreach (var neighbor in GetNeighbors(current))
            {
                if (!neighbor.IsVisited && !neighbor.IsWall)
                {
                    neighbor.IsVisited = true;
                    neighbor.Previous = current;
                    queue.Enqueue(neighbor);
                }
            }
        }
    }
    
    static void DFS(Node start, Node end)
    // Depth-First search for grid
    {
        var stack = new Stack<Node>();
        stack.Push(start);
        start.IsVisited = true;

        while (stack.Count > 0)
        {
            var current = stack.Pop();
            if (current == end) return;
            
            foreach (var neighbor in GetNeighbors(current))
            {
                if (!neighbor.IsVisited && !neighbor.IsWall)
                {
                    neighbor.IsVisited = true;
                    neighbor.Previous = current;
                    stack.Push(neighbor);
                }
            }
        }
    }
    
    static void Dijkstra(Node start, Node end)
    // Dijkstra search for grid
    {
        var unvisited = new List<Node>();
        foreach (var node in _grid)
        {
            node.IsVisited = false;
            node.Distance = double.MaxValue;
            node.Previous = null;
            unvisited.Add(node);
        }
        
        start.Distance = 0;
        while (unvisited.Count > 0)
        {
            // get node with smallest distance
            var current = unvisited.OrderBy(x => x.Distance).First();
            unvisited.Remove(current);
            
            if (current.IsWall) continue;
            if (current.Distance == double.MaxValue) break;
            if (current == end) return;
            
            // update distances of neighbors
            foreach (var neighbor in GetNeighbors(current))
            {
                if (neighbor.IsWall) continue;
                
                double alt = current.Distance + 1;
                if (alt < neighbor.Distance)
                {
                    neighbor.Distance = alt;
                    neighbor.Previous = current;
                }
            }
        }
    }
    
    static List<Node> GetNeighbors(Node node)
        // returns all neighbors of node in a list
    {
        var neighbors = new List<Node>();
        var directions = new (int dx, int dy)[] { (0, 1), (1, 0), (0, -1), (-1, 0) };

        foreach (var (dx, dy) in directions)
        {
            int nx = node.X + dx;
            int ny = node.Y + dy;
            
            if (nx >= 0 && ny >= 0 && nx < _width && ny < _height) neighbors.Add(_grid[nx, ny]);
        }
        
        return neighbors;
    }
}