using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using NUnit.Framework;

namespace HaloSharp.Test.Utility
{
    public class SerializationUtility<T>
    {
        // ReSharper disable once StaticMemberInGenericType
        private static readonly IFormatter Formatter = new BinaryFormatter();

        public static void AssertRoundTripSerializationIsPossible(T source)
        {
            var clone = CloneBySerialization(source);

            Assert.AreEqual(source, clone);
            Assert.IsFalse(ReferenceEquals(source, clone));
        }

        private static T CloneBySerialization(T source)
        {
            return Deserialize(Serialize(source));
        }

        private static T Deserialize(Stream stream)
        {
            stream.Position = 0;
            return (T) Formatter.Deserialize(stream);
        }

        private static Stream Serialize(object source)
        {
            Stream stream = new MemoryStream();
            Formatter.Serialize(stream, source);
            return stream;
        }
    }
}