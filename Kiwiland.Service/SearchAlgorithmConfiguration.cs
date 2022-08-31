namespace Kiwiland.Service;

    public class SearchAlgorithmConfiguration : IAlgorithmConfiguration
    {
        private Func<ITrip, bool> _breakCriteria;
        private Func<ITrip, bool> _addRouteCriteria;
        private IGraph _graph;
        private ITrip _trip;
        private Algorithms _algorithm;
        private Node _lastNode;
        private bool _shouldBreak;

        public Func<ITrip, bool> BreakCriteria
        {
            get { return _breakCriteria; }
        }

        public Func<ITrip, bool> AddRouteCriteria
        {
            get { return _addRouteCriteria; }
        }

        public IGraph Graph
        {
            get { return _graph; }
        }

        public ITrip Trip
        {
            get { return _trip; }
        }

        public Node LastNode
        {
            get { return _lastNode; }
        }

        public bool ShouldBreak
        {
            get { return _shouldBreak; }
        }

        public SearchAlgorithmConfiguration defineGraph(IGraph graph)
        {
            _graph = graph;
            return this;
        }

        public SearchAlgorithmConfiguration breakExecutionCriteria(Func<ITrip,bool> breakCriteria)
        {
            _breakCriteria = breakCriteria;
            return this;
        }
        
        public SearchAlgorithmConfiguration addRouteCriteria(Func<ITrip,bool> addRouteCriteria)
        {
            _addRouteCriteria = addRouteCriteria;
            return this;
        }

        public SearchAlgorithmConfiguration trip(ITrip trip)
        {
            _trip = trip;
            return this;
        }

        public SearchAlgorithmConfiguration algorithm(Algorithms algorithm)
        {
            _algorithm = algorithm;
            return this;
        }

        public SearchAlgorithmConfiguration withLastNode(Node lastNode)
        {
            _lastNode = lastNode;
            return this;
        }

        public SearchAlgorithmConfiguration breakAfterAddingRoute(bool shouldBreak)
        {
            _shouldBreak = shouldBreak;
            return this;
        }

        
        public SearchAlgorithm Configure()
        {
            if (_algorithm == Algorithms.Dijkstra)
                return new DijkstraAlgorithm(this);
            return new DepthFirstAlgorithm(this);
        }

    }