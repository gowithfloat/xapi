// <copyright file="Version.Tests.cs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

using System;
using Xunit;

namespace Float.xAPI.Tests
{
    public class VersionTests : IInitializationTests<Version>, IEqualityTests, IToStringTests, IComparisonTests
    {
        [Fact]
        public Version TestValidInit()
        {
            return new Version(1, 0, 0);
        }

        [Fact]
        public void TestInvalidInit()
        {
            // not possible
        }

        [Fact]
        public void TestToString()
        {
            var version1 = new Version(0, 0, 0);
            Assert.Equal("0.0.0", version1.ToString());

            var version2 = new Version(23, 232, 12);
            Assert.Equal("23.232.12", version2.ToString());
        }

        [Fact]
        public void TestEquality()
        {
            var version1 = new Version(1, 2, 3);
            var version2 = new Version(1, 2, 3);
            Assert.Equal(version1, version2);
            Assert.Equal(version1.GetHashCode(), version2.GetHashCode());
            Assert.True(version1 == version2);
            Assert.False(version1 != version2);

            var version1eq = version1 as IEquatable<IVersion>;
            var version2eq = version2 as IEquatable<IVersion>;
            Assert.True(version1eq.Equals(version2eq));
        }

        [Fact]
        public void TestInequality()
        {
            var version2 = new Version(1, 2, 3);
            var version3 = new Version(33, 22, 11);
            Assert.NotEqual(version2, version3);
            Assert.NotEqual(version2.GetHashCode(), version3.GetHashCode());
            Assert.False(version2 == version3);
            Assert.True(version2 != version3);

            var version2eq = version2 as IEquatable<IVersion>;
            var version3eq = version3 as IEquatable<IVersion>;
            Assert.False(version2eq.Equals(version3eq));

            var version4 = new Version(1, 1, 0);
            Assert.NotEqual(version3, version4);
            var version5 = new Version(1, 0, 12);
            Assert.NotEqual(version4, version5);
        }

        [Fact]
        public void TestComparison()
        {
            var version1 = new Version(1, 0, 0);
            var version2 = new Version(2, 0, 0);
            Assert.True(version1 < version2);
            Assert.False(version1 > version2);

            var version3 = new Version(1, 3, 0);
            var version4 = new Version(1, 5, 0);
            Assert.True(version3 < version4);
            Assert.False(version3 > version4);

            var version5 = new Version(2, 6, 4);
            var version6 = new Version(2, 6, 6);
            Assert.True(version5 < version6);
            Assert.False(version5 > version6);
        }
    }
}
