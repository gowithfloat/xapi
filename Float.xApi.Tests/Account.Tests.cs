// <copyright file="Account.Tests.cs" company="Float">
// Copyright (c) 2018 Float, LLC, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

using System;
using Float.xAPI.Actor.Identifier;
using Xunit;

namespace Float.xAPI.Tests
{
    public class AccountTests
    {
        [Fact]
        public void TestExample()
        {
            var account = new Account("1625378", new Uri("http://www.example.com"));
            Assert.Equal("1625378", account.Name);
            Assert.Equal(new Uri("http://www.example.com"), account.HomePage);

            var account2 = new Account("1625378", new Uri("http://www.example.com"));
            Assert.Equal(account2.ToString(), account.ToString());
            Assert.True(account2.Equals(account));
            Assert.False(account.Equals(new object()));
            Assert.Equal(account2.GetHashCode(), account.GetHashCode());

            var account3 = new Account("other", new Uri("https://www.gowithfloat.com"));
            Assert.NotEqual(account3.GetHashCode(), account.GetHashCode());
            Assert.NotEqual(account2.ToString(), account3.ToString());
        }
    }
}
