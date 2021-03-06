﻿// <copyright file="Account.Tests.cs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

using System;
using Float.xAPI.Actors.Identifier;
using FsCheck;
using FsCheck.Xunit;
using Xunit;

namespace Float.xAPI.Tests
{
    public class AccountTests : IInitializationTests<Account>, IEqualityTests, IPropertyTests
    {
        public AccountTests()
        {
            Arb.Register<Generators>();
        }

        [Fact]
        public Account TestValidInit()
        {
            return new Account("unknown", new Uri("http://www.example.com"));
        }

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
            Assert.Throws<UriFormatException>(() => new Account(name, new Uri(string.Empty)));
        }

        [Fact]
        public void TestEquality()
        {
            var account1 = new Account("unknown", new Uri("http://www.example.com/unknown"));
            var account2 = new Account("unknown", new Uri("http://www.example.com/unknown"));
            AssertHelper.Equality<Account, IAccount, IInverseFunctionalIdentifier>(account1, account2, (a, b) => a == b);
        }

        [Property]
        public void TestGeneratedEquality(NonWhiteSpaceString name, Uri uri)
        {
            var account1 = new Account(name.Item, uri);
            var account2 = new Account(name.Item, uri);
            AssertHelper.Equality<Account, IAccount, IInverseFunctionalIdentifier>(account1, account2, (a, b) => a == b);
        }

        [Fact]
        public void TestInequality()
        {
            var account1 = new Account("unknown", new Uri("http://www.example.com/unknown"));
            var account2 = new Account("known", new Uri("http://www.example.com/known"));
            AssertHelper.Inequality<Account, IAccount, IInverseFunctionalIdentifier>(account1, account2, (a, b) => a != b);
            Assert.NotEqual(account1.Name, account2.Name);
            Assert.NotEqual(account1.HomePage, account2.HomePage);
        }

        [Fact]
        public void TestProperties()
        {
            var account = new Account("Example Student", new Uri("http://example.com/example/student"));
            Assert.Equal("Example Student", account.Name);
            Assert.Equal(new Uri("http://example.com/example/student"), account.HomePage);
        }

        [Property]
        public bool TestGeneratedProperties(NonWhiteSpaceString name, Uri uri)
        {
            var account = new Account(name.Item, uri);
            return account.Name == name.Item && account.HomePage.AbsoluteUri == uri.AbsoluteUri;
        }
    }
}
