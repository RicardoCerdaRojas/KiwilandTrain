namespace Kiwiland.Service;

public class InexistentRouteException : Exception
{
    public override string Message
    {
        get
        {
            return "NO SUCH ROUTE";
        }
    }
}