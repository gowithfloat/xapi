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
    public class CharacterStringPairTests : IInitializationTests<CharacterStringPair>, IToStringTests
    {
        [Fact]
        public CharacterStringPair TestValidInit()
        {
            var items1 = new Dictionary<string, string>
            {
                {
                    "one", "1"
                },
                {
                    "two", "2"
                },
                {
                    "three", "3"
                }
            };
            var csp1 = new CharacterStringPair(items1);

            var items2 = new List<Tuple<string, string>>
            {
                new Tuple<string, string>("a", "A"),
                new Tuple<string, string>("b", "B"),
                new Tuple<string, string>("c", "C")
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
            Assert.Throws<ArgumentException>(() => new CharacterStringPair(itemSeq: new List<Tuple<string, string>>()));
            Assert.Throws<ArgumentException>(() => new CharacterStringPair(itemPairs: new Dictionary<string, string>()));
            Assert.Throws<ArgumentException>(() => new CharacterStringPair(itemSeq: new List<Tuple<string, string>> { new Tuple<string, string>(null, string.Empty) }));
            Assert.Throws<ArgumentException>(() => new CharacterStringPair(itemPairs: new Dictionary<string, string> { { string.Empty, "empty" } }));
        }

        [Fact]
        public void TestToString()
        {
            var dict = new Dictionary<string, string>
            {
                {
                    "ben", "3"
                },
                {
                    "chris", "2"
                },
                {
                    "troy", "4"
                },
                {
                    "freddie", "1"
                }
            };
            var cs2 = new CharacterStringPair(dict);
            Assert.Equal("ben[.]3[,]chris[.]2[,]troy[.]4[,]freddie[.]1", cs2.ToString());
        }

        [Fact]
        public void TestMatchSingle()
        {
            var dict = new Dictionary<string, string>
            {
                {
                    "ben", "3"
                },
                {
                    "chris", "2"
                },
                {
                    "troy", "4"
                },
                {
                    "freddie", "1"
                }
            };
            var cs2 = new CharacterStringPair(dict);
            Assert.Null(cs2.Match("bob"));
            Assert.Null(cs2.Match("a"));
            Assert.Equal("3", cs2.Match("ben"));
        }

        [Fact]
        public void TestMatchMultiple()
        {
            var dict = new Dictionary<string, string>
            {
                {
                    "ben", "3"
                },
                {
                    "chris", "2"
                },
                {
                    "troy", "4"
                },
                {
                    "freddie", "1"
                }
            };

            var cs2 = new CharacterStringPair(dict);

            var responses1 = new Dictionary<string, string>
            {
                {
                    "freddie", "1"
                },
                {
                    "chris", "2"
                },
                {
                    "ben", "3"
                },
                {
                    "troy", "4"
                }
            };

            Assert.True(cs2.Match(responses1));

            var responses2 = new Dictionary<string, string>
            {
                {
                    "freddie", "4"
                },
                {
                    "chris", "3"
                },
                {
                    "ben", "2"
                },
                {
                    "troy", "1"
                }
            };

            Assert.False(cs2.Match(responses2));
        }
    }
}
