// <copyright file="MailboxSha1Sum.Tests.cs" company="">
// Copyright (c) 2018 , All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

using System;
using System.Security.Cryptography;
using Float.xAPI.Actor.Identifier;
using Xunit;

namespace Float.xAPI.Tests
{
	public class MailboxSha1SumTests
	{
        [Fact]
		public void TestInit()
		{
            Assert.Throws<ArgumentException>(() => new MailboxSha1Sum(new SHA1Hash(null)));
            Assert.Throws<ArgumentException>(() => new MailboxSha1Sum(new SHA1Hash(string.Empty)));
            Assert.Throws<ArgumentException>(() => new MailboxSha1Sum(new SHA1Hash(" ")));

            var valid = new MailboxSha1Sum(new SHA1Hash("test"));
		}
	}
}
