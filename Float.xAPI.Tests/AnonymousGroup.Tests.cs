// <copyright file="AnonymousGroup.Tests.cs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using Float.xAPI.Actor;
using Float.xAPI.Actor.Identifier;
using Xunit;

namespace Float.xAPI.Tests
{
    public class AnonymousGroupTests : IInitializationTests<AnonymousGroup>, IToStringTests
    {
        [Fact]
        public AnonymousGroup TestValidInit()
        {
            var ifi = new OpenID(new Uri("a://b.c"));
            var members = new List<IAgent>
            {
                new Agent(ifi, "Agent Name")
            };

            return new AnonymousGroup(members, "Group Name");
        }

        [Fact]
        public void TestInvalidInit()
        {
            var ifi = new OpenID(new Uri("a://b.c"));
            var members1 = new List<IAgent>();
            var members2 = new List<IAgent>
            {
                new Agent(ifi, "Agent Name")
            };

            Assert.Throws<ArgumentNullException>(() => new AnonymousGroup(null, "Group Name"));
            Assert.Throws<ArgumentException>(() => new AnonymousGroup(members1, "Group Name"));
            Assert.Throws<ArgumentException>(() => new AnonymousGroup(members2, string.Empty));
            Assert.Throws<ArgumentException>(() => new AnonymousGroup(members2, " "));
        }

        [Fact]
        public void TestProperties()
        {
            var group = new AnonymousGroup(
                new List<IAgent>
            {
                new Agent(new OpenID(new Uri("http://example.com/1"))),
                new Agent(new OpenID(new Uri("http://example.com/2")))
            }, "test name");

            Assert.Equal("Group", group.ObjectType);

            var igroup = group as IAnonymousGroup;
            Assert.Equal("Group", igroup.ObjectType);
            Assert.Equal(2, igroup.Member.Count());
            Assert.Equal("test name", igroup.Name);
        }

        [Fact]
        public void TestToString()
        {
            var members = new List<IAgent>
            {
                new Agent(new OpenID(new Uri("http://www.example.com")), "Agent Name"),
                new Agent(new OpenID(new Uri("http://www.example.com")), "Another Agent")
            };

            var group = new AnonymousGroup(members, "Sample Group");
            Assert.Equal("<AnonymousGroup: Name \"Sample Group\" Member <Agent: Name \"Agent Name\" IFI <OpenID: http://www.example.com/>>, <Agent: Name \"Another Agent\" IFI <OpenID: http://www.example.com/>>>", group.ToString());
        }
    }
}
