﻿// <copyright file="Agent.Tests.cs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

using System;
using Float.xAPI.Actors;
using Float.xAPI.Actors.Identifier;
using Xunit;
using static Float.xAPI.Json.Tests.TestHelpers;

namespace Float.xAPI.Json.Tests
{
    public class AgentTests
    {
        [Fact]
        public void TestSerialize()
        {
            var ifi1 = new Mailbox(new Uri("mailto:jdoe@example.com"));
            var ifi2 = new MailboxSha1Sum(new SHAHash("sschmoe@example.com"));
            var ifi3 = new OpenID(new Uri("https://www.gowithfloat.com"));
            var ifi4 = new Account("test", new Uri("http://example.com"));
            var agent1 = new Agent(ifi1, "Jane Doe");
            var agent2 = new Agent(ifi2, "Sue Schmoe");
            var agent3 = new Agent(ifi3, "Learner, Example");
            var agent4 = new Agent(ifi4);

            Assert.Equal(FormatJson("{\"objectType\":\"Agent\",\"name\":\"Jane Doe\",\"mbox\":\"mailto:jdoe@example.com\"}"),
                FormatJson(Serialize.Actor(Actor.From(agent1))));
            Assert.Equal(FormatJson("{\"objectType\":\"Agent\",\"name\":\"Sue Schmoe\",\"mbox_sha1sum\":\"0e3372390b51c30c2fa4d2e0fd7b2b2009fc5692\"}"),
                FormatJson(Serialize.Actor(Actor.From(agent2))));
            Assert.Equal(FormatJson("{\"objectType\":\"Agent\",\"name\":\"Learner, Example\",\"openid\":\"https://www.gowithfloat.com/\"}"),
                FormatJson(Serialize.Actor(Actor.From(agent3))));
            Assert.Equal(FormatJson("{\"objectType\":\"Agent\",\"account\":{\"homePage\":\"http://example.com/\",\"name\":\"test\"}}"),
                FormatJson(Serialize.Actor(Actor.From(agent4))));
        }

        [Fact]
        public void TestDeserialize()
        {
            var json = ReadFile("data-agent-account-example.json");
            var agent = Deserialize.ParseAgent(json).Value;

            Assert.NotNull(agent);
            Assert.Equal(ObjectType.Agent, agent.ObjectType);
            Assert.True(agent.IFI.IsAccount);

            switch (agent.IFI)
            {
                case var ifi when ifi.IsAccount:
                    var account = ((InverseFunctionalIdentifier.Account)ifi).Item;
                    Assert.Equal(new Uri("http://www.example.com/"), account.HomePage);
                    Assert.Equal("1625378", account.Name);
                    break;
                default:
                    Assert.True(false);
                    break;
            }
        }
    }
}
