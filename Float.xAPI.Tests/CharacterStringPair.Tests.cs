// <copyright file="CharacterStringPair.Tests.cs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

using System;
using System.Collections.Generic;
using Float.xAPI.Activities.Definitions;
using Float.xAPI.Languages;
using Xunit;

namespace Float.xAPI.Tests
{
    public class CharacterStringPairTests : IInitializationTests<CharacterStringPair>, IToStringTests, IPropertyTests
    {
        [Fact]
        public CharacterStringPair TestValidInit()
        {
            var items1 = new Dictionary<string, ICharacterString>
            {
                {
                    "one", new CharacterString("1")
                },
                {
                    "two", new CharacterString("2")
                },
                {
                    "three", new CharacterString("3")
                }
            };
            var csp1 = new CharacterStringPair(items1);

            var items2 = new List<Tuple<string, ICharacterString>>
            {
                new Tuple<string, ICharacterString>("a", new CharacterString("A")),
                new Tuple<string, ICharacterString>("b", new CharacterString("B")),
                new Tuple<string, ICharacterString>("c", new CharacterString("C"))
            };

            var csp2 = new CharacterStringPair(items2);
            var csp3 = new CharacterStringPair(items1, new LanguageTag(Language.LubaKatanga));
            return new CharacterStringPair(items2, LanguageTag.EnglishUS);
        }

        [Fact]
        public void TestInvalidInit()
        {
            Assert.Throws<ArgumentNullException>(() => new CharacterStringPair(itemSeq: null));
            Assert.Throws<ArgumentNullException>(() => new CharacterStringPair(itemPairs: null));
            Assert.Throws<ArgumentException>(() => new CharacterStringPair(itemSeq: new List<Tuple<string, ICharacterString>>()));
            Assert.Throws<ArgumentException>(() => new CharacterStringPair(itemPairs: new Dictionary<string, ICharacterString>()));
            Assert.Throws<ArgumentException>(() => new CharacterStringPair(itemSeq: new List<Tuple<string, ICharacterString>> { new Tuple<string, ICharacterString>(null, new CharacterString("test")) }));
            Assert.Throws<ArgumentException>(() => new CharacterStringPair(itemPairs: new Dictionary<string, ICharacterString> { { string.Empty, new CharacterString("test") } }));
        }

        [Fact]
        public void TestToString()
        {
            var dict = new Dictionary<string, ICharacterString>
            {
                {
                    "ben", new CharacterString("3")
                },
                {
                    "chris", new CharacterString("2")
                },
                {
                    "troy", new CharacterString("4")
                },
                {
                    "freddie", new CharacterString("1")
                }
            };
            var cs2 = new CharacterStringPair(dict);
            Assert.Equal("ben[.]3[,]chris[.]2[,]troy[.]4[,]freddie[.]1", cs2.ToString());
        }

        [Fact]
        public void TestMatchSingle()
        {
            var dict = new Dictionary<string, ICharacterString>
            {
                {
                    "ben", new CharacterString("3")
                },
                {
                    "chris", new CharacterString("2")
                },
                {
                    "troy", new CharacterString("4")
                },
                {
                    "freddie", new CharacterString("1")
                }
            };
            var cs2 = new CharacterStringPair(dict);
            Assert.Null(cs2.Match("bob"));
            Assert.Null(cs2.Match("a"));
            Assert.Equal("3", cs2.Match("ben").Value.ToString());
        }

        [Fact]
        public void TestMatchMultiple()
        {
            var dict = new Dictionary<string, ICharacterString>
            {
                {
                    "ben", new CharacterString("3")
                },
                {
                    "chris", new CharacterString("2")
                },
                {
                    "troy", new CharacterString("4")
                },
                {
                    "freddie", new CharacterString("1")
                }
            };

            var cs2 = new CharacterStringPair(dict);

            var responses1 = new Dictionary<string, ICharacterString>
            {
                {
                    "freddie", new CharacterString("1")
                },
                {
                    "chris", new CharacterString("2")
                },
                {
                    "ben", new CharacterString("3")
                },
                {
                    "troy", new CharacterString("4")
                }
            };

            Assert.True(cs2.Match(responses1));

            var responses2 = new Dictionary<string, ICharacterString>
            {
                {
                    "freddie", new CharacterString("4")
                },
                {
                    "chris", new CharacterString("3")
                },
                {
                    "ben", new CharacterString("2")
                },
                {
                    "troy", new CharacterString("1")
                }
            };

            Assert.False(cs2.Match(responses2));

            var responses3 = new List<Tuple<string, ICharacterString>>
            {
                new Tuple<string, ICharacterString>("freddie", new CharacterString("1")),
                new Tuple<string, ICharacterString>("chris", new CharacterString("2")),
                new Tuple<string, ICharacterString>("ben", new CharacterString("3")),
                new Tuple<string, ICharacterString>("troy", new CharacterString("4"))
            };

            Assert.True(cs2.Match(responses3));

            var ics2 = cs2 as ICharacterStringPair;
            Assert.True(ics2.Match(responses3));
        }

        [Fact]
        public void TestProperties()
        {
            var tuple = new Tuple<string, ICharacterString>("one", new CharacterString("two"));
            var array = new Tuple<string, ICharacterString>[] { tuple };
            var cs = new CharacterStringPair(array,  new LanguageTag(Language.Malagasy));
            Assert.Equal(new List<Tuple<string, ICharacterString>> { new Tuple<string, ICharacterString>("one", new CharacterString("two")) }, cs.Items);
            Assert.Equal(new LanguageTag(Language.Malagasy), cs.Language);

            var ics = cs as ICharacterStringPair;
            Assert.Equal(array, ics.Items);
            Assert.Equal(new LanguageTag(Language.Malagasy), ics.Language);
        }
    }
}
