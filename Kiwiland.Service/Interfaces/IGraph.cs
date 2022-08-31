namespace Kiwiland.Service;

public interface IGraph
{
    IList<IEdge> Edges { get; }

    IEnumerable<IEdge> GetRoutesStartingFrom(Node startingNode);

    IEnumerable<IEdge> GetRouteFrom(IList<Node> nodes);

    void Add(IEdge edge);

    void AddRange(IList<IEdge> edges);
        
    int GetDistanceFromRoute(IList<Node> nodes);

    int GetDistanceFromRoute(IList<IEdge> route);    
}