// <copyright file="Agent.Tests.cs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

using System;
using System.Net.Mail;
using Float.xAPI.Actor;
using Float.xAPI.Actor.Identifier;
using Xunit;
using static Float.xAPI.Json.Tests.TestHelpers;

namespace Float.xAPI.Json.Tests
{
    public class AgentTests
    {
        [Fact]
        public void TestSerialize()
        {
            var ifi1 = new Mailbox(new MailAddress("jdoe@example.com"));
            var ifi2 = new MailboxSha1Sum(new SHAHash("sschmoe@example.com"));
            var ifi3 = new OpenID(new Uri("https://www.gowithfloat.com"));
            var ifi4 = new Account("test", new Uri("http://example.com"));
            var agent1 = new Agent(ifi1, "Jane Doe");
            var agent2 = new Agent(ifi2, "Sue Schmoe");
            var agent3 = new Agent(ifi3, "Learner, Example");
            var agent4 = new Agent(ifi4, "Student");
        }

        [Fact]
        public void TestDeserialize()
        {
            var json = ReadFile("data-agent-account-example.json");
        }
    }
}
