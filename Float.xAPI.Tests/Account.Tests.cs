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
        public void TestInvalidInit()
        {
            var name = "Example Student";
            var uri = new Uri("https://www.gowithfloat.com");

            Assert.Throws<ArgumentException>(() => new Account(null, null));
            Assert.Throws<ArgumentException>(() => new Account(null, uri));
            Assert.Throws<ArgumentException>(() => new Account(string.Empty, uri));
            Assert.Throws<ArgumentException>(() => new Account(" ", uri));
            Assert.Throws<ArgumentNullException>(() => new Account(name, null));
            Assert.Throws<UriFormatException>(() => new Account(name, new Uri("")));
        }

        [Fact]
        public void TestValidInit()
        {
            var account1 = new Account("unknown", new Uri("http://www.example.com"));
        }

        [Fact]
        public void TestEquality()
        {
            var account1 = new Account("unknown", new Uri("http://www.example.com"));
            var account2 = new Account("known", new Uri("http://www.example.com"));
            Assert.NotEqual(account1, account2);

            var account3 = new Account("other", new Uri("https://www.gowithfloat.com"));
            Assert.NotEqual(account3.GetHashCode(), account1.GetHashCode());
            Assert.NotEqual(account2.ToString(), account3.ToString());
        }
    }
}
