// <copyright file="SHA1Hash.Tests.cs" company="">
// Copyright (c) 2018 , All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

using System;
using Xunit;

namespace Float.xAPI.Tests
{
    public class SHA1HashTests : IInitializationTests, IEqualityTests, IToStringTests
    {
        [Fact]
        public void TestValidInit()
        {
            var hash1 = new SHA1Hash("arbitrary data");
            var hash2 = new SHA1Hash(new byte[] { 0x8b, 0xad, 0xf0, 0x0d });
        }

        [Fact]
        public void TestInvalidInit()
        {
            Assert.Throws<ArgumentException>(() => new SHA1Hash(null as string));
            Assert.Throws<ArgumentNullException>(() => new SHA1Hash(null as byte[]));
            Assert.Throws<ArgumentException>(() => new SHA1Hash(String.Empty));
            Assert.Throws<ArgumentException>(() => new SHA1Hash(" "));
            Assert.Throws<ArgumentException>(() => new SHA1Hash(new byte[] { }));
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

        [Fact]
        public void TestInequality()
        {

        }

        [Fact]
        public void TestToString()
        {

        }

        [Fact]
        public void TestEncoding()
        {
            var hash = new SHA1Hash("test");

            Assert.Equal("a94a8fe5ccb19ba61c4c0873d391e987982fbbd3", hash.ToString());
            Assert.Equal(new byte[] { 0xa9, 0x4a, 0x8f, 0xe5, 0xcc, 0xb1, 0x9b, 0xa6, 0x1c, 0x4c, 0x08, 0x73, 0xd3, 0x91, 0xe9, 0x87, 0x98, 0x2f, 0xbb, 0xd3 }, hash.Encoded);
            Assert.Equal(1404839983, hash.GetHashCode());

            var bytes = new byte[] { 0x12, 0x34, 0x56, 0x78, 0x90 };
            var hash2 = new SHA1Hash(bytes);
            Assert.Equal(bytes, hash2.Encoded);
        }
    }
}
