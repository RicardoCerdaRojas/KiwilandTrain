namespace Kiwiland.Service;

public interface IAlgorithmConfiguration
{
    Func<ITrip, bool> BreakCriteria { get; }
    Func<ITrip, bool> AddRouteCriteria { get; }
    IGraph Graph { get; }
    ITrip Trip { get; }
    Node LastNode { get; }
    Boolean ShouldBreak { get; }
    
}