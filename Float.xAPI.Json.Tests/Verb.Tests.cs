// <copyright file="Verb.Tests.cs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using Float.xAPI.Languages;
using Xunit;
using static Float.xAPI.Json.Tests.TestHelpers;

namespace Float.xAPI.Json.Tests
{
    public class VerbTests
    {
        [Fact]
        public void TestSerializeExample()
        {
            // see https://github.com/adlnet/xAPI-Spec/blob/master/xAPI-Data.md#example-3
            var expected = FormatJson(@"{
                ""id"":""http://example.com/xapi/verbs#defenestrated"",
                ""display"":{
                    ""en-US"":""defenestrated"",
                    ""es"" : ""defenestrado""
                }
            }");

            var id = new VerbId(new Uri("http://example.com/xapi/verbs#defenestrated"));
            var display = new LanguageMap(new Dictionary<ILanguageTag, string>
            {
                {
                    new LanguageTag(Language.English, Region.UnitedStates), "defenestrated"
                },
                {
                    new LanguageTag(Language.Spanish), "defenestrado"
                },
            });

            var verb = new Verb(id, display);
            var actual = Json.Serialize.Verb(verb);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestDeserializeExample()
        {
            var id = new VerbId(new Uri("http://example.com/xapi/verbs#defenestrated"));
            var display = new LanguageMap(new Dictionary<ILanguageTag, string>
            {
                {
                    new LanguageTag(Language.English, Region.UnitedStates), "defenestrated"
                },
                {
                    new LanguageTag(Language.Spanish), "defenestrado"
                },
            });

            var expected = new Verb(id, display);

            // see https://github.com/adlnet/xAPI-Spec/blob/master/xAPI-Data.md#example-3
            var jsonString = FormatJson(@"{
                ""id"":""http://example.com/xapi/verbs#defenestrated"",
                ""display"":{
                    ""en-US"":""defenestrated"",
                    ""es"" : ""defenestrado""
                }
            }");

            var actual = Json.Deserialize.ParseVerb(jsonString).Value;

            Assert.Equal(expected.Id, actual.Id);
            Assert.Equal(expected.Display, actual.Display);
            Assert.Equal(expected, actual);

            var notDisplay = new LanguageMap(new Dictionary<ILanguageTag, string>
            {
                {
                    new LanguageTag(Language.English, Region.UnitedStates), "defenestrated"
                },
            });

            var notActual = new Verb(id, notDisplay);

            Assert.Equal(expected.Id, notActual.Id);
            Assert.NotEqual(expected.Display, notActual.Display);

            // verb comparison is done using ID only
            Assert.Equal(expected, notActual);
        }

        [Fact]
        public void TestSerialize()
        {
            var verb = new Verb(new VerbId("http://example.com"), new LanguageMap(LanguageTag.EnglishUS, "example"));
            var str = Json.Serialize.Verb(verb);
            Assert.Equal("{\"id\":\"http://example.com/\",\"display\":{\"en-US\":\"example\"}}", str);
        }

        [Fact]
        public void TestDeserialize()
        {
            var json = ReadFile("data-verb-example.json");
            var verb = Json.Deserialize.ParseVerb(json).Value;
            Assert.Equal("http://example.com/xapi/verbs#defenestrated", verb.Id.Iri.AbsoluteUri);
            Assert.Equal(verb.Display.Keys.Select(arg => arg.ToString()), new string[] { "en-US", "es" });
            Assert.Equal(verb.Display.Values.Select(arg => arg.ToString()), new string[] { "defenestrated", "defenestrado" });
        }
    }
}
