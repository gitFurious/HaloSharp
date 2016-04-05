# HaloSharp #

The purpose of this project is to create a dead simple C# wrapper for the official Halo® Game Data API ([developer.haloapi.com](https://developer.haloapi.com)).

HaloSharp attempts to fully support all available official endpoints.

### Usage ###

1. Create an instance of `HaloClient`. Provide your SubscriptionKey at a minimum, optionally include a RateLimit and CacheDuration(s).
2. Call the `StartSession` method.
3. Call the `.Query<TResult>()` method and pass in a prepackaged Query object.

###### Sample ######

```
var developerAccessProduct = new Product
{
    SubscriptionKey = "00000000000000000000000000000000",
    RateLimit = new RateLimit
    {
        RequestCount = 10,
        TimspSpan = new TimeSpan(0, 0, 0, 10),
        Timeout = Timeout.InfiniteTimeSpan
    }
};

var cacheSettings = new CacheSettings
{
	MetadataCacheDuration = new TimeSpan(0, 0, 10, 0),
	ProfileCacheDuration = new TimeSpan(0, 0, 10, 0),
	StatsCacheDuration = null //Don't cache 'Stats' endpoints.
};

var client = new HaloClient(developerAccessProduct, cacheSettings);

using (var session = client.StartSession())
{
    var query = new GetMatches()
      .InGameMode(Enumeration.GameMode.Arena)
      .ForPlayer("Furiousn00b");

    var matchSet = await session.Query(query);

    foreach (var result in matchSet.Results)
    {
        Console.WriteLine($"MatchId: {result.Id.MatchId}");
    }
}
```

### NuGet ###

A Nuget package is available at [www.nuget.org/packages/HaloSharp](https://www.nuget.org/packages/HaloSharp) 

`PM> Install-Package HaloSharp`

### Changelog ###

###### v.1.4.1.0 (2016-04-05)

1. Fixed a bug where I was using an int instead of an Enum (DeathDisposition)

###### v.1.4.0.0 (2016-04-05)

1. Stats Endpoints.
  * Events for Match

###### v.1.3.2.0 (2016-04-04)

1. Updated BaseMatch model.
  * New property: GameVariantResourceId
  * New property: MapVariantResourceId
  
1. Updated BasePlayerStat model.
  * New property: PlayerScore (Firefight Hype!?)

###### v.1.3.1.0 (2016-03-16)

1. Fixed a bug where every result is cached when the CacheDuration was not set.

###### v.1.3.0.0 (2016-03-13)

1. Fixed an issue with unhandled HighestCsrSeasonId values (Reported by 'b01000100' and 'RHIT Propensity').
2. Added the ability to specify cache durations (expiration). Metadata, Profile, and Stats can be independently set (or not at all).
3. Fixed a couple of spelling mistakes. Breaking change :)

###### v.1.2.3.0 (2016-02-25)

1. Updated Medal enum.
  * New Medal Type: Ball

###### v.1.2.2.0 (2016-02-20)

1. Updated Medal enum.
  * New Medal Type: Goal

2. Updated Requisition model.
  * New property: HideIfNotAcquired

###### v.1.2.1.0 (2016-02-14)

1. Updated CampaignMatch model.
  * New property: CharacterIndex

2. Updated MatchSet model.
  * New property: MatchCompletedDateFidelity

###### v.1.2.0.0 (2016-01-31)

1. Query validation.
  * Validation exceptions will be thrown for bad queries (missing mandatory fields, invalid gamertags etc.).

2. Updated GetArenaServiceRecord query.
  * New SeasonId parameter.

3. Updated ArenaServiceRecord model.
  * New property: ArenaPlaylistStatsSeasonId
  * New property: HighestCsrSeasonId

4. Updated Requisition model.
  * New property: LevelRequirement

###### v.1.1.0.0 (2015-12-26)

1. Rate Limiter
  * Optional rate limiter with timeout settings.

2. JSON Structural Validation (JSON Schema).
  * A significant update to the test harness. Using JSON schemas to detect changes to API responses.

3. Serialization.
  * Strongly typed models are now serializable.

4. Metadata Endpoints.
  * Seasons

5. Profile Endpoints
  * Emblem Url
  * Spartan Url

###### v.1.0.0.0 (2015-11-04)######

1. Metadata Endpoints
  * Campaign Missions
  * Commendations
  * CSR Designations
  * Enemies
  * Flexible Stats
  * Game Base Variants
  * Game Variants
  * Impulses
  * Map Variants
  * Maps
  * Medals
  * Playlists
  * Requisition Packs
  * Requisitions
  * Skulls
  * Spartan Ranks
  * Team Colors
  * Vehicles
  * Weapons

2. Profile Endpoints
  * Emblem Image
  * Spartan Image

3. Stats Endpoints
  * Player Matches 
  * Arena Carnage Report
  * Arena Service Record
  * Campaign Carnage Report
  * Campaign Service Record
  * Custom Carnage Report
  * Custom Service Record
  * Warzone Carnage Report
  * Warzone Service Record


### Notes ###

* The Halo® Game Data API is still in a Beta period. Breaking changes are to be expected.
* Pull requests are welcome.
* If you see something or think something could be done better, shout out. I'm all ears.
* Review the HaloSharp.Test project for examples on each of the different endpoints and their usages.
* You'll need to provide your own API Key to run the test suite. ([Setup.cs](https://github.com/gitFurious/HaloSharp/blob/master/Source/HaloSharp.Test/Setup.cs))

### About ###
This application is offered by Damon Pollard, which is solely responsible for its content. It is not sponsored or endorsed by Microsoft. This application uses the Halo® Game Data API. Halo © 2015 Microsoft Corporation. All rights reserved. Microsoft, Halo, and the Halo Logo are trademarks of the Microsoft group of companies.
