namespace HaloSharp.Model.Metadata
{
    public class Vehicle
    {
        public string Description { get; set; }
        public uint Id { get; set; }
        public bool IsUsableByPlayer { get; set; }
        public string LargeIconImageUrl { get; set; }
        public string Name { get; set; }
        public string SmallIconImageUrl { get; set; }

        // Internal use.
        //public Guid ContentId { get; set; }
    }
}