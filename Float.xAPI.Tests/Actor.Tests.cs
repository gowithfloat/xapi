// <copyright file="Actor.Tests.cs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

using Xunit;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography;
using Float.xAPI.Actor;
using Float.xAPI.Actor.Identifier;
using Microsoft.FSharp.Core;

namespace Float.xAPI.Tests
{
    public class ActorTests
    {
        [Fact]
        public void TestAgent()
        {
            var agent = new Agent(new Mailbox(new MailAddress("test@example.com")), "me");
            Assert.Equal("me", agent.Name);
            Assert.Equal("Agent", agent.ObjectType);

            var ext = new Dictionary<Uri, string>
            {
                
            };
            var result = new Result(new Score(1.0, 1.0, 1.0, 1.0), true, true, "resp", TimeSpan.Zero, ext);
        }

        [Fact]
        public void TestGroup()
        {
            var agent1 = new Agent(new MailboxSha1Sum(SHA1.Create()), "jeff");
            var agent2 = new Agent(new OpenID(new Uri("http://www.example.com")), "bob");
            var group = new AnonymousGroup(new IAgent[] { agent1, agent2 }, "my group");
            Assert.Equal("my group", group.Name);
            Assert.Equal("Group", group.ObjectType);
            Assert.Equal(2, group.Member.Count());

            var agent3 = new Agent(new Account("frank", new Uri("http://www.example.com")), "frank");
            var group2 = new AnonymousGroup(new List<IAgent> { agent1, agent2, agent3 }, "list group");
            Assert.Equal(3, group2.Member.Count());
        }
    }
}
