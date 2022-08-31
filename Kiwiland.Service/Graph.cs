namespace Kiwiland.Service;

public class Graph : IGraph
{
    private IList<IEdge> _edges;

    public Graph(string townsGraph)
    {
        _edges = InputInterpreter.GetEdgesFrom(townsGraph).ToList();
    }

    public Graph(IList<IEdge> edges)
    {
        _edges = edges;
    }

    public IList<IEdge> Edges
    {
        get { return _edges; }
    }


    public IEnumerable<IEdge> GetRoutesStartingFrom(Node startingNode)
    {
        return _edges.Where(x => x.Start.Equals(startingNode));
    }

    public IEnumerable<IEdge> GetRouteFrom(IList<Node> nodes)
    {
        for (int i = 0; i <= nodes.Count -2; i++)
        {
            yield return GetEdge(nodes[i], nodes[i + 1]);

        }
    }

    public void Add(IEdge edge)
    {
        _edges.Add(edge);
    }

    public void AddRange(IList<IEdge> edges)
    {
        foreach (var e in edges)
        {
            Add(e);
        }
    }

    public int GetDistanceFromRoute(IList<Node> nodes)
    {
        return GetDistanceFromRoute(GetRouteFrom(nodes).ToList());
    }

    public int GetDistanceFromRoute(IList<IEdge> route)
    {
        int _distance = 0;
        foreach (var r in route)
        {
            _distance += r.Distance;
        }
        return _distance;
    }

    public IEdge GetEdge(Node start, Node end)
    {
        if (_edges.Any(x => x.Start.Equals(start) && x.End.Equals(end)))
            return _edges.First(x => x.Start.Equals(start) && x.End.Equals(end));
        throw new InexistentRouteException();
    }
}