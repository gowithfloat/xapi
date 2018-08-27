// <copyright file="SHA1Hash.Tests.cs" company="">
// Copyright (c) 2018 , All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

using System;
using Float.xAPI;
using Xunit;

namespace Float.xAPI.Tests
{
    public class SHA1HashTests
    {
        [Fact]
        public void TestInit()
        {
            Assert.Throws<ArgumentException>(() => new SHA1Hash(null));
            Assert.Throws<ArgumentException>(() => new SHA1Hash(String.Empty));
            Assert.Throws<ArgumentException>(() => new SHA1Hash(" "));

            var hash = new SHA1Hash("test");
        }

        [Fact]
        public void TestEncoding()
        {
            var hash = new SHA1Hash("test");

            // todo: get values verified elsewhere
            Assert.Equal("a94a8fe5ccb19ba61c4c0873d391e987982fbbd3", hash.ToString());
            Assert.Equal(new byte[] { 0xa9, 0x4a, 0x8f, 0xe5, 0xcc, 0xb1, 0x9b, 0xa6, 0x1c, 0x4c, 0x08, 0x73, 0xd3, 0x91, 0xe9, 0x87, 0x98, 0x2f, 0xbb, 0xd3 }, hash.Encoded);
            Assert.Equal(1404839983, hash.GetHashCode());
        }

        [Fact]
        public void TestEquality()
        {
            var hash1 = new SHA1Hash("verb");
            var hash2 = new SHA1Hash("statement");
            Assert.NotEqual(hash1, hash2);

            var hash3 = new SHA1Hash("verb");
            Assert.Equal(hash1, hash3);
        }
    }
}
