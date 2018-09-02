// <copyright file="ContextActivities.Tests.cs" company="">
// Copyright (c) 2018 , All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

using System;
using System.Collections.Generic;
using Float.xAPI.Activities;
using Xunit;

namespace Float.xAPI.Tests
{
    public class ContextActivitiesTests : IInitializationTests<ContextActivities>, IToStringTests, ISpecExampleTests
    {
        [Fact]
        public ContextActivities TestValidInit()
        {
            var ca1 = new ContextActivities();
            Assert.Null(ca1.Category);

            var parent = new List<IActivity>
            {
                new Activity(new Uri("a://b.c"))
            };

            var grouping = new List<IActivity>
            {
                new Activity(new Uri("a://b.c"))
            };

            var category = new List<IActivity>
            {
                new Activity(new Uri("a://b.c"))
            };

            var other = new List<IActivity>
            {
                new Activity(new Uri("a://b.c"))
            };

            return new ContextActivities(parent, grouping, category, other);
        }

        [Fact]
        public void TestInvalidInit()
        {
            var empty = new List<IActivity>();
            var one = new List<IActivity>
            {
                new Activity(new Uri("d://e.f"))
            };
            Assert.Throws<ArgumentException>(() => new ContextActivities(empty, empty, empty, empty));
            Assert.Throws<ArgumentException>(() => new ContextActivities(empty, one, one, one));
        }

        [Fact]
        public void TestToString()
        {
            var parent = new List<IActivity>
            {
                new Activity(new Uri("http://example.com/parent"))
            };

            var grouping = new List<IActivity>
            {
                new Activity(new Uri("http://example.com/grouping"))
            };

            var category = new List<IActivity>
            {
                new Activity(new Uri("http://example.com/category"))
            };

            var other = new List<IActivity>
            {
                new Activity(new Uri("http://example.com/other"))
            };

            var ca2 = new ContextActivities(parent, grouping, category, other);
            Assert.Equal("<ContextActivities: Parent <Activity: Id http://example.com/parent> Grouping <Activity: Id http://example.com/grouping> Category <Activity: Id http://example.com/category> Other <Activity: Id http://example.com/other>>", ca2.ToString());
        }

        [Fact]
        public void TestExample()
        {
            var parent = new Activity(new Uri("http://example.adlnet.gov/xapi/example/test1"));
            var parentList = new List<IActivity> { parent };
            var grouping = new Activity(new Uri("http://example.adlnet.gov/xapi/example/Algebra1"));
            var groupingList = new List<IActivity> { grouping };
            var contextActivities = new ContextActivities(parentList, groupingList, null, null);
        }
    }
}
