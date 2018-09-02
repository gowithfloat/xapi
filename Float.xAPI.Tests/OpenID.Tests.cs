// <copyright file="OpenID.Tests.cs" company="">
// Copyright (c) 2018 , All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

using System;
using Float.xAPI.Actor.Identifier;
using Xunit;

namespace Float.xAPI.Tests
{
    public class OpenIDTests : IInitializationTests, IEqualityTests, IToStringTests
    {
        [Fact]
        public void TestValidInit()
        {
            var openid = new OpenID(new Uri("http://openid.com/jane-schmoe"));
        }

        [Fact]
        public void TestInvalidInit()
        {
            Assert.Throws<ArgumentNullException>(() => new OpenID(null));
            Assert.Throws<ArgumentNullException>(() => new OpenID(new Uri(null)));
            Assert.Throws<UriFormatException>(() => new OpenID(new Uri(string.Empty)));
            Assert.Throws<UriFormatException>(() => new OpenID(new Uri(" ")));
        }

        [Fact]
        public void TestEquality()
        {
            var openid1 = new OpenID(new Uri("http://openid.com/sue-schmoe"));
            var openid3 = new OpenID(new Uri("http://openid.com/sue-schmoe"));
            Assert.Equal(openid1, openid3);
            Assert.Equal(openid1.GetHashCode(), openid3.GetHashCode());
        }

        [Fact]
        public void TestInequality()
        {
            var openid1 = new OpenID(new Uri("http://openid.com/sue-schmoe"));
            var openid2 = new OpenID(new Uri("http://openid.com/jane-schmoe"));
            Assert.NotEqual(openid1, openid2);
            Assert.NotEqual(openid1.GetHashCode(), openid2.GetHashCode());
        }

        [Fact]
        public void TestToString()
        {
            var openid = new OpenID(new Uri("http://openid.com/jane-doe"));
            Assert.Equal("<OpenID: http://openid.com/jane-doe>", openid.ToString());
        }
    }
}
