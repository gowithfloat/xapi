// <copyright file="CharacterStringNumeric.Tests.cs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

using System;
using Float.xAPI.Activities.Definitions;
using Xunit;

namespace Float.xAPI.Tests
{
    public class CharacterStringNumericTests : IInitializationTests<CharacterStringNumeric>, IToStringTests
    {
        [Fact]
        public CharacterStringNumeric TestValidInit()
        {
            var cs1 = new CharacterStringNumeric(min: 2);
            var cs2 = new CharacterStringNumeric(max: 5);
            return new CharacterStringNumeric(5, 55);
        }

        [Fact]
        public void TestInvalidInit()
        {
            // todo: properly handle the case where no max or min value is provided (this doesn't work as it defaults to the parameterless struct initializer)
            // Assert.Throws<ArgumentException>(() => new CharacterStringNumeric());
            Assert.Throws<ArgumentException>(() => new CharacterStringNumeric(15, 5));
        }

        [Fact]
        public void TestToString()
        {
            var cs3 = new CharacterStringNumeric(max: 4);
            Assert.Equal("[:]4", cs3.ToString());

            var cs4 = new CharacterStringNumeric(min: 4);
            Assert.Equal("4[:]", cs4.ToString());

            var cs5 = new CharacterStringNumeric(min: 1, max: 10);
            Assert.Equal("1[:]10", cs5.ToString());
        }

        [Fact]
        public void TestProperties()
        {
            var cs6 = new CharacterStringNumeric(11, 43);
            Assert.Equal(11, cs6.Min);
            Assert.Equal(43, cs6.Max);
        }

        [Fact]
        public void TestMatch()
        {
            var cs2 = new CharacterStringNumeric(17, 41);
            Assert.False(cs2.Match(3));
            Assert.True(cs2.Match(18));
            Assert.True(cs2.Match(40));
            Assert.False(cs2.Match(43));
        }
    }
}
