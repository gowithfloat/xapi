// // <copyright file="Verb.Tests.cs" company="Float">
// // Copyright (c) 2018 Float, All rights reserved.
// // Shared under an MIT license. See license.md for details.
// // </copyright>

using System;
using System.Collections.Generic;
using Float.xAPI.Languages;
using Xunit;
using static Float.xAPI.Tests.TestHelpers;

namespace Float.xAPI.Tests
{
    public class VerbTests : IInitializationTests, IEqualityTests, IToStringTests, ISpecExampleTests, ISerializationTests
    {
        [Fact]
        public void TestInvalidInit()
        {
            var uri = new Uri("http://www.gowithfloat.com");
            var map = new LanguageMap(LanguageTag.EnglishUS, "floated");

            Assert.Throws<ArgumentNullException>(() => new Verb(null, map));
            Assert.Throws<ArgumentNullException>(() => new Verb(uri, null));
        }

        [Fact]
        public void TestValidInit()
        {
            var uri = new Uri("http://www.gowithfloat.com");
            var map = new LanguageMap(LanguageTag.EnglishUS, "floated");
            var verb = new Verb(uri, map);
        }

        [Fact]
        public void TestEquality()
        {

        }

        [Fact]
        public void TestInequality()
        {

        }

        [Fact]
        public void TestToString()
        {

        }

        [Fact]
        public void TestExample()
        {
            var uri = new Uri("http://example.com/xapi/verbs#defenestrated");
            var map = new Dictionary<ILanguageTag, string>
            {
                {
                    new LanguageTag(Language.English, Region.UnitedStates), "defenestrated"
                },
                {
                    new LanguageTag(Language.Spanish, Region.Mexico), "defenestrado"
                }
            };

            var verb = new Verb(uri, map);

            Assert.Equal(uri, verb.Id);
            Assert.Equal(map, verb.Display);
        }

        [Fact]
        public void TestSerialize()
        {
            var verb = new Verb(new Uri("http://example.com"), new LanguageMap(LanguageTag.EnglishUS, "example"));
        }

        [Fact]
        public void TestDeserialize()
        {
            var json = ReadFile("data-verb-example.json");
        }
    }
}
