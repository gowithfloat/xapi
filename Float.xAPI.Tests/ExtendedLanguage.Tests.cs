// <copyright file="ExtendedLanguage.Tests.cs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

using Float.xAPI.Languages;
using Xunit;

namespace Float.xAPI.Tests
{
    public class ExtendedLanguageTests : IInitializationTests<ExtendedLanguage>, IEqualityTests, IToStringTests
    {
        [Fact]
        public ExtendedLanguage TestValidInit()
        {
            var language1 = ExtendedLanguage.CzechSignLanguage;
            var language2 = ExtendedLanguage.FromString("csh");
            return ExtendedLanguage.MoroccanArabic;
        }

        [Fact]
        public void TestInvalidInit()
        {
            Assert.Null(ExtendedLanguage.FromString("zzz"));
            Assert.Null(ExtendedLanguage.FromString(null));
            Assert.Null(ExtendedLanguage.FromString(string.Empty));
        }

        [Fact]
        public void TestEquality()
        {
            var lang1 = ExtendedLanguage.Kubu;
            var lang2 = ExtendedLanguage.Kubu;
            Assert.True(lang1 == lang2);
            Assert.False(lang1 != lang2);
            Assert.True(lang1.Equals(lang2));
        }

        [Fact]
        public void TestInequality()
        {
            var lang1 = ExtendedLanguage.Col;
            var lang2 = ExtendedLanguage.SabahMalay;
            Assert.False(lang1 == lang2);
            Assert.True(lang1 != lang2);
            Assert.False(lang1.Equals(lang2));
        }

        [Fact]
        public void TestToString()
        {
            Assert.Equal("zmi", ExtendedLanguage.NegeriSembilanMalay.ToString());
            Assert.Equal("tmw", ExtendedLanguage.Temuan.ToString());
        }

        [Fact]
        public void TestFromString()
        {
            Assert.Equal(ExtendedLanguage.ManadoMalay, ExtendedLanguage.FromString("xmm"));
            Assert.Equal(ExtendedLanguage.PortugueseSignLanguage, ExtendedLanguage.FromString("psr"));
        }
    }
}
