// <copyright file="Region.Tests.cs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

using Float.xAPI.Languages;
using Xunit;

namespace Float.xAPI.Tests
{
    public class RegionTests : IInitializationTests<Region>, IEqualityTests, IToStringTests
    {
        [Fact]
        public Region TestValidInit()
        {
            var language1 = Region.CôtedIvoire;
            var language2 = Region.FromString("IM");
            return Region.Sudan;
        }

        [Fact]
        public void TestInvalidInit()
        {
            Assert.Null(Region.FromString("aaa"));
            Assert.Null(Region.FromString(null));
            Assert.Null(Region.FromString(string.Empty));
        }

        [Fact]
        public void TestEquality()
        {
            var lang1 = Region.Kiribati;
            var lang2 = Region.Kiribati;
            Assert.True(lang1 == lang2);
            Assert.False(lang1 != lang2);
            Assert.True(lang1.Equals(lang2));
        }

        [Fact]
        public void TestInequality()
        {
            var lang1 = Region.SouthAfrica;
            var lang2 = Region.Vanuatu;
            Assert.False(lang1 == lang2);
            Assert.True(lang1 != lang2);
            Assert.False(lang1.Equals(lang2));
        }

        [Fact]
        public void TestToString()
        {
            Assert.Equal("LT", Region.Lithuania.ToString());
            Assert.Equal("TZ", Region.Tanzania.ToString());
        }

        [Fact]
        public void TestFromString()
        {
            Assert.Equal(Region.Myanmar, Region.FromString("MM"));
            Assert.Equal(Region.Mayotte, Region.FromString("YT"));
        }
    }
}
