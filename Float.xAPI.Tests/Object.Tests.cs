// <copyright file="Object.Tests.cs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

using Xunit;

namespace Float.xAPI.Tests
{
    public class ObjectTests
    {
        [Fact]
        public void TestObjectType()
        {
            Assert.Equal("Activity", ObjectType.Activity.ToString());
            Assert.Equal("Agent", ObjectType.Agent.ToString());
            Assert.Equal("Group", ObjectType.Group.ToString());
            Assert.Equal("StatementRef", ObjectType.StatementReference.ToString());
            Assert.Equal("SubStatement", ObjectType.SubStatement.ToString());

            Assert.True(ObjectType.Agent is ObjectType);

            AssertHelper.Equality(ObjectType.Activity, ObjectType.Activity);
            AssertHelper.Inequality(ObjectType.Agent, ObjectType.Group);
        }
    }
}
