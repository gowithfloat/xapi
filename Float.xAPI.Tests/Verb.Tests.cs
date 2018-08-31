// // <copyright file="Verb.Tests.cs" company="Float">
// // Copyright (c) 2018 Float, All rights reserved.
// // Shared under an MIT license. See license.md for details.
// // </copyright>

using System;
using System.Collections.Generic;
using System.Globalization;
using Float.xAPI.Languages;
using Xunit;

namespace Float.xAPI.Tests
{
    public class VerbTests : IInitializationTests, IEqualityTests, IToStringTests, ISpecExampleTests
    {
        [Fact]
        public void TestInvalidInit()
        {
            var uri = new Uri("http://www.gowithfloat.com");
            var map = new LanguageMap(LanguageTag.EnglishUS, "floated");
            var map2 = new LanguageMap();

            Assert.Throws<ArgumentNullException>(() => new Verb(null, map));
            Assert.Throws<ArgumentException>(() => new Verb(uri, map2));
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
    }
}
