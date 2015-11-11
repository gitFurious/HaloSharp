﻿using HaloSharp.Extension;
using HaloSharp.Model.Metadata;
using HaloSharp.Query.Metadata;
using HaloSharp.Test.Utility;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HaloSharp.Test.Query.Metadata
{
    [TestFixture]
    public class GetImpulsesTests : TestSessionSetup
    {
        [Test]
        public async Task GetImpulses()
        {
            var query = new GetImpulses()
                .SkipCache();

            var result = await Session.Query(query);

            Assert.IsInstanceOf(typeof (List<Impulse>), result);
        }

        [Test]
        public async Task GetImpulses_IsSerializable()
        {
            var query = new GetImpulses()
                .SkipCache();

            var result = await Session.Query(query);

            var serializationUtility = new SerializationUtility<List<Impulse>>();
            serializationUtility.AssertRoundTripSerializationIsPossible(result);
        }
    }
}