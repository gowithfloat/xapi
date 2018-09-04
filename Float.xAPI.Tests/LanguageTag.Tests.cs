// <copyright file="LanguageTag.Tests.cs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

using System;
using System.Globalization;
using Float.xAPI.Languages;
using Xunit;

namespace Float.xAPI.Tests
{
    public class LanguageTagTests : IInitializationTests<LanguageTag>, IEqualityTests, IToStringTests
    {
        [Fact]
        public LanguageTag TestValidInit()
        {
            var tag1 = new LanguageTag(Language.Abkhazian, Region.Afghanistan);
            var tag2 = new LanguageTag(Language.Samoan, Region.Pitcairn);
            return new LanguageTag(Language.Sindhi, Region.VirginIslandsBritish);
        }

        [Fact]
        public void TestInvalidInit()
        {
            Assert.Throws<ArgumentNullException>(() => new LanguageTag(null, null));
            Assert.Throws<ArgumentNullException>(() => new LanguageTag(Language.Marathi, null));
            Assert.Throws<ArgumentNullException>(() => new LanguageTag(null, Region.Maldives));
        }

        [Fact]
        public void TestEquality()
        {
            var tag1 = new LanguageTag(Language.Wolof, Region.Senegal);
            var tag2 = new LanguageTag(Language.Wolof, Region.Senegal);
            Assert.Equal(tag1, tag2);

            var tag3 = new LanguageTag(Language.English, Region.UnitedStates);
            var tag4 = LanguageTag.EnglishUS;
            Assert.Equal(tag3, tag4);
        }

        [Fact]
        public void TestInequality()
        {
            var tag1 = new LanguageTag(Language.Catalan, Region.Kyrgyzstan);
            var tag2 = new LanguageTag(Language.Catalan, Region.Gibraltar);
            var tag3 = new LanguageTag(Language.Amharic, Region.Kyrgyzstan);
            var tag4 = new LanguageTag(Language.Lao, Region.Latvia);
            Assert.NotEqual(tag1, tag2);
            Assert.NotEqual(tag1, tag3);
            Assert.NotEqual(tag1, tag4);
            Assert.NotEqual(tag2, tag3);
            Assert.NotEqual(tag2, tag4);
            Assert.NotEqual(tag3, tag4);
        }

        [Fact]
        public void TestToString()
        {
            var tag1 = new LanguageTag(Language.German, Region.Germany);
            var tag2 = new LanguageTag(Language.Nepali, Region.Congo);
            var tag3 = new LanguageTag(Language.Sinhala, Region.Brazil);
            var tag4 = new LanguageTag(Language.Norwegian, Region.HongKong);
            Assert.Equal("de-DE", tag1.ToString());
            Assert.Equal("ne-CG", tag2.ToString());
            Assert.Equal("si-BR", tag3.ToString());
            Assert.Equal("no-HK", tag4.ToString());
        }

        [Fact]
        public void TestToCultureInfo()
        {
            var tag1 = new LanguageTag(Language.Malagasy, Region.Chad);
            var tag2 = new LanguageTag(Language.Dutch, Region.Angola);
            Assert.Equal(new CultureInfo("mg-TD"), tag1.ToCultureInfo());
            Assert.Equal(new CultureInfo("nl-AO"), tag2.ToCultureInfo());
        }
    }
}
