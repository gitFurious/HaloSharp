using System;

namespace HaloSharp.Model.Stats.Common
{
    [Serializable]
    public class Identity
    {
        public string Gamertag { get; set; }

        // Internal use only.
        //public object Xuid { get; set; } //This will always be null.
    }
}