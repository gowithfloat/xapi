// <copyright file="CharacterString.Tests.cs" company="Float">
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
    public class CharacterStringSingleTests : IInitializationTests<CharacterString>, IToStringTests
    {
        [Fact]
        public CharacterString TestValidInit()
        {
            var cs1 = new CharacterString("item");
            var cs2 = new CharacterString(new string[] { "item" });
            var cs3 = new CharacterString("item", LanguageTag.EnglishUS);
            return new CharacterString(new string[] { "item" }, new LanguageTag(Language.Luxembourgish));
        }

        [Fact]
        public void TestInvalidInit()
        {
            Assert.Throws<ArgumentNullException>(() => new CharacterString(item: null));
            Assert.Throws<ArgumentException>(() => new CharacterString(string.Empty));
            Assert.Throws<ArgumentException>(() => new CharacterString(" "));
            Assert.Throws<ArgumentException>(() => new CharacterString(new string[] { }));
            Assert.Throws<ArgumentException>(() => new CharacterString(new List<string> { string.Empty }));
        }

        [Fact]
        public void TestToString()
        {
            var cs1 = new CharacterString("test");
            Assert.Equal("test", cs1.ToString());

            var cs2 = new CharacterString("test2", new LanguageTag(Language.English));
            Assert.Equal("{lang=en}test2", cs2.ToString());

            var cs3 = new CharacterString(new string[] { "test1", "test2" }, LanguageTag.EnglishUS);
            Assert.Equal("{lang=en-US}test1[,]test2", cs3.ToString());

            var cs4 = new CharacterString(new List<string> { "test3", "test4", "test5" });
            Assert.Equal("test3[,]test4[,]test5", cs4.ToString());
        }

        [Fact]
        public void TestProperties()
        {
            var cs1 = new CharacterString("item", new LanguageTag(Language.Luxembourgish));
            Assert.Single(cs1.Items);
            Assert.Equal(new string[] { "item" }, cs1.Items);
            Assert.Equal(new LanguageTag(Language.Luxembourgish), cs1.Language);

            var ics1 = cs1 as ICharacterStringSingle;
            Assert.Equal(new string[] { "item" }, ics1.Items);
            Assert.Equal(new LanguageTag(Language.Luxembourgish), ics1.Language);
        }

        [Fact]
        public void TestExample()
        {
            var cs = new CharacterString(new string[] { "foo", "bar" });
            Assert.Equal("foo[,]bar", cs.ToString());
        }

        [Fact]
        public void TestMatch()
        {
            var cs1 = new CharacterString(new string[] { "foo", "bar" });
            Assert.False(cs1.Match("bar"));
            Assert.False(cs1.Match("foo"));
            Assert.True(cs1.Match(new string[] { "foo", "bar" }));
            Assert.True(cs1.Match(new string[] { "bar", "foo" }));

            var cs2 = new CharacterString("foo");
            var ics2 = cs2 as ICharacterStringMatchString;
            Assert.False(ics2.Match("bar"));

            var cs3 = new CharacterString(new string[] { "bar", "foo" });
            var ics3 = cs3 as ICharacterStringMatchSequence;
            Assert.True(ics3.Match(new string[] { "foo", "bar" }));
        }

        [Fact]
        public void TestInvalidMatch()
        {
            var cs1 = new CharacterString(new string[] { "option b", "all of the above" });
            Assert.Throws<ArgumentNullException>(() => cs1.Match(str: null));
            Assert.Throws<ArgumentException>(() => cs1.Match(str: string.Empty));
            Assert.Throws<ArgumentException>(() => cs1.Match(str: " "));
            Assert.Throws<ArgumentNullException>(() => cs1.Match(strseq: null));
            Assert.Throws<ArgumentException>(() => cs1.Match(strseq: new string[] { }));
            Assert.Throws<ArgumentException>(() => cs1.Match(strseq: new string[] { null }));
            Assert.Throws<ArgumentException>(() => cs1.Match(strseq: new string[] { string.Empty }));
            Assert.Throws<ArgumentException>(() => cs1.Match(strseq: new string[] { " " }));
        }
    }
}
