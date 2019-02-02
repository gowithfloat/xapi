// <copyright file="SHAHash.Tests.cs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

using System;
using System.Security.Cryptography;
using Xunit;

namespace Float.xAPI.Tests
{
    public class SHAHashTests : IInitializationTests<SHAHash>, IEqualityTests, IToStringTests, IPropertyTests
    {
        [Fact]
        public SHAHash TestValidInit()
        {
            var hash1 = new SHAHash("arbitrary data");
            var hash2 = new SHAHash("example data", SHA256.Create());
            return new SHAHash(new byte[] { 0x8b, 0xad, 0xf0, 0x0d });
        }

        [Fact]
        public void TestInvalidInit()
        {
            Assert.Throws<ArgumentException>(() => new SHAHash(null as string));
            Assert.Throws<ArgumentNullException>(() => new SHAHash(null as byte[]));
            Assert.Throws<ArgumentException>(() => new SHAHash(string.Empty));
            Assert.Throws<ArgumentException>(() => new SHAHash(" "));
            Assert.Throws<ArgumentException>(() => new SHAHash(Array.Empty<byte>()));
        }

        [Fact]
        public void TestEquality()
        {
            var hash1 = new SHAHash("verb");
            var hash3 = new SHAHash("verb");
            Assert.Equal(hash1, hash3);
            Assert.True(hash1 == hash3);
            Assert.Equal(hash1.GetHashCode(), hash3.GetHashCode());
        }

        [Fact]
        public void TestInequality()
        {
            var hash1 = new SHAHash("verb");
            var hash2 = new SHAHash("statement");
            Assert.NotEqual(hash1, hash2);
            Assert.True(hash1 != hash2);
            Assert.NotEqual(hash1.GetHashCode(), hash2.GetHashCode());
        }

        [Fact]
        public void TestToString()
        {
            var hash = new SHAHash("verb");
            Assert.Equal("aca6ddc032a17d3f70acf3e02835f5a02faf8de4", hash.ToString());
        }

        [Fact]
        public void TestEncoding()
        {
            var hash = new SHAHash("test");

            Assert.Equal("a94a8fe5ccb19ba61c4c0873d391e987982fbbd3", hash.ToString());
            Assert.Equal(new byte[] { 0xa9, 0x4a, 0x8f, 0xe5, 0xcc, 0xb1, 0x9b, 0xa6, 0x1c, 0x4c, 0x08, 0x73, 0xd3, 0x91, 0xe9, 0x87, 0x98, 0x2f, 0xbb, 0xd3 }, hash.Encoded);

            var bytes = new byte[] { 0x12, 0x34, 0x56, 0x78, 0x90 };
            var hash2 = new SHAHash(bytes);
            Assert.Equal(bytes, hash2.Encoded);
        }

        [Fact]
        public void TestProperties()
        {
            var hash = new SHAHash("test");
            Assert.Equal(new byte[] { 0xa9, 0x4a, 0x8f, 0xe5, 0xcc, 0xb1, 0x9b, 0xa6, 0x1c, 0x4c, 0x08, 0x73, 0xd3, 0x91, 0xe9, 0x87, 0x98, 0x2f, 0xbb, 0xd3 }, hash.Encoded);

            var ihash = hash as ISHAHash;
            Assert.Equal(new byte[] { 0xa9, 0x4a, 0x8f, 0xe5, 0xcc, 0xb1, 0x9b, 0xa6, 0x1c, 0x4c, 0x08, 0x73, 0xd3, 0x91, 0xe9, 0x87, 0x98, 0x2f, 0xbb, 0xd3 }, ihash.Encoded);
        }
    }
}
