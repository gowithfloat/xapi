// <copyright file="MailboxSha1Sum.Tests.cs" company="">
// Copyright (c) 2018 , All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

using Float.xAPI.Actor.Identifier;
using Xunit;

namespace Float.xAPI.Tests
{
	public class MailboxSha1SumTests
	{
        [Fact]
		public void TestValidInit()
		{
            var valid = new MailboxSha1Sum(new SHA1Hash("test"));
		}

        [Fact]
        public void TestToString()
        {
            var mailbox = new MailboxSha1Sum(new SHA1Hash("person@example.com"));
            Assert.Equal("mbox_sha1sum: 371ab9ac0b1ab6d871f7a4c6e8823579e979eb90", mailbox.ToString());
        }

        [Fact]
        public void TestEquality()
        {
            var mailbox1 = new MailboxSha1Sum(new SHA1Hash("person1@example.com"));
            var mailbox2 = new MailboxSha1Sum(new SHA1Hash("person2@example.com"));
            Assert.NotEqual(mailbox1, mailbox2);
            Assert.NotEqual(mailbox1.MboxSha1Sum, mailbox2.MboxSha1Sum);
            Assert.NotEqual(mailbox1.MboxSha1Sum.Encoded, mailbox2.MboxSha1Sum.Encoded);

            var mailbox3 = new MailboxSha1Sum(new SHA1Hash("person1@example.com"));
            Assert.Equal(mailbox1, mailbox3);
            Assert.Equal(mailbox1.MboxSha1Sum, mailbox3.MboxSha1Sum);
            Assert.Equal(mailbox1.MboxSha1Sum.Encoded, mailbox3.MboxSha1Sum.Encoded);
        }
	}
}
