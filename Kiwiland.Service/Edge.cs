namespace Kiwiland.Service;

public class Edge : IEdge
{
    private Node _start;
    private Node _end;
    private int _distance;

    public Node Start
    {
        get { return _start; }
    }
    public Node End
    {
        get { return _end; }
    }

    public int Distance
    {
        get { return _distance; }
    }

    public Edge(Node start, Node end, int distance)
    {
        _start = start;
        _end = end;
        _distance = distance;
    }
}