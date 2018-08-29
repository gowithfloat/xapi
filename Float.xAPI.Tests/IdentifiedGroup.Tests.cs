// <copyright file="IdentifiedGroup.Tests.cs" company="">
// Copyright (c) 2018 , All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

using System;
using System.Collections.Generic;
using Float.xAPI.Actor;
using Float.xAPI.Actor.Identifier;
using Xunit;

namespace Float.xAPI.Tests
{
    public class IdentifiedGroupTests : IInitializationTests, IEqualityTests, IToStringTests
    {
        [Fact]
        public void TestValidInit()
        {
            var ifi = new OpenID(new Uri("https://www.gowithfloat.com"));
            var group1 = new IdentifiedGroup(ifi);

            var ifi2 = new Account("Example", new Uri("http://www.example.com"));
            var members = new List<IAgent>
            {
                new Agent(ifi2),
                new Agent(ifi2)
            };

            var group2 = new IdentifiedGroup(ifi, members);
            var group3 = new IdentifiedGroup(ifi, members, "Identified Group");
        }

        [Fact]
        public void TestInvalidInit()
        {
            Assert.Throws<ArgumentNullException>(() => new IdentifiedGroup(null));
        }

        [Fact]
        public void TestEquality()
        {
            var group1 = new IdentifiedGroup(new OpenID(new Uri("http://example.com")));
            var group2 = new IdentifiedGroup(new OpenID(new Uri("http://example.com")));
            Assert.Equal(group1, group2);

            var ifi2 = new Account("Example", new Uri("http://example.com"));
            var members = new List<IAgent>
            {
                new Agent(ifi2),
                new Agent(ifi2)
            };
            var group3 = new IdentifiedGroup(new OpenID(new Uri("http://example.com")), members);
            Assert.Equal(group2, group3);
        }

        [Fact]
        public void TestInequality()
        {
            var group1 = new IdentifiedGroup(new OpenID(new Uri("http://gowithfloat.com")));
            var group2 = new IdentifiedGroup(new OpenID(new Uri("http://example.com")));
            Assert.NotEqual(group1, group2);
        }

        [Fact]
        public void TestToString()
        {
            var group1 = new IdentifiedGroup(new OpenID(new Uri("http://example.com/group")), new List<IAgent>
            {
                new Agent(new OpenID(new Uri("http://example.com/agent1"))),
                new Agent(new OpenID(new Uri("http://example.com/agent2")))
            }, "Example Group");
            Assert.Equal("<IdentifiedGroup: Name Example Group Member <Agent: IFI <OpenID: http://example.com/agent1>>, <Agent: IFI <OpenID: http://example.com/agent2>> IFI <OpenID: http://example.com/group>>", group1.ToString());
        }
    }
}
