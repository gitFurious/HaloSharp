using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using NUnit.Framework;

namespace HaloSharp.Test.Utility
{
    public class SchemaUtility
    {
        public static void AssertSchemaIsValid(JSchema jSchema, JContainer jContainer)
        {
            IList<string> messages;
            var isValid = jContainer.IsValid(jSchema, out messages);
            foreach (var message in messages)
            {
                Console.WriteLine(message);
            }

            Assert.IsTrue(isValid);
        }
    }
}
