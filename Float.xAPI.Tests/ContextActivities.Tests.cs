// <copyright file="ContextActivities.Tests.cs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using Float.xAPI.Activities;
using Xunit;

namespace Float.xAPI.Tests
{
    public class ContextActivitiesTests : IInitializationTests<ContextActivities>, ISpecExampleTests, IPropertyTests
    {
        [Fact]
        public ContextActivities TestValidInit()
        {
            var ca1 = new ContextActivities();
            Assert.Null(ca1.Category);

            var parent = new List<IActivity>
            {
                new Activity(new ActivityId("http://b.c")),
            };

            var grouping = new List<IActivity>
            {
                new Activity(new ActivityId("http://b.c")),
            };

            var category = new List<IActivity>
            {
                new Activity(new ActivityId("http://b.c")),
            };

            var other = new List<IActivity>
            {
                new Activity(new ActivityId("http://b.c")),
            };

            return new ContextActivities(parent, grouping, category, other);
        }

        [Fact]
        public void TestInvalidInit()
        {
            var empty = new List<IActivity>();
            var one = new List<IActivity>
            {
                new Activity(new ActivityId("http://example.com")),
            };
            Assert.Throws<ArgumentException>(() => new ContextActivities(empty, empty, empty, empty));
            Assert.Throws<ArgumentException>(() => new ContextActivities(empty, one, one, one));
        }

        [Fact]
        public void TestExample()
        {
            var parent = new Activity(new ActivityId("http://example.adlnet.gov/xapi/example/test1"));
            var parentList = new List<IActivity> { parent };
            var grouping = new Activity(new ActivityId("http://example.adlnet.gov/xapi/example/Algebra1"));
            var groupingList = new List<IActivity> { grouping };
            var contextActivities = new ContextActivities(parentList, groupingList, null, null);
        }

        [Fact]
        public void TestProperties()
        {
            var parent = new Activity(new ActivityId("http://example/com/parent"));
            var parentList = new List<IActivity> { parent };
            var grouping = new Activity(new ActivityId("http://example/com/grouping"));
            var groupingList = new List<IActivity> { grouping };
            var category = new Activity(new ActivityId("http://example/com/category"));
            var categoryList = new List<IActivity> { category };
            var other = new Activity(new ActivityId("http://example/com/other"));
            var otherList = new List<IActivity> { other };
            var contextActivities = new ContextActivities(parentList, groupingList, categoryList, otherList);
            Assert.Equal(parent, contextActivities.Parent.Value.First());
            Assert.Equal(grouping, contextActivities.Grouping.Value.First());
            Assert.Equal(category, contextActivities.Category.Value.First());
            Assert.Equal(other, contextActivities.Other.Value.First());

            var icontextActivities = contextActivities as IContextActivities;
            Assert.Equal(parent, icontextActivities.Parent.Value.First());
            Assert.Equal(grouping, icontextActivities.Grouping.Value.First());
            Assert.Equal(category, icontextActivities.Category.Value.First());
            Assert.Equal(other, icontextActivities.Other.Value.First());
        }
    }
}
