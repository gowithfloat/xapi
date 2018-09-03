// <copyright file="Agent.Tests.cs" company="">
// Copyright (c) 2018 , All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

using System;
using System.Net.Mail;
using Float.xAPI.Actor;
using Float.xAPI.Actor.Identifier;
using Xunit;
using static Float.xAPI.Tests.TestHelpers;

namespace Float.xAPI.Tests
{
    public class AgentTests : IInitializationTests<Agent>, IEqualityTests, IToStringTests, ISerializationTests
    {
        [Fact]
        public Agent TestValidInit()
        {
            var ifi1 = new Mailbox(new MailAddress("test@example.com"));
            var ifi2 = new MailboxSha1Sum(new SHAHash("test@example.com"));
            var ifi3 = new OpenID(new Uri("https://www.gowithfloat.com"));
            var ifi4 = new Account("test", new Uri("http://example.com"));
            var agent1 = new Agent(ifi1, "example");
            var agent2 = new Agent(ifi2, "example");
            var agent3 = new Agent(ifi3, "example");
            var agent4 = new Agent(ifi4, "example");
            return agent1;
        }

        [Fact]
        public void TestInvalidInit()
        {
            Assert.Throws<ArgumentNullException>(() => new Agent(null));
            Assert.Throws<ArgumentNullException>(() => new Agent(null, null));
            Assert.Throws<ArgumentNullException>(() => new Agent(null, "Name"));
        }

        [Fact]
        public void TestEquality()
        {
            var ifi1 = new Mailbox(new MailAddress("test@example.com"));
            var ifi2 = new MailboxSha1Sum(new SHAHash("test@example.com"));
            var ifi3 = new OpenID(new Uri("https://www.gowithfloat.com"));
            var ifi4 = new Account("test", new Uri("http://example.com"));
            var agent1a = new Agent(ifi1, "Example Learner");
            var agent1b = new Agent(ifi1, "Learner, Example");
            var agent2a = new Agent(ifi2, "Jane Doe");
            var agent2b = new Agent(ifi2, "Sue Schmoe");
            var agent3a = new Agent(ifi3, "App User");
            var agent3b = new Agent(ifi3, "xAPI Example");
            var agent4a = new Agent(ifi4, "Virtual Instructor");
            var agent4b = new Agent(ifi4, "Student");
            Assert.Equal(agent1a, agent1b);
            Assert.Equal(agent2a, agent2b);
            Assert.Equal(agent3a, agent3b);
            Assert.Equal(agent4a, agent4b);
            Assert.Equal(agent1a.GetHashCode(), agent1b.GetHashCode());
            Assert.True(agent1a == agent1b);
            Assert.True(agent2a == agent2b);
            Assert.True(agent3a == agent3b);
            Assert.True(agent4a == agent4b);
        }

        [Fact]
        public void TestInequality()
        {
            var ifi1 = new Mailbox(new MailAddress("test@example.com"));
            var ifi2 = new MailboxSha1Sum(new SHAHash("test@example.com"));
            var ifi3 = new OpenID(new Uri("https://www.gowithfloat.com"));
            var ifi4 = new Account("test", new Uri("http://example.com"));
            var agent1a = new Agent(ifi1, "Jane Doe");
            var agent1b = new Agent(ifi1, "Learner, Example");
            var agent2a = new Agent(ifi2, "Jane Doe");
            var agent2b = new Agent(ifi2, "Sue Schmoe");
            var agent3a = new Agent(ifi3, "Jane Doe");
            var agent3b = new Agent(ifi3, "xAPI Example");
            var agent4a = new Agent(ifi4, "Jane Doe");
            var agent4b = new Agent(ifi4, "Student");
            Assert.NotEqual(agent1a, agent2a);
            Assert.NotEqual(agent2a, agent3a);
            Assert.NotEqual(agent3a, agent4a);
            Assert.NotEqual(agent1a.GetHashCode(), agent2a.GetHashCode());
            Assert.True(agent1a != agent2a);
            Assert.True(agent2a != agent3a);
            Assert.True(agent3a != agent4a);
        }

        [Fact]
        public void TestToString()
        {
            var ifi1 = new Mailbox(new MailAddress("jdoe@example.com"));
            var ifi2 = new MailboxSha1Sum(new SHAHash("sschmoe@example.com"));
            var ifi3 = new OpenID(new Uri("https://www.gowithfloat.com"));
            var ifi4 = new Account("test", new Uri("http://example.com"));
            var agent1a = new Agent(ifi1, "Jane Doe");
            var agent2a = new Agent(ifi2, "Sue Schmoe");
            var agent3a = new Agent(ifi3, "Learner, Example");
            var agent4a = new Agent(ifi4, "Student");
            Assert.Equal("<Agent: Name \"Jane Doe\" IFI mailto:jdoe@example.com>", agent1a.ToString());
            Assert.Equal("<Agent: Name \"Sue Schmoe\" IFI mbox_sha1sum: 0e3372390b51c30c2fa4d2e0fd7b2b2009fc5692>", agent2a.ToString());
            Assert.Equal("<Agent: Name \"Learner, Example\" IFI <OpenID: https://www.gowithfloat.com/>>", agent3a.ToString());
            Assert.Equal("<Agent: Name \"Student\" IFI <Account: Name \"test\" HomePage http://example.com/>>", agent4a.ToString());
        }

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
