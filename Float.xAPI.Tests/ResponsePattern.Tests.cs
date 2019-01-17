// <copyright file="ResponsePattern.Tests.cs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using Float.xAPI.Activities.Definitions;
using Float.xAPI.Languages;
using Xunit;

namespace Float.xAPI.Tests
{
    public class ResponsePatternTests : IInitializationTests<ResponsePattern>, IToStringTests, IPropertyTests
    {
        [Fact]
        public ResponsePattern TestValidInit()
        {
            var rp1 = new ResponsePattern(true);
            var rp2 = new ResponsePattern("item");
            var rp3 = new ResponsePattern(new CharacterString("item"));
            var rp4 = new ResponsePattern(new ICharacterString[] { new CharacterString("item") });
            var rp5 = new ResponsePattern("item", false);
            var rp6 = new ResponsePattern(new CharacterString("item"), true);
            var rp7 = new ResponsePattern(new ICharacterString[] { new CharacterString("item") }, false);
            var rp8 = new ResponsePattern("item", false, true);
            var rp9 = new ResponsePattern(new CharacterString("item"), true, false);
            return new ResponsePattern(new ICharacterString[] { new CharacterString("item") }, false, false);
        }

        [Fact]
        public void TestInvalidInit()
        {
            Assert.Throws<ArgumentNullException>(() => new ResponsePattern(item: null));
            Assert.Throws<ArgumentException>(() => new ResponsePattern(item: string.Empty));
            Assert.Throws<ArgumentException>(() => new ResponsePattern(item: " "));
            Assert.Throws<ArgumentNullException>(() => new ResponsePattern(characterString: null));
            Assert.Throws<ArgumentNullException>(() => new ResponsePattern(characterStrings: null));
            Assert.Throws<ArgumentException>(() => new ResponsePattern(characterStrings: new ICharacterString[] { }));
        }

        [Fact]
        public void TestToString()
        {
            var rp1 = new ResponsePattern(true);
            Assert.Equal("[\"{case_matters=false}true\"]", rp1.ToString());

            var rp2 = new ResponsePattern("example");
            Assert.Equal("[\"example\"]", rp2.ToString());

            var rp3 = new ResponsePattern(new CharacterString("test"));
            Assert.Equal("[\"test\"]", rp3.ToString());

            var rp4 = new ResponsePattern(new ICharacterString[] { new CharacterString("xapi") });
            Assert.Equal("[\"xapi\"]", rp4.ToString());

            var rp5 = new ResponsePattern("one", false);
            Assert.Equal("[\"{case_matters=false}one\"]", rp5.ToString());

            var rp6 = new ResponsePattern(new CharacterString("two"), true);
            Assert.Equal("[\"{case_matters=true}two\"]", rp6.ToString());

            var rp7 = new ResponsePattern(new ICharacterString[] { new CharacterString("three") }, false);
            Assert.Equal("[\"{case_matters=false}three\"]", rp7.ToString());

            var rp8 = new ResponsePattern("item", false, true);
            Assert.Equal("[\"{case_matters=false}three\"]", rp7.ToString());

            var rp9 = new ResponsePattern(new CharacterString("item"), true, false);
            var rp0 = new ResponsePattern(new ICharacterString[] { new CharacterString("item") }, false, false);
        }

        [Fact]
        public void TestExample()
        {
            var css = new List<ICharacterString>
            {
                new CharacterString("foo"),
                new CharacterString(new string[] { "foo", "bar" })
            };

            var rp1 = new ResponsePattern(css);

            // todo: the actual example has these reversed; is order important?
            // Assert.Equal("[\"foo[,]bar\",\"foo\"]", rp1.ToString());
            Assert.Equal("[\"foo\", \"foo[,]bar\"]", rp1.ToString());

            var rp2 = new ResponsePattern(new CharacterString("To store and provide access to learning experiences.", new LanguageTag(Language.English)), false);
            Assert.Equal("[\"{case_matters=false}{lang=en}To store and provide access to learning experiences.\"]", rp2.ToString());
        }

        [Fact]
        public void TestMatch()
        {
            var css = new List<ICharacterString>
            {
                new CharacterString("foo"),
                new CharacterString(new string[] { "foo", "bar" })
            };

            var rp1 = new ResponsePattern(css);
            Assert.True(rp1.Match("foo"));
            Assert.True(rp1.Match(new string[] { "foo", "bar" }));
            Assert.False(rp1.Match("bar"));

            var css2 = new List<ICharacterString>
            {
                new CharacterStringNumeric(min: 0, max: 10),
                new CharacterStringPair(new Dictionary<string, ICharacterString> { { "foo", new CharacterString("bar") } })
            };

            var rp2 = new ResponsePattern(css2);
            Assert.False(rp2.Match("foo"));
            Assert.True(rp2.MatchNumeric(5));
            Assert.False(rp2.MatchNumeric(15));
            Assert.Equal(new ICharacterString[] { new CharacterString("bar") }, rp2.MatchResponse("foo"));

            var irp1 = rp1 as IResponsePattern;
            Assert.True(irp1.Match("foo"));
            Assert.True(irp1.Match(new string[] { "foo", "bar" }));
            Assert.False(irp1.Match("bar"));
        }

        [Fact]
        public void TestInvalidMatch()
        {
            var rp1 = new ResponsePattern(new CharacterString(new string[] { "option b", "all of the above" }));
            Assert.Throws<ArgumentNullException>(() => rp1.Match(str: null));
            Assert.Throws<ArgumentException>(() => rp1.Match(str: string.Empty));
            Assert.Throws<ArgumentException>(() => rp1.Match(str: " "));
            Assert.Throws<ArgumentNullException>(() => rp1.Match(strseq: null));
            Assert.Throws<ArgumentException>(() => rp1.Match(strseq: new string[] { }));
            Assert.Throws<ArgumentException>(() => rp1.Match(strseq: new string[] { null }));
            Assert.Throws<ArgumentException>(() => rp1.Match(strseq: new string[] { string.Empty }));
            Assert.Throws<ArgumentException>(() => rp1.Match(strseq: new string[] { " " }));
        }

        [Fact]
        public void TestProperties()
        {
            var rp1 = new ResponsePattern("1", true, false);
            Assert.True(rp1.CaseMatters.Value);
            Assert.False(rp1.OrderMatters.Value);
            Assert.Equal(new CharacterString("1"), rp1.CharacterStrings.First());

            var irp1 = rp1 as IResponsePattern;
            Assert.True(irp1.CaseMatters.Value);
            Assert.False(irp1.OrderMatters.Value);
            Assert.Equal(new CharacterString("1"), irp1.CharacterStrings.First());
        }
    }
}
