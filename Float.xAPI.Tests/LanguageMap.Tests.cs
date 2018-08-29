// <copyright file="LanguageMap.Tests.cs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

using System;
using System.Globalization;
using System.Collections.Generic;
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
            var map = new Dictionary<CultureInfo, string>
            {
                {
                    new CultureInfo("en-US"), "sent"
                }
            };

            Assert.Single(map);
            Assert.Single(map.Keys);
            Assert.Single(map.Values);
            Assert.True(map.ContainsKey(new CultureInfo("en-US")));
        }

        [Fact]
        public void TestLanguageMap()
        {
            var map = new Dictionary<CultureInfo, string>
            {
                {
                    new CultureInfo("en-US"), "sent"
                },
                {
                    new CultureInfo("es-MX"), "expedido"
                }
            };

            Assert.Equal(2, map.Count);
            Assert.Equal(2, map.Keys.Count);
            Assert.Equal(2, map.Values.Count);
            Assert.True(map.ContainsKey(new CultureInfo("en-US")));
            Assert.True(map.ContainsKey(new CultureInfo("es-MX")));
            Assert.False(map.ContainsKey(new CultureInfo("fr-FR")));
            Assert.True(map.ContainsValue("sent"));
            Assert.True(map.ContainsValue("expedido"));
            Assert.False(map.ContainsValue("completed"));
        }

        [Fact]
        public void TestCreatePairs()
        {
            var list = new List<KeyValuePair<CultureInfo, string>>
            {
                new KeyValuePair<CultureInfo, string>(new CultureInfo("en-US"), "sent"),
                new KeyValuePair<CultureInfo, string>(new CultureInfo("es-MX"), "expedido")
            };

            //var pair = new LanguageMap(list);
            //Assert.Equal(2, pair.Count);
        }

        [Fact]
        public void TestLanguageMapCreate()
        {
            var map = new LanguageMap("es-MX", "expedido");
            Assert.Single(map);

            var map2 = new LanguageMap(new Dictionary<CultureInfo, string>
            {
                {
                    new CultureInfo("en-US"), "sent"
                }
            });
            Assert.Single(map2);

            Assert.Throws<ArgumentException>(() => new LanguageMap(new Dictionary<CultureInfo, string>()));

            var map3 = new LanguageMap(new CultureInfo("fr-FR"), "envoyé");
            Assert.Single(map3);

            var map4 = new LanguageMap();
            Assert.Empty(map4);
        }
    }
}
