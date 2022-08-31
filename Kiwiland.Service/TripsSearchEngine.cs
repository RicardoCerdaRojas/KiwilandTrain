namespace Kiwiland.Service;

public class TripsSearchEngine
{
        private IGraph _graph;
        public TripsSearchEngine(string townsGraph)
        {
            _graph = new Graph(townsGraph);
        }

        public int GetDistanceFromRoute(string route)
        {
            IList<Node> nodes = InputInterpreter.GetNodesFrom(route).ToList();
            return _graph.GetDistanceFromRoute(nodes);
        }

        public IList<ITrip> GetRoutesWithExactNumberOfStops(char start, char end, int numberStops)
        {
            Func<ITrip, bool> breakCriteria = (x => x.GetNumberOfStops() > numberStops);
            Func<ITrip, bool> addRouteCriteria =
                (x => (x.GetNumberOfStops() == numberStops) && (x.StartNode().Equals(start) && (x.LastNode().Equals(end))));

            return GetPossibleRoutesFor(start, breakCriteria, addRouteCriteria);

        }

        public IList<ITrip> GetRoutesWithMaxNumberOfStops(char start, char end, int maxNumberOfStops)
        {
            Func<ITrip, bool> breakCriteria = (x => x.GetNumberOfStops() > maxNumberOfStops);
            Func<ITrip, bool> addRouteCriteria =
                (x => (!x.IsEmpty()) && (x.StartNode().Equals(start)) && (x.LastNode().Equals(end)));

            return GetPossibleRoutesFor(start, breakCriteria, addRouteCriteria);
        }

        public ITrip GetShortestRouteBetween(char start, char end)
        {
            var search = FluentConfiguration.Fluently()
                .defineGraph(_graph)
                .trip(new Trip(start))
                .withLastNode(new Node(end))
                .algorithm(Algorithms.Dijkstra)
                .Configure();
            return search.run()[0];
        }

        public IList<ITrip> GetRoutesWithDistanceLowerThan(int distance, char start, char end)
        {
            Func<ITrip, bool> breakCriteria = (x => x.GetDistance() >= distance);
            Func<ITrip, bool> addRouteCriteria =
                (x => (!x.IsEmpty()) && (x.StartNode().Equals(start)) && (x.LastNode().Equals(end)));

            return GetPossibleRoutesFor(start, breakCriteria, addRouteCriteria, false);
        }

        private IList<ITrip> GetPossibleRoutesFor(Node start, Func<ITrip, bool> breakCriteria, Func<ITrip, bool> addRouteCriteria)
        {
            return GetPossibleRoutesFor(start, breakCriteria, addRouteCriteria, true);
        }

        private IList<ITrip> GetPossibleRoutesFor(Node start, Func<ITrip, bool> breakCriteria, Func<ITrip, bool> addRouteCriteria, bool shouldBreak)
        {
            var search = FluentConfiguration.Fluently()
                 .defineGraph(_graph)
                 .breakExecutionCriteria(breakCriteria)
                 .addRouteCriteria(addRouteCriteria)
                 .breakAfterAddingRoute(shouldBreak)
                 .trip(new Trip(start))
                 .algorithm(Algorithms.DFS)
                 .Configure();

            return search.run();
        }
    
}