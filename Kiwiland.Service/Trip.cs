using System.Text;

namespace Kiwiland.Service;

public class Trip : ITrip
{
    private Node _startNode;
    private IList<IEdge> _edges;

    public IList<IEdge> Route
    {
        get { return _edges; }
    }

    public Trip(Node startNode)
    {
        _startNode = startNode;
        _edges = new List<IEdge>();
    }

    public int GetNumberOfStops()
    {
        if (_edges.Any())
            return _edges.Count;
        return 0;
    }

    public Node LastNode()
    {
        if (!IsEmpty())
            return _edges.Last().End;
        return _startNode;
    }

    public Node StartNode()
    {
        return _startNode;
    }

    public bool IsEmpty()
    {
        return !_edges.Any();
    }

    public void AddEdge(IEdge edge)
    {
        _edges.Add(edge);
    }

    public int GetDistance()
    {
        var _distance = 0;
        foreach (var edge in Route)
        {
            _distance += edge.Distance;
        }
        return _distance;
    }

    public bool Contains(IEdge edge)
    {
        return _edges.Any(x => x.Start.Code == edge.Start.Code && x.End.Code == edge.End.Code);
    }

    public void AddRange(IList<IEdge> edges)
    {
        foreach (var edge in edges)
        {
            AddEdge(edge);
        }
    }

    public override string ToString()
    {
        StringBuilder result = new StringBuilder();
        for (int i = 0; i <= Route.Count - 1; i++)
        {
            if (i == Route.Count - 1)
                result.Append(String.Concat(Route[i].Start, " - ", Route[i].End));
            else
                result.Append(String.Concat(Route[i].Start, " - "));
        }

        return result.ToString();
    }
}