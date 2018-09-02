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
    public class LanguageMapTests : IInitializationTests<LanguageMap>, IEqualityTests, IToStringTests, ISerializationTests
    {
        [Fact]
        public LanguageMap TestValidInit()
        {
            var map1 = new LanguageMap(LanguageTag.EnglishUS, "completed");
            var map2 = new LanguageMap(Language.Abkhazian, Region.Antarctica, "sent");
            var map3 = new LanguageMap(new Dictionary<ILanguageTag, string>
            {
                { new LanguageTag(Language.Kyrgyz, Region.Jamaica), "example1" },
                { new LanguageTag(Language.Sango, Region.Mauritius), "example2" }
            });
            var map4 = new LanguageMap(new List<KeyValuePair<ILanguageTag, string>>
            {
                new KeyValuePair<ILanguageTag, string>(
                    new LanguageTag(Language.Limburgish, Region.Liechtenstein),
                    "example3"
                ),
                new KeyValuePair<ILanguageTag, string>(
                    new LanguageTag(Language.Limburger, Region.Lebanon),
                    "example4"
                ),
                new KeyValuePair<ILanguageTag, string>(
                    new LanguageTag(Language.Limburgan, Region.LaoPeoplesDemocraticRepublic),
                    "example5"
                )
            });
            var map5 = new LanguageMap(new KeyValuePair<ILanguageTag, string>[]
            {
                new KeyValuePair<ILanguageTag, string>(
                    new LanguageTag(Language.Cree, Region.Qatar),
                    "example6"
                ),
                new KeyValuePair<ILanguageTag, string>(
                    new LanguageTag(Language.Chewa, Region.Yemen),
                    "example7"
                ),
                new KeyValuePair<ILanguageTag, string>(
                    new LanguageTag(Language.Cornish, Region.RussianFederation),
                    "example8"
                )
            });
            return LanguageMap.EnglishUS("example9");
        }

        [Fact]
        public void TestInvalidInit()
        {
            Assert.Throws<ArgumentNullException>(() => new LanguageMap(null, null));
            Assert.Throws<ArgumentException>(() => new LanguageMap(LanguageTag.EnglishUS, null));
            Assert.Throws<ArgumentException>(() => new LanguageMap(LanguageTag.EnglishUS, string.Empty));
            Assert.Throws<ArgumentException>(() => new LanguageMap(LanguageTag.EnglishUS, " "));
            Assert.Throws<ArgumentNullException>(() => new LanguageMap(null, Region.Algeria, "test"));
            Assert.Throws<ArgumentNullException>(() => new LanguageMap(Language.Pali, null, "test"));
            Assert.Throws<ArgumentException>(() => new LanguageMap(Language.Pali, Region.Algeria, null));
            Assert.Throws<ArgumentException>(() => new LanguageMap(new Dictionary<ILanguageTag, string>()));
            Assert.Throws<ArgumentException>(() => new LanguageMap(new List<KeyValuePair<ILanguageTag, string>>()));
            Assert.Throws<ArgumentException>(() => new LanguageMap(new KeyValuePair<ILanguageTag, string>[] {}));
        }

        [Fact]
        public void TestEquality()
        {
            var map1 = LanguageMap.EnglishUS("sent");
            var map2 = new LanguageMap(LanguageTag.EnglishUS, "sent");
            Assert.Equal(map1, map2);

            var map3 = new LanguageMap(new Dictionary<ILanguageTag, string>
            {
                { new LanguageTag(Language.Ido, Region.Panama), "example" },
                { new LanguageTag(Language.NorthNdebele, Region.UnitedArabEmirates), "test" }
            });
            var map4 = new LanguageMap(new Dictionary<ILanguageTag, string>
            {
                { new LanguageTag(Language.NorthNdebele, Region.UnitedArabEmirates), "test" },
                { new LanguageTag(Language.Ido, Region.Panama), "example" }
            });
            Assert.Equal(map3, map4);
        }

        [Fact]
        public void TestInequality()
        {
            var map1 = LanguageMap.EnglishUS("sent");
            var map2 = LanguageMap.EnglishUS("received");
            Assert.NotEqual(map1, map2);

            var map3 = new LanguageMap(new Dictionary<ILanguageTag, string>
            {
                { new LanguageTag(Language.Ido, Region.Panama), "example" },
                { new LanguageTag(Language.NorthNdebele, Region.UnitedArabEmirates), "test" }
            });
            var map4 = new LanguageMap(new Dictionary<ILanguageTag, string>
            {
                { new LanguageTag(Language.NorthNdebele, Region.UnitedArabEmirates), "test" },
                { new LanguageTag(Language.Ido, Region.Panama), "example2" }
            });
            Assert.NotEqual(map3, map4);
        }

        [Fact]
        public void TestToString()
        {
            var map1 = LanguageMap.EnglishUS("attempted");
            Assert.Equal("<LanguageMap: Map [en-US, attempted]>", map1.ToString());

            var map2 = new LanguageMap(new Dictionary<ILanguageTag, string>
            {
                {
                    new LanguageTag(Language.Latin, Region.Estonia),
                    "tested"
                },
                {
                    new LanguageTag(Language.Lingala, Region.Ethiopia),
                    "examined"
                }
            });
            Assert.Equal("<LanguageMap: Map [la-EE, tested], [ln-ET, examined]>", map2.ToString());
        }

        [Fact]
        public void TestSingle()
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
        }

        [Fact]
        public void TestSerialize()
        {
            var map1 = new LanguageMap(LanguageTag.EnglishUS, "launched");
            var map2 = new LanguageMap(new Dictionary<ILanguageTag, string>
            {
                { new LanguageTag(Language.French, Region.France), "envoyé" }
            });
        }

        [Fact]
        public void TestDeserialize()
        {
            var json1 = "{\"en-US\":\"launched\"}";
            Assert.NotNull(json1);
        }
    }
}
