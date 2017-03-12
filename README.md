# HaloSharp #

The purpose of this project is to create a dead simple C# wrapper for the official Halo® Game Data API ([developer.haloapi.com](https://developer.haloapi.com)).

HaloSharp attempts to fully support all available official endpoints.

### Features ###

* All available games (Halo 5, Halo 5: Forge, Halo Wars 2).
* Query builders for all endpoints.
* Request rate limiter.
* Response caching.

### Usage ###

1. Create an instance of `HaloClient`. Provide your SubscriptionKey at a minimum, optionally include a RateLimit and CacheDuration(s).
2. Call the `StartSession` method.
3. Call the `.Query<TResult>()` method and pass in a prepackaged Query object.

###### Sample ######

```
var product = new Product
{
	SubscriptionKey = "00000000000000000000000000000000",
	RateLimit = new RateLimit
	{
		RequestCount = 200,
		TimeSpan = new TimeSpan(0, 0, 0, 10),
		Timeout = new TimeSpan(0, 0, 0, 10)
	}
};

var cacheSettings = new CacheSettings
{
	CacheDuration = new TimeSpan(0, 1, 0, 0)
};

var haloClient = new HaloClient(product, cacheSettings);

using (var session = haloClient.StartSession())
{
    var halo5MatchHistory = new Query.Halo5.Stats.GetMatchHistory("Furiousn00b");

    var halo5MatchSet = await session.Query(halo5MatchHistory);

    foreach (var result in halo5MatchSet.Results)
    {
        System.Console.WriteLine($"H5: MatchId: {result.Id.MatchId}");
    }
	
	var haloWars2MatchHistory = new Query.HaloWars2.Stats.GetMatchHistory("Furiousn00b");

    var haloWars2MatchSet = await session.Query(haloWars2MatchHistory);

    foreach (var result in haloWars2MatchSet.Results)
    {
        System.Console.WriteLine($"HW2: MatchId: {match.MatchId}");
    }
}
```

### NuGet ###

A Nuget package is available at [www.nuget.org/packages/HaloSharp](https://www.nuget.org/packages/HaloSharp) 

`PM> Install-Package HaloSharp`

### Notes ###

* The Halo® Game Data API is still in a Beta period. Breaking changes are to be expected.
* Pull requests are welcome.
* If you see something or think something could be done better, shout out. I'm all ears.
* Review the HaloSharp.Test project for examples on each of the different endpoints and their usages.
* You'll need to provide your own API Key to run the test suite. ([Setup.cs](https://github.com/gitFurious/HaloSharp/blob/master/Source/HaloSharp.Test/Setup.cs))

### About ###
This application is offered by Damon Pollard, which is solely responsible for its content. It is not sponsored or endorsed by Microsoft. This application uses the Halo® Game Data API. Halo © 2015 Microsoft Corporation. All rights reserved. Microsoft, Halo, and the Halo Logo are trademarks of the Microsoft group of companies.
