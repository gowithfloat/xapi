// <copyright file="Agent.Tests.cs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

using System;
using System.Net.Mail;
using Float.xAPI.Actor;
using Float.xAPI.Actor.Identifier;
using Xunit;

namespace Float.xAPI.Tests
{
    public class AgentTests : IInitializationTests<Agent>, IEqualityTests
    {
        [Fact]
        public Agent TestValidInit()
        {
            var ifi1 = new Mailbox(new Uri("mailto:test@example.com"));
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
            var ifi1 = new Mailbox(new Uri("mailto:test@example.com"));
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
            AssertHelper.Equality<Agent, IAgent, IIdentifiedActor>(agent1a, agent1b, (a, b) => a == b);
            AssertHelper.Equality<Agent, IAgent, IIdentifiedActor>(agent2a, agent2b, (a, b) => a == b);
            AssertHelper.Equality<Agent, IAgent, IIdentifiedActor>(agent3a, agent3b, (a, b) => a == b);
            AssertHelper.Equality<Agent, IAgent, IIdentifiedActor>(agent4a, agent4b, (a, b) => a == b);
        }

        [Fact]
        public void TestInequality()
        {
            var ifi1 = new Mailbox(new Uri("mailto:test1@example.com"));
            var ifi2 = new MailboxSha1Sum(new SHAHash("test2@example.com"));
            var ifi3 = new OpenID(new Uri("https://www.gowithfloat.com"));
            var ifi4 = new Account("test", new Uri("http://example.com"));
            var agent1a = new Agent(ifi1, "Jane Doe");
            var agent2a = new Agent(ifi2, "Jane Doe");
            var agent3a = new Agent(ifi3, "Jane Doe");
            var agent4a = new Agent(ifi4, "Jane Doe");
            AssertHelper.Inequality<Agent, IAgent, IIdentifiedActor>(agent1a, agent2a, (a, b) => a != b);
            AssertHelper.Inequality<Agent, IAgent, IIdentifiedActor>(agent2a, agent3a, (a, b) => a != b);
            AssertHelper.Inequality<Agent, IAgent, IIdentifiedActor>(agent3a, agent4a, (a, b) => a != b);
            AssertHelper.Inequality<Agent, IAgent, IIdentifiedActor>(agent4a, agent1a, (a, b) => a != b);
        }
    }
}
