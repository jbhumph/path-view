namespace path_view.Models;

public class GridGraph
{
    public int Rows { get; }
    public int Columns { get; }
    public Node[,] Nodes { get; }

    public GridGraph(int rows, int columns)
    {
        Rows = rows;
        Columns = columns;
        Nodes = new Node[rows, columns];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                Nodes[i, j] = new Node(i, j); // Row and column indices.
            }
        }
    }
      
    // Add utility methods here, e.g., for resetting walls, exporting adjacency list, etc.

}