# HaloSharp #

The purpose of this project is to create a dead simple C# wrapper for the official Halo® Game Data API ([developer.haloapi.com](https://developer.haloapi.com)).

HaloSharp attempts to fully support all available official endpoints.

## Usage ##

1. Create an instance of `HaloClient` (provide your API Key).
2. Call the `StartSession` method.
3. Call the `.Query<TResult>()` method and pass in a prepackaged Query object.

###### Sample ######

```
var client = new HaloClient("00000000000000000000000000000000");

using (var session = client.StartSession())
{
    var query = new GetMatches()
      .InGameMode(Enumeration.GameMode.Arena)
      .ForPlayer("Furiousn00b");
        
    var matchSet = await Session.Query(query);
    
    foreach (var result in matchSet.Results)
    {
        Console.WriteLine($"MatchId: {match.Id.MatchId}");
    }
}
```

## NuGet ##

A Nuget package is available at [www.nuget.org/packages/HaloSharp](https://www.nuget.org/packages/HaloSharp) 

`PM> Install-Package HaloSharp`

## To Do ##

* Rate limiting.
* Better unit testing.

## Notes ##

* The Halo® Game Data API is still in a Beta period. Breaking changes are to be expected.
* Pull requests are welcome. Especially if you're cleaing out the todo list :)
* If you see something or think something could be done better, shout out. I'm all ears.
* Review the HaloSharp.Test project for examples on each of the different endpoints and their usages.
* You'll need to provide your own API Key to run the test suite. ([Setup.cs](https://github.com/gitFurious/HaloSharp/blob/master/Source/HaloSharp.Test/Setup.cs))

## About ##
This application is offered by Damon Pollard, which is solely responsible for its content. It is not sponsored or endorsed by Microsoft. This application uses the Halo® Game Data API. Halo © 2015 Microsoft Corporation. All rights reserved. Microsoft, Halo, and the Halo Logo are trademarks of the Microsoft group of companies.
