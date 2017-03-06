using HaloSharp.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using HaloSharp.Model.HaloWars2.Stats.Events;

namespace HaloSharp.Converter
{
    internal class HaloWars2MatchEventConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(MatchEvent).IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var events = JArray.Load(reader);

            var matchEvents = new List<MatchEvent>();
            foreach (var @event in events)
            {
                var matchEventType = (Enumeration.HaloWars2.MatchEventType)Enum.Parse(typeof(Enumeration.HaloWars2.MatchEventType), @event["EventName"].Value<string>());

                switch (matchEventType)
                {
                    case Enumeration.HaloWars2.MatchEventType.BuildingConstructionQueued:
                        {
                            var buildingConstructionQueued = @event.ToObject<BuildingConstructionQueued>();
                            matchEvents.Add(buildingConstructionQueued);
                            break;
                        }
                    case Enumeration.HaloWars2.MatchEventType.BuildingConstructionCompleted:
                        {
                            var buildingConstructionCompleted = @event.ToObject<BuildingConstructionCompleted>();
                            matchEvents.Add(buildingConstructionCompleted);
                            break;
                        }
                    case Enumeration.HaloWars2.MatchEventType.BuildingRecycled:
                        {
                            var buildingRecycled = @event.ToObject<BuildingRecycled>();
                            matchEvents.Add(buildingRecycled);
                            break;
                        }
                    case Enumeration.HaloWars2.MatchEventType.BuildingUpgraded:
                        {
                            var buildingUpgraded = @event.ToObject<BuildingUpgraded>();
                            matchEvents.Add(buildingUpgraded);
                            break;
                        }
                    case Enumeration.HaloWars2.MatchEventType.CardCycled:
                        {
                            var cardCycled = @event.ToObject<CardCycled>();
                            matchEvents.Add(cardCycled);
                            break;
                        }
                    case Enumeration.HaloWars2.MatchEventType.CardPlayed:
                        {
                            var cardPlayed = @event.ToObject<CardPlayed>();
                            matchEvents.Add(cardPlayed);
                            break;
                        }
                    case Enumeration.HaloWars2.MatchEventType.Death:
                        {
                            var death = @event.ToObject<Death>();
                            matchEvents.Add(death);
                            break;
                        }
                    case Enumeration.HaloWars2.MatchEventType.FirefightWaveCompleted:
                        {
                            var firefightWaveCompleted = @event.ToObject<FirefightWaveCompleted>();
                            matchEvents.Add(firefightWaveCompleted);
                            break;
                        }
                    case Enumeration.HaloWars2.MatchEventType.FirefightWaveSpawned:
                        {
                            var firefightWaveSpawned = @event.ToObject<FirefightWaveSpawned>();
                            matchEvents.Add(firefightWaveSpawned);
                            break;
                        }
                    case Enumeration.HaloWars2.MatchEventType.FirefightWaveStarted:
                        {
                            var firefightWaveStarted = @event.ToObject<FirefightWaveStarted>();
                            matchEvents.Add(firefightWaveStarted);
                            break;
                        }
                    case Enumeration.HaloWars2.MatchEventType.LeaderPowerCast:
                        {
                            var leaderPowerCast = @event.ToObject<LeaderPowerCast>();
                            matchEvents.Add(leaderPowerCast);
                            break;
                        }
                    case Enumeration.HaloWars2.MatchEventType.LeaderPowerUnlocked:
                        {
                            var leaderPowerUnlocked = @event.ToObject<LeaderPowerUnlocked>();
                            matchEvents.Add(leaderPowerUnlocked);
                            break;
                        }
                    case Enumeration.HaloWars2.MatchEventType.ManaOrbCollected:
                        {
                            var manaOrbCollected = @event.ToObject<ManaOrbCollected>();
                            matchEvents.Add(manaOrbCollected);
                            break;
                        }
                    case Enumeration.HaloWars2.MatchEventType.MatchEnd:
                        {
                            var matchEnd = @event.ToObject<MatchEnd>();
                            matchEvents.Add(matchEnd);
                            break;
                        }
                    case Enumeration.HaloWars2.MatchEventType.MatchStart:
                        {
                            var matchStart = @event.ToObject<MatchStart>();
                            matchEvents.Add(matchStart);
                            break;
                        }
                    case Enumeration.HaloWars2.MatchEventType.PlayerEliminated:
                        {
                            var playerEliminated = @event.ToObject<PlayerEliminated>();
                            matchEvents.Add(playerEliminated);
                            break;
                        }
                    case Enumeration.HaloWars2.MatchEventType.PlayerJoinedMatch:
                        {
                            var playerJoinedMatch = @event.ToObject<PlayerJoinedMatch>();
                            matchEvents.Add(playerJoinedMatch);
                            break;
                        }
                    case Enumeration.HaloWars2.MatchEventType.PlayerLeftMatch:
                        {
                            var playerLeftMatch = @event.ToObject<PlayerLeftMatch>();
                            matchEvents.Add(playerLeftMatch);
                            break;
                        }
                    case Enumeration.HaloWars2.MatchEventType.PointCaptured:
                        {
                            var pointCaptured = @event.ToObject<PointCaptured>();
                            matchEvents.Add(pointCaptured);
                            break;
                        }
                    case Enumeration.HaloWars2.MatchEventType.PointCreated:
                        {
                            var pointCreated = @event.ToObject<PointCreated>();
                            matchEvents.Add(pointCreated);
                            break;
                        }
                    case Enumeration.HaloWars2.MatchEventType.PointStatusChange:
                        {
                            var pointStatusChange = @event.ToObject<PointStatusChange>();
                            matchEvents.Add(pointStatusChange);
                            break;
                        }
                    case Enumeration.HaloWars2.MatchEventType.ResourceHeartbeat:
                        {
                            var resourceHeartbeat = @event.ToObject<ResourceHeartbeat>();
                            matchEvents.Add(resourceHeartbeat);
                            break;
                        }
                    case Enumeration.HaloWars2.MatchEventType.ResourceTransferred:
                        {
                            var resourceTransferred = @event.ToObject<ResourceTransferred>();
                            matchEvents.Add(resourceTransferred);
                            break;
                        }
                    case Enumeration.HaloWars2.MatchEventType.TechResearched:
                        {
                            var techResearched = @event.ToObject<TechResearched>();
                            matchEvents.Add(techResearched);
                            break;
                        }
                    case Enumeration.HaloWars2.MatchEventType.UnitControlTransferred:
                        {
                            var unitControlTransferred = @event.ToObject<UnitControlTransferred>();
                            matchEvents.Add(unitControlTransferred);
                            break;
                        }
                    case Enumeration.HaloWars2.MatchEventType.UnitPromoted:
                        {
                            var unitPromoted = @event.ToObject<UnitPromoted>();
                            matchEvents.Add(unitPromoted);
                            break;
                        }
                    case Enumeration.HaloWars2.MatchEventType.UnitTrained:
                        {
                            var unitTrained = @event.ToObject<UnitTrained>();
                            matchEvents.Add(unitTrained);
                            break;
                        }
                    default:
                        {
                            var matchEvent = @event.ToObject<MatchEvent>();
                            matchEvents.Add(matchEvent);
                            break;
                        }
                }
            }

            return matchEvents;
        }

        public override bool CanWrite => false;

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}