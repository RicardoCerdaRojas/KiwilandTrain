namespace Kiwiland.Service;

public class DepthFirstAlgorithm : SearchAlgorithm
{
    private Func<ITrip, bool> _breakCriteria;
    private Func<ITrip, bool> _addRouteCriteria;
    private IGraph _graph;
    private ITrip _trip;
    private List<ITrip> _possibleTrips;
    private bool _shouldBreak;

    public DepthFirstAlgorithm(IAlgorithmConfiguration cfg)
    {
        _graph = cfg.Graph;
        _breakCriteria = cfg.BreakCriteria;
        _addRouteCriteria = cfg.AddRouteCriteria;
        _trip = cfg.Trip;
        _shouldBreak = cfg.ShouldBreak;
        _possibleTrips = new List<ITrip>();
    }

    public IList<ITrip> run()
    {
        dfs(_trip);
        return _possibleTrips;
    }

    private void dfs(ITrip trip)
    {
        if (_breakCriteria(trip))
            return;

        if (_addRouteCriteria(trip))
        {
            _possibleTrips.Add(trip);
            if(_shouldBreak)
                return;
        }

        foreach (IEdge edge in _graph.GetRoutesStartingFrom(trip.LastNode()))
        {
            var t = new Trip(trip.StartNode());
            t.AddRange(trip.Route);
            t.AddEdge(edge);
            dfs(t);
        }
    }
}