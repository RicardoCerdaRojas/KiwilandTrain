namespace Kiwiland.Service;

public class DijkstraAlgorithm : SearchAlgorithm
{
    private IGraph _graph;
    private ITrip _shortestTrip;
    private ITrip _trip;
    private Node _endNode;
    private int _shortestDistance = int.MaxValue;

    public DijkstraAlgorithm(IAlgorithmConfiguration cfg)
    {
        _graph = cfg.Graph;
        _trip = cfg.Trip;
        _endNode = cfg.LastNode;
    }
    public IList<ITrip> run()
    {
        Dijkstra(_trip);
        return new List<ITrip> {_shortestTrip};
    }

    private void Dijkstra(ITrip trip)
    {
        if (IsShortest(trip))
        {
            SetShortest(trip);
            return;
        }

        foreach (IEdge neighbour in _graph.GetRoutesStartingFrom(trip.LastNode()))
        {
            if (HasVisited(trip,neighbour))
                continue;
            var t = new Trip(trip.StartNode());
            t.AddRange(trip.Route);
            t.AddEdge(neighbour);
            Dijkstra(t);
        }
    }

    private bool HasVisited(ITrip trip, IEdge neighbour)
    {
        return trip.Contains(neighbour);
    }

    private void SetShortest(ITrip trip)
    {
        _shortestTrip = trip;
        _shortestDistance = trip.GetDistance();
    }

    private bool IsShortest(ITrip trip)
    {   if( !trip.IsEmpty() && EndsWithExpectedNode(trip))
            return trip.GetDistance() < _shortestDistance;
        return false;
    }

    private bool EndsWithExpectedNode(ITrip trip)
    {
        return (trip.LastNode().Equals(_endNode));
    }
}
