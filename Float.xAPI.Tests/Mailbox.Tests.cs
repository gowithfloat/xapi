// <copyright file="Mailbox.Tests.cs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

using System;
using System.Net.Mail;
using Float.xAPI.Actor.Identifier;
using Xunit;

namespace Float.xAPI.Tests
{
    public class MailboxTests : IInitializationTests<Mailbox>, IEqualityTests, IToStringTests
    {
        [Fact]
        public Mailbox TestValidInit()
        {
            return new Mailbox(new Uri("mailto:valid@example.com"));
        }

        [Fact]
        public void TestInvalidInit()
        {
            Assert.Throws<ArgumentNullException>(() => new Mailbox(null));
            Assert.Throws<ArgumentNullException>(() => new Mailbox(new Uri(null)));
            Assert.Throws<UriFormatException>(() => new Mailbox(new Uri(string.Empty)));
            Assert.Throws<UriFormatException>(() => new Mailbox(new Uri(" ")));
            Assert.Throws<UriFormatException>(() => new Mailbox(new Uri("invalid")));
            Assert.Throws<UriFormatException>(() => new Mailbox(new Uri("invalid.com")));
        }

        [Fact]
        public void TestEquality()
        {
            var mailbox1 = new Mailbox(new Uri("mailto:test@example.com"));
            var mailbox2 = new Mailbox(new Uri("mailto:test@example.com"));
            AssertHelper.Equality<Mailbox, IMailbox, IInverseFunctionalIdentifier>(mailbox1, mailbox2, (a, b) => a == b);
        }

        [Fact]
        public void TestInequality()
        {
            var mailbox1 = new Mailbox(new Uri("mailto:test@example.com"));
            var mailbox3 = new Mailbox(new Uri("mailto:notequal@example.com"));
            Assert.False(mailbox1.Address.AbsoluteUri == mailbox3.Address.AbsoluteUri);
            Assert.True(mailbox1.Address.AbsoluteUri != mailbox3.Address.AbsoluteUri);

            Assert.False(mailbox1 == mailbox3);
            Assert.True(mailbox1 != mailbox3);
            AssertHelper.Inequality<Mailbox, IMailbox, IInverseFunctionalIdentifier>(mailbox1, mailbox3, (a, b) => a != b);
        }

        [Fact]
        public void TestToString()
        {
            var mailbox = new Mailbox(new Uri("mailto:email@example.com"));
            Assert.Equal("mailto:email@example.com", mailbox.ToString());
        }
    }
}
