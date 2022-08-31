namespace Kiwiland.Service;

public static class InputInterpreter
{
    private const char GraphSeparator = ',';
    private const char NodeSeparator = '-';

    public static IEnumerable<IEdge> GetEdgesFrom(string townsGraph)
    {
        foreach (var rawEdge in townsGraph.Split(GraphSeparator))
        {
            yield return convertToEdge(rawEdge);

        }    
    }

    private static IEdge convertToEdge(string edge)
    {
        edge = edge.Trim();
        Node start = new Node(edge[0]);
        Node end = new Node(edge[1]);
        int distance = Convert.ToInt32(edge[2].ToString());
        return new Edge(start,end,distance);
    }

    public static IEnumerable<Node> GetNodesFrom(string route)
    {
        foreach (var n in route.Split(NodeSeparator))
        {
            yield return new Node(Convert.ToChar(n));
        }
    }
}