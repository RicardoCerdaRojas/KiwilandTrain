namespace Kiwiland.Service;

public interface ITrip
{
    IList<IEdge> Route { get; }
    int GetNumberOfStops();
    Node LastNode();
    Node StartNode();
    bool IsEmpty();
    bool Contains(IEdge edge);
    void AddEdge(IEdge edge);
    int GetDistance();

}