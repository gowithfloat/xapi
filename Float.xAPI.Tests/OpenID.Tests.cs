// <copyright file="OpenID.Tests.cs" company="">
// Copyright (c) 2018 , All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

using System;
using Float.xAPI.Actor.Identifier;
using Xunit;

namespace Float.xAPI.Tests
{
    public abstract class OpenIDTests
    {
        [Fact]
        public void TestInvalidInit()
        {
            Assert.Throws<ArgumentException>(() => new OpenID(null));
            Assert.Throws<ArgumentException>(() => new OpenID(new Uri(null)));
            Assert.Throws<ArgumentException>(() => new OpenID(new Uri(string.Empty)));
            Assert.Throws<ArgumentException>(() => new OpenID(new Uri(" ")));
        }

        [Fact]
        public void TestValidInit()
        {
            var openid = new OpenID(new Uri("http://openid.com/jane-schmoe"));
        }

        [Fact]
        public void TestToString()
        {
            var openid = new OpenID(new Uri("http://openid.com/jane-doe"));
            Assert.Equal("<OpenID: http://openid.com/jane-doe>", openid.ToString());
        }

        [Fact]
        public void TestEquality()
        {
            var openid1 = new OpenID(new Uri("http://openid.com/sue-schmoe"));
            var openid2 = new OpenID(new Uri("http://openid.com/jane-schmoe"));
            Assert.NotEqual(openid1, openid2);

            var openid3 = new OpenID(new Uri("http://openid.com/sue-schmoe"));
            Assert.Equal(openid1, openid3);
        }
    }
}
