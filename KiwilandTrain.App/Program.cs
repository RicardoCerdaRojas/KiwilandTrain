

using Kiwiland.Service;

Console.ForegroundColor = ConsoleColor.DarkCyan;

TripsSearchEngine engine = new TripsSearchEngine("AB5, BC4, CD8, DC8, DE6, AD5, CE2, EB3, AE7");

bool showMenu = true;

while (showMenu)
{
    showMenu = MainMenu();
}

bool MainMenu()
{
    Console.Clear();
    Console.Title = "Sales Taxes App";
    Console.WriteLine("Welcome to Kiwiland Routes APP!");
    Console.WriteLine("##########################");
    Console.WriteLine("Available stations today: A-B-C-D-E");
    Console.WriteLine("");
    Console.WriteLine("Choose an option:");
    Console.WriteLine("[1] Get Distance for a route (test 1 to 5)");
    Console.WriteLine("[2] Get number of routes (test 6)");
    Console.WriteLine("[3] Get number of routes with exact number of stops (test 7)");
    Console.WriteLine("[4] Find the lenght of the shortest route (test 8 to 9)");
    Console.WriteLine("[5] Find all diferent routes (test 10)");
    Console.WriteLine("[0] Exit");

    Console.Write("\r\nSelect an option: ");
 
    switch (Console.ReadLine())
    {
        case "1":
            GetDistanceRoutes();
            return true;
        case "2":
            GetNumberOfRoutes();
            return true;
        case "3":
            GetNumberOfRoutesWithExtactNumberOfStops();
            return true;
        case "4":
            FindLenghtShortestRoute();
            return true;
        case "5":
            FindDireferntRoutes();
            return true;
        case "0":
            return false;
        default:
            return true;
    }
}

void GetDistanceRoutes()
{
    string geValue;
    Console.Clear();
    Console.Title = "Sales Taxes App";
    Console.WriteLine("[1] Get Distance for a route (test 1 to 4)");
    Console.WriteLine("##########################");
    Console.WriteLine("Available stations today: A-B-C-D-E");
    Console.WriteLine("A-B-C     --> Expect 9");
    Console.WriteLine("A-D       --> Expect 5");
    Console.WriteLine("A-D-C     --> Expect 13");
    Console.WriteLine("A-E-B-C-D --> Expect 22");
    Console.WriteLine("");
    Console.Write("Insert route: ");
     string route = Console.ReadLine();

     try
     {
         var result = engine.GetDistanceFromRoute(route);
    
         Console.WriteLine("");
         Console.WriteLine("***********************************");
         Console.WriteLine("The distance for this route is: {0}", result);
         Console.WriteLine("***********************************");
         Console.WriteLine("");
         Console.WriteLine("Press any key to go back...");
         Console.ReadLine();

     }
     catch (InexistentRouteException e)
     {
         ErrorMessage(e.Message);
     }
     catch (Exception e)
     {
         ErrorMessage(e.Message);
     }
}
void GetNumberOfRoutes()
{
    Console.Clear();
    Console.Title = "Sales Taxes App";
    Console.WriteLine("[2] Get number of routes (test 6)");
    Console.WriteLine("##########################");
    Console.WriteLine("Available stations today: A-B-C-D-E");
    Console.WriteLine("start: C, end: C, MaxStops: 3, --> Expect 2");
    Console.WriteLine("start: C, end: C, MaxStops: 4, --> Expect 3");
    Console.WriteLine("");
    Console.Write("Insert the start Station: ");
    var start = Console.ReadLine();
    Console.Write("Insert the end Station: ");
    var end = Console.ReadLine();
    Console.Write("Insert Max Stops: ");
    var maxNumbersStops = Console.ReadLine();

    try
    {
        var result = engine.GetRoutesWithMaxNumberOfStops(Convert.ToChar(start) , 
                                                        Convert.ToChar(end), 
                                                        Convert.ToInt32(maxNumbersStops)).Count;
    
        Console.WriteLine("");
        Console.WriteLine("***********************************");
        Console.WriteLine("The number of routes is: {0}", result);
        Console.WriteLine("***********************************");
        Console.WriteLine("");
        Console.WriteLine("Press any key to go back...");
        Console.ReadLine();

    }
    catch (Exception e)
    {
        ErrorMessage(e.Message);
    }
}
void GetNumberOfRoutesWithExtactNumberOfStops()
{
    Console.Clear();
    Console.Title = "Sales Taxes App";
    Console.WriteLine("[3] Get number of routes with exact number of stops (test 7)");
    Console.WriteLine("##########################");
    Console.WriteLine("Available stations today: A-B-C-D-E");
    Console.WriteLine("start: A, end: C, MaxStops: 4, --> Expect 3");
    Console.WriteLine("");
    Console.Write("Insert the start Station: ");
    var start = Console.ReadLine();
    Console.Write("Insert the end Station: ");
    var end = Console.ReadLine();
    Console.Write("Insert Number os Stops: ");
    var maxNumbersStops = Console.ReadLine();

    try
    {
        var result = engine.GetRoutesWithExactNumberOfStops(Convert.ToChar(start) , 
            Convert.ToChar(end), 
            Convert.ToInt32(maxNumbersStops)).Count;
    
        Console.WriteLine("");
        Console.WriteLine("***********************************");
        Console.WriteLine("The number of routes is: {0}", result);
        Console.WriteLine("***********************************");
        Console.WriteLine("");
        Console.WriteLine("Press any key to go back...");
        Console.ReadLine();

    }
    catch (Exception e)
    {
        ErrorMessage(e.Message);
    }
}
void FindLenghtShortestRoute()
{
    Console.Clear();
    Console.Title = "Sales Taxes App";
    Console.WriteLine("[4] Find the lenght of the shortest route (test 8 to 9)");
    Console.WriteLine("##########################");
    Console.WriteLine("Available stations today: A-B-C-D-E");
    Console.WriteLine("start: A, end: C --> Expect 9");
    Console.WriteLine("start: B, end: B --> Expect 9");
    Console.WriteLine("");
    Console.Write("Insert the start Station: ");
    var start = Console.ReadLine();
    Console.Write("Insert the end Station: ");
    var end = Console.ReadLine();

    try
    {
        ITrip shortest = engine.GetShortestRouteBetween(Convert.ToChar(start) , 
            Convert.ToChar(end));
        var result = shortest.GetDistance();
        string stations = "";
        foreach (IEdge edge in shortest.Route)
        {
            if (stations.Length == 0)
                stations = edge.Start.ToString();
            else
                stations += " --> " + edge.Start.ToString();
        }
        stations += " --> " + end;
        
        Console.WriteLine("");
        Console.WriteLine("***********************************");
        Console.WriteLine("The shortest distance for this route is: {0}", result);
        Console.WriteLine("throw: {0}", stations);
        Console.WriteLine("***********************************");
        Console.WriteLine("");
        Console.WriteLine("Press any key to go back...");
        Console.ReadLine();

    }
    catch (Exception e)
    {
        ErrorMessage(e.Message);
    }
}
void FindDireferntRoutes()
{
    Console.Clear();
    Console.Title = "Sales Taxes App";
    Console.WriteLine("[5] Find all diferent routes (test 10)");
    Console.WriteLine("##########################");
    Console.WriteLine("Available stations today: A-B-C-D-E");
    Console.WriteLine("start: C, end: C, Distance Restriction: 30, --> Expect 7");
    Console.WriteLine("");
    Console.Write("Insert the start Station: ");
    var start = Console.ReadLine();
    Console.Write("Insert the end Station: ");
    var end = Console.ReadLine();
    Console.Write("Insert Number os Stops: ");
    var distanceRestriction = Console.ReadLine();

    try
    {
        var result = engine.GetRoutesWithDistanceLowerThan(Convert.ToInt32(distanceRestriction), 
            Convert.ToChar(start) , 
            Convert.ToChar(end)).Count;
    
        Console.WriteLine("");
        Console.WriteLine("***********************************");
        Console.WriteLine("The number of diferent routes is: {0}", result);
        Console.WriteLine("***********************************");
        Console.WriteLine("");
        Console.WriteLine("Press any key to go back...");
        Console.ReadLine();

    }
    catch (Exception e)
    {
        ErrorMessage(e.Message);
    }
}


void ErrorMessage(string message)
{
    Console.WriteLine("");
    Console.WriteLine("Ups... something wrong: {0}", message);
    Console.WriteLine("");
    Console.WriteLine("Press any key to go back...");
    Console.ReadLine();    
}

