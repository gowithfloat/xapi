// <copyright file="Mailbox.Tests.cs" company="">
// Copyright (c) 2018 , All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

using System;
using System.Net.Mail;
using Float.xAPI.Actor.Identifier;
using Xunit;

namespace Float.xAPI.Tests
{
    public class MailboxTests
    {
        [Fact]
        public void TestInit()
        {
            Assert.Throws<ArgumentNullException>(() => new Mailbox(null));
            Assert.Throws<ArgumentNullException>(() => new Mailbox(new MailAddress(null)));
            Assert.Throws<ArgumentException>(() => new Mailbox(new MailAddress(string.Empty)));
            Assert.Throws<FormatException>(() => new Mailbox(new MailAddress(" ")));
            Assert.Throws<FormatException>(() => new Mailbox(new MailAddress("invalid")));
            Assert.Throws<FormatException>(() => new Mailbox(new MailAddress("invalid.com")));
            var mailbox = new Mailbox(new MailAddress("valid@example.com"));
        }

        [Fact]
        public void TestEquality()
        {
            var mailbox1 = new Mailbox(new MailAddress("test@example.com"));
            var mailbox2 = new Mailbox(new MailAddress("test@example.com"));
            var mailbox3 = new Mailbox(new MailAddress("notequal@example.com"));
            Assert.Equal(mailbox1, mailbox2);
            Assert.NotEqual(mailbox1, mailbox3);
        }

        [Fact]
        public void TestToString()
        {
            var mailbox = new Mailbox(new MailAddress("email@example.com"));
            Assert.Equal("mailto:email@example.com", mailbox.ToString());
        }

        [Fact]
        public void TestHashCode()
        {
            var mailbox1 = new Mailbox(new MailAddress("test@example.com"));
            var mailbox2 = new Mailbox(new MailAddress("test@example.com"));
            var mailbox3 = new Mailbox(new MailAddress("notequal@example.com"));
            Assert.Equal(mailbox1.GetHashCode(), mailbox2.GetHashCode());
            Assert.NotEqual(mailbox1.GetHashCode(), mailbox3.GetHashCode());
        }
    }
}
