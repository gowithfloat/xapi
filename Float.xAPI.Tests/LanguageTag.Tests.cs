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
            var tag3 = new LanguageTag(Language.Gikuyu, Region.Jordan, ExtendedLanguage.AdamorobeSignLanguage);
            var tag4 = new LanguageTag(Language.Marathi, Region.Sudan, null);
            return new LanguageTag(Language.Sindhi, Region.VirginIslandsBritish);
        }

        [Fact]
        public void TestInvalidInit()
        {
            Assert.Throws<ArgumentNullException>(() => new LanguageTag(null, null));
            Assert.Throws<ArgumentNullException>(() => new LanguageTag(Language.Marathi, null));
            Assert.Throws<ArgumentNullException>(() => new LanguageTag(null, Region.Maldives));
            Assert.Throws<ArgumentNullException>(() => new LanguageTag(null, null));
            Assert.Throws<ArgumentNullException>(() => new LanguageTag(Language.Romansh, null, ExtendedLanguage.NajdiArabic));
            Assert.Throws<ArgumentNullException>(() => new LanguageTag(null, Region.WallisAndFutuna, ExtendedLanguage.JambiMalay));
        }

        [Fact]
        public void TestEquality()
        {
            var tag1 = new LanguageTag(Language.Wolof, Region.Senegal);
            var tag2 = new LanguageTag(Language.Wolof, Region.Senegal);
            Assert.Equal(tag1, tag2);
            Assert.True(tag1 == tag2);
            Assert.False(tag1 != tag2);
            Assert.True(tag1.Equals(tag2));

            var itag1 = tag1 as ILanguageTag;
            var itag2 = tag2 as ILanguageTag;
            Assert.Equal(itag1, itag2);
            Assert.True(tag1.Equals(itag2));
            Assert.True(tag1.Equals(tag2));
            Assert.True(itag1.Equals(itag2));
            Assert.True(itag1.Equals(tag2));
            Assert.True(itag2.Equals(itag1));
            Assert.True(itag2.Equals(tag1));

            var tag3 = new LanguageTag(Language.English, Region.UnitedStates);
            var tag4 = LanguageTag.EnglishUS;
            Assert.Equal(tag3, tag4);
            Assert.True(tag3 == tag4);
            Assert.False(tag3 != tag4);

            var tag5 = new LanguageTag(Language.Nyanja, Region.Niue, ExtendedLanguage.NicaraguanSignLanguage);
            var tag6 = new LanguageTag(Language.Nyanja, Region.Niue, ExtendedLanguage.NicaraguanSignLanguage);
            Assert.Equal(tag5, tag6);
            Assert.False(tag5 != tag6);
        }

        [Fact]
        public void TestInequality()
        {
            var tag1 = new LanguageTag(Language.Catalan, Region.Kyrgyzstan);
            var tag2 = new LanguageTag(Language.Catalan, Region.Gibraltar);
            var tag3 = new LanguageTag(Language.Amharic, Region.Kyrgyzstan);
            var tag4 = new LanguageTag(Language.Lao, Region.Latvia);
            var tag5 = new LanguageTag(Language.Ido, Region.Gabon, ExtendedLanguage.Musi);
            var tag6 = new LanguageTag(Language.Ido, Region.Gabon);
            Assert.NotEqual(tag1, tag2);
            Assert.NotEqual(tag1, tag3);
            Assert.NotEqual(tag1, tag4);
            Assert.NotEqual(tag2, tag3);
            Assert.NotEqual(tag2, tag4);
            Assert.NotEqual(tag3, tag4);
            Assert.NotEqual(tag5, tag6);
            Assert.False(tag1 == tag2);
            Assert.False(tag1 == tag3);
            Assert.True(tag1 != tag4);
            Assert.False(tag1.Equals(tag2));

            var itag1 = tag1 as ILanguageTag;
            var itag2 = tag2 as ILanguageTag;
            Assert.NotEqual(itag1, itag2);
            Assert.False(tag1.Equals(itag2));
            Assert.False(tag1.Equals(tag2));
            Assert.False(itag1.Equals(itag2));
            Assert.False(itag1.Equals(tag2));
            Assert.False(itag2.Equals(itag1));
            Assert.False(itag2.Equals(tag1));
        }

        [Fact]
        public void TestToString()
        {
            var tag1 = new LanguageTag(Language.German, Region.Germany);
            var tag2 = new LanguageTag(Language.Nepali, Region.Congo);
            var tag3 = new LanguageTag(Language.Sinhala, Region.Brazil);
            var tag4 = new LanguageTag(Language.Norwegian, Region.HongKong);
            var tag5 = new LanguageTag(Language.Italian, Region.Italy, ExtendedLanguage.ItalianSignLanguage);
            Assert.Equal("de-DE", tag1.ToString());
            Assert.Equal("ne-CG", tag2.ToString());
            Assert.Equal("si-BR", tag3.ToString());
            Assert.Equal("no-HK", tag4.ToString());
            Assert.Equal("it-ise-IT", tag5.ToString());
        }

        [Fact]
        public void TestToCultureInfo()
        {
            var tag1 = new LanguageTag(Language.Malagasy, Region.Chad);
            var tag2 = new LanguageTag(Language.Dutch, Region.Angola);
            var tag3 = new LanguageTag(Language.Korean, Region.RepublicOfKorea, ExtendedLanguage.KoreanSignLanguage);
            var tag4 = new LanguageTag(Language.Chinese, Region.China, ExtendedLanguage.YueChinese);
            var tag5 = new LanguageTag(Language.Chinese, Region.China, ExtendedLanguage.GanChinese);
            var tag6 = new LanguageTag(Language.Chinese, Region.China, ExtendedLanguage.MandarinChinese);
            Assert.Equal(new CultureInfo("mg-TD"), tag1.ToCultureInfo());
            Assert.Equal(new CultureInfo("nl-AO"), tag2.ToCultureInfo());
            Assert.Equal(new CultureInfo("ko-kvk-KR"), tag3.ToCultureInfo());
            Assert.Equal(new CultureInfo("zh-yue-CN"), tag4.ToCultureInfo());
            Assert.Equal(new CultureInfo("zh-gan-CN"), tag5.ToCultureInfo());
            Assert.Equal(new CultureInfo("zh-cmn-CN"), tag6.ToCultureInfo());

            var itag1 = tag1 as ILanguageTag;
            var itag2 = tag2 as ILanguageTag;
            Assert.Equal(new CultureInfo("mg-TD"), itag1.ToCultureInfo());
            Assert.Equal(new CultureInfo("nl-AO"), itag2.ToCultureInfo());
        }

        [Fact]
        public void TestExtendedLanguage()
        {
            var tag1 = new LanguageTag(Language.Flemish, Region.Niue, ExtendedLanguage.OmaniArabic);
            var tag2 = new LanguageTag(Language.Flemish, Region.Niue, ExtendedLanguage.OmaniArabic);
            Assert.Equal(ExtendedLanguage.OmaniArabic, tag1.ExtendedLanguage);

            var itag1 = tag1 as ILanguageTag;
            Assert.Equal(ExtendedLanguage.OmaniArabic, itag1.ExtendedLanguage);
        }
    }
}
