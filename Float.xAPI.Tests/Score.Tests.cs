// <copyright file="Score.Tests.cs" company="">
// Copyright (c) 2018 , All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

using System;
using Xunit;

namespace Float.xAPI.Tests
{
    public class ScoreTests : IInitializationTests<Score>, IEqualityTests, IComparisonTests, IToStringTests
    {
        [Fact]
        public Score TestValidInit()
        {
            var score1 = new Score(0.5);
            var score2 = new Score(67, 0, 100);
            return score2;
        }

        [Fact]
        public void TestInvalidInit()
        {
            Assert.Throws<ArgumentException>(() => new Score(-3));
            Assert.Throws<ArgumentException>(() => new Score(-1, 0, 10));
            Assert.Throws<ArgumentException>(() => new Score(0, -1.2345, 10));
            Assert.Throws<ArgumentException>(() => new Score(0, 0, -1));
            Assert.Throws<ArgumentException>(() => new Score(100, 0, 10));
            Assert.Throws<ArgumentException>(() => new Score(2, 5, 10));
        }

        [Fact]
        public void TestEquality()
        {
            var score1 = new Score(0.5);
            var score2 = new Score(50, 0, 100);
            Assert.Equal(score1, score2);
            Assert.True(score1 == score2);
        }

        [Fact]
        public void TestInequality()
        {
            var score1 = new Score(0.4);
            var score2 = new Score(4, 1, 10);
            Assert.NotEqual(score1, score2);
            Assert.True(score1 != score2);
        }

        [Fact]
        public void TestComparison()
        {
            var score1 = new Score(0.1);
            var score2 = new Score(0.2);
            Assert.True(score1 < score2);
            Assert.False(score1 > score2);

            var score3 = new Score(3, 0, 10);
            Assert.True(score2 < score3);
            Assert.False(score2 > score3);
        }

        [Fact]
        public void TestToString()
        {
            var score1 = new Score(0.95);
            Assert.Equal("<Score: Scaled 0.95>", score1.ToString());

            var score2 = new Score(95, 0, 100);
            Assert.Equal("<Score: Scaled 0.95 Raw 95.0 Min 0 Max 100>", score2.ToString());
        }
    }
}
