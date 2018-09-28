// <copyright file="Verb.Tests.cs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

using System;
using System.Collections.Generic;
using Float.xAPI.Languages;
using Xunit;
using static Float.xAPI.Tests.TestHelpers;

namespace Float.xAPI.Tests
{
    public class VerbTests : IInitializationTests<Verb>, IEqualityTests, IToStringTests, ISpecExampleTests, ISerializationTests
    {
        [Fact]
        public Verb TestValidInit()
        {
            var uri = new Uri("http://www.gowithfloat.com");
            var map = new LanguageMap(LanguageTag.EnglishUS, "floated");
            return new Verb(uri, map);
        }

        [Fact]
        public void TestInvalidInit()
        {
            var uri = new Uri("http://www.gowithfloat.com");
            var map = new LanguageMap(LanguageTag.EnglishUS, "floated");

            Assert.Throws<ArgumentNullException>(() => new Verb(null, map));
            Assert.Throws<ArgumentNullException>(() => new Verb(uri, null));
        }

        [Fact]
        public void TestEquality()
        {
            var verb1 = new Verb(new Uri("https://w3id.org/xapi/adl/verbs/abandoned"), LanguageMap.EnglishUS("abandoned"));
            var verb2 = new Verb(new Uri("https://w3id.org/xapi/dod-isd/verbs/accessed"), LanguageMap.EnglishUS("accessed"));
            var verb3 = new Verb(
                new Uri("https://w3id.org/xapi/dod-isd/verbs/accessed"),
                new LanguageMap(new LanguageTag(Language.Spanish, Region.Mexico), "acceso"));
            Assert.Equal(verb2, verb3);
            Assert.Equal(verb2.Id, verb3.Id);
            Assert.Equal(verb2.GetHashCode(), verb3.GetHashCode());
            Assert.True(verb2 == verb3);
            Assert.False(verb2 != verb3);
        }

        [Fact]
        public void TestInequality()
        {
            var verb1 = new Verb(new Uri("https://w3id.org/xapi/adl/verbs/abandoned"), LanguageMap.EnglishUS("abandoned"));
            var verb2 = new Verb(new Uri("https://w3id.org/xapi/dod-isd/verbs/accessed"), LanguageMap.EnglishUS("accessed"));
            Assert.NotEqual(verb1, verb2);
            Assert.NotEqual(verb1.GetHashCode(), verb2.GetHashCode());
            Assert.False(verb1 == verb2);
            Assert.True(verb1 != verb2);
        }

        [Fact]
        public void TestToString()
        {
            var display = new LanguageMap(new Dictionary<ILanguageTag, string>
            {
                {
                    new LanguageTag(Language.Spanish, Region.Mexico), "acceso"
                },
                {
                    new LanguageTag(Language.English, Region.UnitedStates), "accessed"
                }
            });
            var verb3 = new Verb(
                new Uri("https://w3id.org/xapi/dod-isd/verbs/accessed"),
                display);
            Assert.Equal($"<Verb: Id https://w3id.org/xapi/dod-isd/verbs/accessed Display {verb3.Display}>", verb3.ToString());
        }

        [Fact]
        public void TestExample()
        {
            var uri = new Uri("http://example.com/xapi/verbs#defenestrated");
            var map = new LanguageMap(new Dictionary<ILanguageTag, string>
            {
                {
                    new LanguageTag(Language.English, Region.UnitedStates), "defenestrated"
                },
                {
                    new LanguageTag(Language.Spanish, Region.Mexico), "defenestrado"
                }
            });

            var verb = new Verb(uri, map);

            Assert.Equal(uri, verb.Id);
            Assert.Equal(map, verb.Display);

            var iverb = verb as IVerb;
            Assert.Equal(uri, iverb.Id);
            Assert.Equal(map, iverb.Display);
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
