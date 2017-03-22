# HaloSharp #

### Changelog ###

###### v.2.0.1.0 (2017-03-22)

1. Updated HW2 Season Model.
  * Added property: Image4K
  * Fixed property: Playlists

###### v.2.0.0.0 (2017-03-12)

1. Breaking changes galore!

2. Halo Wars 2 - Metadata Endpoints
  * Campaign Levels
  * Campaign Logs
  * Card Keywords
  * Cards
  * CSR Designations
  * Difficulties
  * Game Object Categories
  * Game Objects
  * Leader Powers
  * Leaders
  * Maps
  * Packs
  * Playlists
  * Seasons
  * Spartan Ranks
  * Techs
  
3. Halo Wars 2 - Stats Endpoints
  * Match Events 
  * Match Result
  * Player Campaign Progress
  * Player Match History
  * Player Playlist Ratings
  * Player Seasons Stats Summary
  * Player Stats Summary
  * Player XPs
  
4. Halo 5 Forge - Stats Endpoints
  * Custom Carnage Report
  * Custom Service Record
  * Player Match History

###### v.1.6.1.0 (2016-12-08)

1. Updated RequisitionPack model.
  * New property: GiftableAcquisitionMethods
  * New property: IsGiftOnly

###### v.1.6.0.0 (2016-09-03)

1. Halo 5 - User Generated Content (UGC) Endpoints.
  * List Game Variants
  * Get Game Variant
  * List Map Variants
  * Get Map Variant

###### v.1.5.6.0 (2016-07-28)

1. Updated XpInfo model.
  * Updated: PerformanceXP

###### v.1.5.5.0 (2016-07-16)

1. Updated WarzoneMatch model.
  * Updated: PveTotalRoundAssistBonuses
  * Updated: PveTotalRoundKillBonuses
  * Updated: PveTotalRoundSpeedBonuses
  * Updated: PveTotalRoundSurvivalBonuses

###### v.1.5.4.0 (2016-06-30)

1. Updated Player Stat model.
  * New property: GameEndStatus

###### v.1.5.3.0 (2016-06-20)

1. Updated Warzone Match model.
  * New property: ObjectivesCompleted

###### v.1.5.2.0 (2016-06-02)

1. Updated Service Record models.
  * New property: FastestMatchWin
  
1. Updated ArenaMatch model.
  * New property: BoostInfo
  
1. Updated WarzoneMatch model.
  * New property: BoostInfo
  * New property: PveTotalRoundAssistBonuses
  * New property: PveTotalRoundKillBonuses
  * New property: PveTotalRoundSpeedBonuses
  * New property: PveTotalRoundSurvivalBonuses
  
###### v.1.5.1.0 (2016-05-12)

1. Added new Medal Enum (Infection Hype!).

###### v.1.5.0.0 (2016-04-21)

1. Halo 5 - Stats Endpoints.
  * Leaderboard for Season Playlists

2. Updated MatchEvents model 
  * New Event Types (Impulses, Medals, Player Spawns, Round Starts, Round Ends, Weapon Drops, Weapon Pickups, and Weapon Pickup Pads)

3. Updated ArenaPlaylistStat model.
  * New property: CsrPercentile

4. Updated XpInfo/CreditsEarned models.
  * New property: MatchSpeedWinAmount
  * New property: ObjectivesCompletedAmount

###### v.1.4.4.0 (2016-04-21)

1. Fixed the TimeSinceStart property on GameEvents. Should have been a TimeSpan from the start.

###### v.1.4.3.0 (2016-04-15)

1. Fixed a bug where getting an Arena Service Record for a defunct Gamertag would throw an exception.

###### v.1.4.2.0 (2016-04-06)

1. Updated MatchEvents model.
  * Rename: KillerAttachmentIds to KillerWeaponAttachmentIds
  * Rename: KillerStockId to KillerWeaponStockId

2. Fixed a bunch of tests related to MatchEvents.
  
###### v.1.4.1.0 (2016-04-05)

1. Fixed a bug where I was using an int instead of an Enum (DeathDisposition)

###### v.1.4.0.0 (2016-04-05)

1. Halo 5 - Stats Endpoints.
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

4. Halo 5 - Metadata Endpoints.
  * Seasons

5. Halo 5 - Profile Endpoints
  * Emblem Url
  * Spartan Url

###### v.1.0.0.0 (2015-11-04)######

1. Halo 5 - Metadata Endpoints
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

2. Halo 5 - Profile Endpoints
  * Emblem Image
  * Spartan Image

3. Halo 5 - Stats Endpoints
  * Player Matches 
  * Arena Carnage Report
  * Arena Service Record
  * Campaign Carnage Report
  * Campaign Service Record
  * Custom Carnage Report
  * Custom Service Record
  * Warzone Carnage Report
  * Warzone Service Record