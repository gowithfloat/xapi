// <copyright file="Language.Tests.cs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

using Float.xAPI.Languages;
using Xunit;

namespace Float.xAPI.Tests
{
    public class LanguageTests : IInitializationTests<Language>, IEqualityTests, IToStringTests
    {
        [Fact]
        public Language TestValidInit()
        {
            var language1 = Language.BokmålNorwegian;
            var language2 = Language.FromString("ti");
            return Language.Tonga;
        }

        [Fact]
        public void TestInvalidInit()
        {
            Assert.Null(Language.FromString("qqqq"));
            Assert.Null(Language.FromString(null));
            Assert.Null(Language.FromString(string.Empty));
        }

        [Fact]
        public void TestEquality()
        {
            var lang1 = Language.Quechua;
            var lang2 = Language.Quechua;
            Assert.True(lang1 == lang2);
            Assert.False(lang1 != lang2);
            Assert.True(lang1.Equals(lang2));
        }

        [Fact]
        public void TestInequality()
        {
            var lang1 = Language.Walloon;
            var lang2 = Language.Turkmen;
            Assert.False(lang1 == lang2);
            Assert.True(lang1 != lang2);
            Assert.False(lang1.Equals(lang2));
        }

        [Fact]
        public void TestToString()
        {
            Assert.Equal("uk", Language.Ukrainian.ToString());
            Assert.Equal("la", Language.Latin.ToString());
        }

        [Fact]
        public void TestFromString()
        {
            Assert.Equal(Language.Cornish, Language.FromString("kw"));
            Assert.Equal(Language.Interlingua, Language.FromString("ia"));
        }
    }
}
