namespace Kiwiland.Service.Test;

using Xunit;

public class KiwilandServiceShould
{
    private TripsSearchEngine engine;
    private string graph = "AB5, BC4, CD8, DC8, DE6, AD5, CE2, EB3, AE7";
    
    public KiwilandServiceShould()
    {
        engine = new TripsSearchEngine(graph);
    }
    
    //Test 1 to 4
    [Theory]
    [InlineData("A-B-C", 9)]
    [InlineData("A-D", 5)]
    [InlineData("A-D-C", 13)]
    [InlineData("A-E-B-C-D", 22)]
    public void GetCorrecDistanceForRoute(string route, int expectedDistance)
    {
        //Arrang
        //Acts
        var result = engine.GetDistanceFromRoute(route);

        //Assets
        Assert.Equal(expectedDistance, result);
    }

    //Test 5
    [Theory]
    [InlineData("A-E-D", "NO SUCH ROUTE")]
    public void GetInexistentRoute(string route, string expected)
    {
    //Arrang
        //Acts
        InexistentRouteException noRouteExist = new();
        try
        {
            var result = engine.GetDistanceFromRoute(route);

        }
        catch (InexistentRouteException e)
        {
            noRouteExist = e;
        }

        //Assets
        Assert.Equal(expected, noRouteExist.Message);
    }

    
    //Test 6
    [Theory]
    [InlineData('C', 'C', 3, 2)]
    [InlineData('C', 'C', 4, 3)]
    public void EvaluateNumberOfRoutes(char start, char end, int maxNumbersStops, int expected)
    {
        //Arrange
        
        //Acts
        var result = engine.GetRoutesWithMaxNumberOfStops(start, end, maxNumbersStops).Count;
        
        //Assets
        Assert.Equal(expected, result);
        
    }
    
    //Test 7
    [Theory]
    [InlineData('A', 'C', 4, 3)] 
    public void EvaluateNumberOfRoutesWithExtactNumberOfStop(char start, char end, int maxNumbersStops, int expected)
    {
        //Arrange
        
        //Acts
        var result = engine.GetRoutesWithExactNumberOfStops(start, end, maxNumbersStops).Count;
        
        //Assets
        Assert.Equal(expected, result);
        
    }
    
    [Theory]
    [InlineData('A', 'C', 9)]
    [InlineData('B', 'B', 9)]
    public void FindTheLenghtOfTheShortestRoute(char start, char end, int expected)
    {
        ITrip shortest = engine.GetShortestRouteBetween(start, end);
        var result = shortest.GetDistance();
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData('C', 'C', 30, 7)]
    public void FindAllDifferentRoutes(char start, char end, int maxDistanceRestriction, int expected)
    {
        //This test specify a max distance restriction to get the diferent routes 
        var result = engine.GetRoutesWithDistanceLowerThan(maxDistanceRestriction, start, end).Count;
        Assert.Equal(expected, result);
    }

    
}