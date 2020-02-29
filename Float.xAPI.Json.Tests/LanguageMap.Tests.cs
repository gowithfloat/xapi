﻿// <copyright file="LanguageMap.Tests.cs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using Float.xAPI.Languages;
using Xunit;

namespace Float.xAPI.Json.Tests
{
    public class LanguageMapTests
    {
        [Fact]
        public void TestSerialize()
        {
            var map1 = new LanguageMap(LanguageTag.EnglishUS, "launched");
            var map2 = new LanguageMap(new Dictionary<ILanguageTag, string>
            {
                { new LanguageTag(Language.French, Region.France), "envoyé" },
            });

            var serialized1 = Json.SerializeLanguageMap(map1);
            var serialized2 = Json.SerializeLanguageMap(map2);

            Console.WriteLine(serialized1);
            Console.WriteLine(serialized2);

            Assert.Equal("{\"en-US\":\"launched\"}", serialized1);
            Assert.Equal("{\"fr-FR\":\"envoyé\"}", serialized2);
        }

        [Fact]
        public void TestDeserialize()
        {
            var json1 = "{\"en-US\":\"launched\"}";
            var map1 = Json.DeserializeLanguageMap(json1);

            Assert.True(map1.ContainsKey(LanguageTag.EnglishUS));
            Assert.Contains("launched", map1.Values);
        }
    }
}
