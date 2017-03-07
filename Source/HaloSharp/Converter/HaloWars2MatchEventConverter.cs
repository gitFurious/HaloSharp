using HaloSharp.Model;
using HaloSharp.Model.HaloWars2.Stats.Events;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

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

                MatchEvent matchEvent;
                switch (matchEventType)
                {
                    case Enumeration.HaloWars2.MatchEventType.BuildingConstructionQueued:
                        {
                            matchEvent = @event.ToObject<BuildingConstructionQueued>();
                            break;
                        }
                    case Enumeration.HaloWars2.MatchEventType.BuildingConstructionCompleted:
                        {
                            matchEvent = @event.ToObject<BuildingConstructionCompleted>();
                            break;
                        }
                    case Enumeration.HaloWars2.MatchEventType.BuildingRecycled:
                        {
                            matchEvent = @event.ToObject<BuildingRecycled>();
                            break;
                        }
                    case Enumeration.HaloWars2.MatchEventType.BuildingUpgraded:
                        {
                            matchEvent = @event.ToObject<BuildingUpgraded>();
                            break;
                        }
                    case Enumeration.HaloWars2.MatchEventType.CardCycled:
                        {
                            matchEvent = @event.ToObject<CardCycled>();
                            break;
                        }
                    case Enumeration.HaloWars2.MatchEventType.CardPlayed:
                        {
                            matchEvent = @event.ToObject<CardPlayed>();
                            break;
                        }
                    case Enumeration.HaloWars2.MatchEventType.Death:
                        {
                            matchEvent = @event.ToObject<Death>();
                            break;
                        }
                    case Enumeration.HaloWars2.MatchEventType.FirefightWaveCompleted:
                        {
                            matchEvent = @event.ToObject<FirefightWaveCompleted>();
                            break;
                        }
                    case Enumeration.HaloWars2.MatchEventType.FirefightWaveSpawned:
                        {
                            matchEvent = @event.ToObject<FirefightWaveSpawned>();
                            break;
                        }
                    case Enumeration.HaloWars2.MatchEventType.FirefightWaveStarted:
                        {
                            matchEvent = @event.ToObject<FirefightWaveStarted>();
                            break;
                        }
                    case Enumeration.HaloWars2.MatchEventType.LeaderPowerCast:
                        {
                            matchEvent = @event.ToObject<LeaderPowerCast>();
                            break;
                        }
                    case Enumeration.HaloWars2.MatchEventType.LeaderPowerUnlocked:
                        {
                            matchEvent = @event.ToObject<LeaderPowerUnlocked>();
                            break;
                        }
                    case Enumeration.HaloWars2.MatchEventType.ManaOrbCollected:
                        {
                            matchEvent = @event.ToObject<ManaOrbCollected>();
                            break;
                        }
                    case Enumeration.HaloWars2.MatchEventType.MatchEnd:
                        {
                            matchEvent = @event.ToObject<MatchEnd>();
                            break;
                        }
                    case Enumeration.HaloWars2.MatchEventType.MatchStart:
                        {
                            matchEvent = @event.ToObject<MatchStart>();
                            break;
                        }
                    case Enumeration.HaloWars2.MatchEventType.PlayerEliminated:
                        {
                            matchEvent = @event.ToObject<PlayerEliminated>();
                            break;
                        }
                    case Enumeration.HaloWars2.MatchEventType.PlayerJoinedMatch:
                        {
                            matchEvent = @event.ToObject<PlayerJoinedMatch>();
                            break;
                        }
                    case Enumeration.HaloWars2.MatchEventType.PlayerLeftMatch:
                        {
                            matchEvent = @event.ToObject<PlayerLeftMatch>();
                            break;
                        }
                    case Enumeration.HaloWars2.MatchEventType.PointCaptured:
                        {
                            matchEvent = @event.ToObject<PointCaptured>();
                            break;
                        }
                    case Enumeration.HaloWars2.MatchEventType.PointCreated:
                        {
                            matchEvent = @event.ToObject<PointCreated>();
                            break;
                        }
                    case Enumeration.HaloWars2.MatchEventType.PointStatusChange:
                        {
                            matchEvent = @event.ToObject<PointStatusChange>();
                            break;
                        }
                    case Enumeration.HaloWars2.MatchEventType.ResourceHeartbeat:
                        {
                            matchEvent = @event.ToObject<ResourceHeartbeat>();
                            break;
                        }
                    case Enumeration.HaloWars2.MatchEventType.ResourceTransferred:
                        {
                            matchEvent = @event.ToObject<ResourceTransferred>();
                            break;
                        }
                    case Enumeration.HaloWars2.MatchEventType.TechResearched:
                        {
                            matchEvent = @event.ToObject<TechResearched>();
                            break;
                        }
                    case Enumeration.HaloWars2.MatchEventType.UnitControlTransferred:
                        {
                            matchEvent = @event.ToObject<UnitControlTransferred>();
                            break;
                        }
                    case Enumeration.HaloWars2.MatchEventType.UnitPromoted:
                        {
                            matchEvent = @event.ToObject<UnitPromoted>();
                            break;
                        }
                    case Enumeration.HaloWars2.MatchEventType.UnitTrained:
                        {
                            matchEvent = @event.ToObject<UnitTrained>();
                            break;
                        }
                    default:
                        {
                            matchEvent = @event.ToObject<MatchEvent>();
                            break;
                        }
                }
                matchEvents.Add(matchEvent);
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