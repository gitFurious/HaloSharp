using HaloSharp.Model;
using HaloSharp.Model.Halo5.Stats.CarnageReport.Events;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace HaloSharp.Converter
{
    internal class Halo5MatchEventConverter : JsonConverter
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
                var matchEventType = (Enumeration.Halo5.MatchEventType)Enum.Parse(typeof(Enumeration.Halo5.MatchEventType), @event["EventName"].Value<string>());

                MatchEvent matchEvent;
                switch (matchEventType)
                {
                    case Enumeration.Halo5.MatchEventType.Death:
                        {
                            matchEvent = @event.ToObject<Death>();
                            break;
                        }
                    case Enumeration.Halo5.MatchEventType.Impulse:
                        {
                            matchEvent = @event.ToObject<Impulse>();
                            break;
                        }
                    case Enumeration.Halo5.MatchEventType.Medal:
                        {
                            matchEvent = @event.ToObject<Medal>();
                            break;
                        }
                    case Enumeration.Halo5.MatchEventType.PlayerSpawn:
                        {
                            matchEvent = @event.ToObject<PlayerSpawn>();
                            break;
                        }
                    case Enumeration.Halo5.MatchEventType.RoundStart:
                        {
                            matchEvent = @event.ToObject<RoundStart>();
                            break;
                        }
                    case Enumeration.Halo5.MatchEventType.RoundEnd:
                        {
                            matchEvent = @event.ToObject<RoundEnd>();
                            break;
                        }
                    case Enumeration.Halo5.MatchEventType.WeaponDrop:
                        {
                            matchEvent = @event.ToObject<WeaponDrop>();
                            break;
                        }
                    case Enumeration.Halo5.MatchEventType.WeaponPickup:
                        {
                            matchEvent = @event.ToObject<WeaponPickup>();
                            break;
                        }
                    case Enumeration.Halo5.MatchEventType.WeaponPickupPad:
                        {
                            matchEvent = @event.ToObject<WeaponPickupPad>();
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