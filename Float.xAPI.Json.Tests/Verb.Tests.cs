// <copyright file="Verb.Tests.cs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

using System;
using System.Collections.Generic;
using Float.xAPI.Languages;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;

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
            var actual = Json.Serialize(verb);

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

            var actual = Json.DeserializeVerb(jsonString);

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

        string FormatJson(string json)
        {
            return JToken.Parse(json).ToString(Formatting.None);
        }
    }
}
