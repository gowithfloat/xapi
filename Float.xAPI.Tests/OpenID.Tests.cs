// <copyright file="OpenID.Tests.cs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

using System;
using Float.xAPI.Actors.Identifier;
using Xunit;

namespace Float.xAPI.Tests
{
    public class OpenIDTests : IInitializationTests<OpenID>, IEqualityTests, IPropertyTests
    {
        [Fact]
        public OpenID TestValidInit()
        {
            return new OpenID(new Uri("http://openid.com/jane-schmoe"));
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
            AssertHelper.Equality<OpenID, IOpenID, IInverseFunctionalIdentifier>(openid1, openid3, (a, b) => a == b);
        }

        [Fact]
        public void TestInequality()
        {
            var openid1 = new OpenID(new Uri("http://openid.com/sue-schmoe"));
            var openid2 = new OpenID(new Uri("http://openid.com/jane-schmoe"));
            AssertHelper.Inequality<OpenID, IOpenID, IInverseFunctionalIdentifier>(openid1, openid2, (a, b) => a != b);
        }

        [Fact]
        public void TestProperties()
        {
            var openid = new OpenID(new Uri("http://openid.com/jane-schmoe"));
            Assert.Equal("http://openid.com/jane-schmoe", openid.OpenID.AbsoluteUri);
            Assert.Equal(new Uri("http://openid.com/jane-schmoe"), (openid as IOpenID).OpenID);
        }
    }
}
