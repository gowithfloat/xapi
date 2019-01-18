// <copyright file="IdentifiedGroup.Tests.cs" company="Float">
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
    public class IdentifiedGroupTests : IInitializationTests<IdentifiedGroup>, IEqualityTests
    {
        [Fact]
        public IdentifiedGroup TestValidInit()
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
            return new IdentifiedGroup(ifi, members, "Identified Group");
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
            Assert.Equal(group2.GetHashCode(), group3.GetHashCode());
            Assert.True(group2 == group3);
        }

        [Fact]
        public void TestInequality()
        {
            var group1 = new IdentifiedGroup(new OpenID(new Uri("http://gowithfloat.com")));
            var group2 = new IdentifiedGroup(new OpenID(new Uri("http://example.com")));
            Assert.NotEqual(group1, group2);
            Assert.NotEqual(group1.GetHashCode(), group2.GetHashCode());
            Assert.True(group1 != group2);
        }

        [Fact]
        public void TestProperties()
        {
            var members = new List<IAgent>
            {
                new Agent(new Account("learner", new Uri("http://example.com"))),
                new Agent(new Account("learner", new Uri("http://example.com")))
            };
            var group = new IdentifiedGroup(
                new OpenID(
                    new Uri("http://example.com")),
                    members,
                    "group");
            Assert.Equal(ObjectType.Group, group.ObjectType);

            var igroup = group as IIdentifiedGroup;
            Assert.Equal(ObjectType.Group, igroup.ObjectType);
            Assert.Equal(2, igroup.Member.Count());
            Assert.Equal("group", igroup.Name);
        }
    }
}
