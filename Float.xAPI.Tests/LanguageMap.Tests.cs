// <copyright file="LanguageMap.Tests.cs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

using System;
using System.Collections.Generic;
using Float.xAPI.Languages;
using Xunit;

namespace Float.xAPI.Tests
{
    public class LanguageMapTests : IInitializationTests, IEqualityTests, IToStringTests
    {
        [Fact]
        public void TestValidInit()
        {

        }

        [Fact]
        public void TestInvalidInit()
        {

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
        public void TestSingleLanguageMap()
        {
            var map = new LanguageMap(LanguageTag.EnglishUS, "sent");
            Assert.Single(map);
        }

        [Fact]
        public void TestLanguageMap()
        {

        }

        [Fact]
        public void TestCreatePairs()
        {
            var list = new List<KeyValuePair<ILanguageTag, string>>
            {
                new KeyValuePair<ILanguageTag, string>(new LanguageTag(Language.English, Region.UnitedStates), "sent"),
                new KeyValuePair<ILanguageTag, string>(new LanguageTag(Language.Spanish, Region.Mexico), "expedido")
            };

            //var pair = new LanguageMap(list);
            //Assert.Equal(2, pair.Count);
        }

        [Fact]
        public void TestLanguageMapCreate()
        {
            var map = new LanguageMap(new LanguageTag(Language.Spanish, Region.Mexico), "expedido");
            Assert.Single(map);

            var map2 = new LanguageMap(new Dictionary<ILanguageTag, string>
            {
                {
                    LanguageTag.EnglishUS, "sent"
                }
            });
            Assert.Single(map2);

            Assert.Throws<ArgumentException>(() => new LanguageMap(new Dictionary<ILanguageTag, string>()));

            var map3 = new LanguageMap(new LanguageTag(Language.French, Region.France), "envoyé");
            Assert.Single(map3);

            var map4 = new LanguageMap();
            Assert.Empty(map4);
        }
    }
}
