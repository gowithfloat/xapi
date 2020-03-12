// <copyright file="MailboxSha1Sum.Tests.cs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

using Float.xAPI.Actors.Identifier;
using Xunit;

namespace Float.xAPI.Tests
{
    public class MailboxSha1SumTests : IInitializationTests<MailboxSha1Sum>, IEqualityTests, IToStringTests
    {
        [Fact]
        public MailboxSha1Sum TestValidInit()
        {
            return new MailboxSha1Sum(new SHAHash("test"));
        }

        [Fact]
        public void TestInvalidInit()
        {
            // since MailboxSha1Sum takes a struct, there's not really a way to pass it a null value
        }

        [Fact]
        public void TestEquality()
        {
            var mailbox1 = new MailboxSha1Sum(new SHAHash("person1@example.com"));
            var mailbox3 = new MailboxSha1Sum(new SHAHash("person1@example.com"));
            AssertHelper.Equality<MailboxSha1Sum, IMailboxSha1Sum, IInverseFunctionalIdentifier>(mailbox1, mailbox3, (a, b) => a == b);
        }

        [Fact]
        public void TestInequality()
        {
            var mailbox1 = new MailboxSha1Sum(new SHAHash("person1@example.com"));
            var mailbox2 = new MailboxSha1Sum(new SHAHash("person2@example.com"));
            AssertHelper.Inequality<MailboxSha1Sum, IMailboxSha1Sum, IInverseFunctionalIdentifier>(mailbox1, mailbox2, (a, b) => a != b);
        }

        [Fact]
        public void TestToString()
        {
            var mailbox = new MailboxSha1Sum(new SHAHash("person@example.com"));
            Assert.Equal("mbox_sha1sum: 371ab9ac0b1ab6d871f7a4c6e8823579e979eb90", mailbox.ToString());
        }
    }
}
