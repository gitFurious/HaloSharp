using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace HaloSharp.Model.Metadata
{
    public class Medal
    {
        [JsonConverter(typeof (StringEnumConverter))]
        public Enumeration.MedalType Classification { get; set; } //TODO: enums don't match documentation.

        public string Description { get; set; }
        public int Difficulty { get; set; }
        public uint Id { get; set; }
        public string Name { get; set; }
        public SpriteLocation SpriteLocation { get; set; }

        // Internal use.
        //public Guid ContentId { get; set; }
    }

    public class SpriteLocation
    {
        public int Height { get; set; }
        public int Left { get; set; }
        public int SpriteHeight { get; set; }
        public string SpriteSheetUri { get; set; }
        public int SpriteWidth { get; set; }
        public int Top { get; set; }
        public int Width { get; set; }
    }
}