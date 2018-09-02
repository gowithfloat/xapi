// <copyright file="Account.Tests.cs" company="Float">
// Copyright (c) 2018 Float, LLC, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

using System;
using Float.xAPI.Actor.Identifier;
using Xunit;

namespace Float.xAPI.Tests
{
    public class AccountTests : IInitializationTests, IEqualityTests, IToStringTests
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
            var account2 = new Account("unknown", new Uri("http://www.example.com"));
            Assert.Equal(account1, account2);
            Assert.Equal(account1.GetHashCode(), account2.GetHashCode());
        }

        [Fact]
        public void TestInequality()
        {
            var account1 = new Account("unknown", new Uri("http://www.example.com"));
            var account2 = new Account("known", new Uri("http://www.example.com"));
            Assert.NotEqual(account1, account2);
            Assert.NotEqual(account1.GetHashCode(), account2.GetHashCode());
        }

        [Fact]
        public void TestToString()
        {
            var account1 = new Account("Example Learner", new Uri("https://www.gowithfloat.com"));
            Assert.Equal("<Account: Name \"Example Learner\" HomePage https://www.gowithfloat.com/>", account1.ToString());
        }
    }
}
