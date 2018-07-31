// <copyright file="ContextActivites.Tests.cs" company="">
// Copyright (c) 2018 , All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

using System;
using System.Collections.Generic;
using Float.xAPI.Activities;
using Xunit;

namespace Float.xAPI.Tests
{
    public class ContextActivitesTests
    {
        [Fact]
        public void TestExample()
        {
            var parent = new Activity(new Uri("http://example.adlnet.gov/xapi/example/test1"));
            var parentList = new List<IActivity> { parent };
            var grouping = new Activity(new Uri("http://example.adlnet.gov/xapi/example/Algebra1"));
            var groupingList = new List<IActivity> { grouping };
            var contextActivities = new ContextActivites(parentList, groupingList, null, null);
        }
    }
}
