// <copyright file="Verb.Tests.cs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

using System;
using System.Collections.Generic;
using Float.xAPI.Languages;
using Xunit;

namespace Float.xAPI.Tests
{
    public class VerbTests : IInitializationTests<Verb>, IEqualityTests, ISpecExampleTests
    {
        [Fact]
        public Verb TestValidInit()
        {
            var uri = new VerbId("http://www.gowithfloat.com");
            var map = new LanguageMap(LanguageTag.EnglishUS, "floated");
            return new Verb(uri, map);
        }

        [Fact]
        public void TestInvalidInit()
        {
            var uri = new VerbId("http://www.gowithfloat.com");
            var map = new LanguageMap(LanguageTag.EnglishUS, "floated");

            Assert.Throws<ArgumentNullException>(() => new Verb(uri, null));
        }

        [Fact]
        public void TestEquality()
        {
            var verb2 = new Verb(new VerbId("https://w3id.org/xapi/dod-isd/verbs/accessed"), LanguageMap.EnglishUS("accessed"));
            var verb3 = new Verb(
                new VerbId("https://w3id.org/xapi/dod-isd/verbs/accessed"),
                new LanguageMap(new LanguageTag(Language.Spanish, Region.Mexico), "acceso"));
            AssertHelper.Equality<Verb, IVerb>(verb2, verb3, (a, b) => a == b);
        }

        [Fact]
        public void TestInequality()
        {
            var verb1 = new Verb(new VerbId("https://w3id.org/xapi/adl/verbs/abandoned"), LanguageMap.EnglishUS("abandoned"));
            var verb2 = new Verb(new VerbId("https://w3id.org/xapi/dod-isd/verbs/accessed"), LanguageMap.EnglishUS("accessed"));
            AssertHelper.Inequality<Verb, IVerb>(verb1, verb2, (a, b) => a != b);
        }

        [Fact]
        public void TestExample()
        {
            var uri = new VerbId("http://example.com/xapi/verbs#defenestrated");
            var map = new LanguageMap(new Dictionary<ILanguageTag, string>
            {
                {
                    new LanguageTag(Language.English, Region.UnitedStates), "defenestrated"
                },
                {
                    new LanguageTag(Language.Spanish, Region.Mexico), "defenestrado"
                },
            });

            var verb = new Verb(uri, map);

            Assert.Equal(uri, verb.Id);
            Assert.Equal(map, verb.Display);

            var iverb = verb as IVerb;
            Assert.Equal(uri, iverb.Id);
            Assert.Equal(map, iverb.Display);
        }
    }
}
