// <copyright file="Activity.Tests.cs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

using System;
using Float.xAPI.Activities;
using Float.xAPI.Activities.Definitions;
using Float.xAPI.Languages;
using Xunit;

namespace Float.xAPI.Tests
{
    public class ActivityTests : IInitializationTests<Activity>, IEqualityTests
    {
        [Fact]
        public Activity TestValidInit()
        {
            var activity1 = new Activity(new Uri("http://example.com/id"));
            var definition = new ActivityDefinition(
                LanguageMap.EnglishUS("name"),
                LanguageMap.EnglishUS("description"),
                new Uri("http://example.com/type"));
            return new Activity(new Uri("http://example.com/id-2"), definition);
        }

        [Fact]
        public void TestInvalidInit()
        {
            Assert.Throws<ArgumentNullException>(() => new Activity(null));
        }

        [Fact]
        public void TestEquality()
        {
            var activity1 = new Activity(new Uri("http://example.com/id"));
            var activity2 = new Activity(new Uri("http://example.com/id"));
            AssertHelper.Equality<Activity, IActivity, IActivity>(activity1, activity2, (a, b) => a == b);
        }

        [Fact]
        public void TestInequality()
        {
            var activity1 = new Activity(new Uri("http://example.com/activity1"));
            var activity2 = new Activity(new Uri("http://example.com/activity2"));
            Assert.NotEqual(activity1, activity2);
            Assert.False(activity1 == activity2);
            Assert.False(activity1.Equals(activity2));
            Assert.True(activity1 != activity2);
            Assert.NotEqual(activity1.GetHashCode(), activity2.GetHashCode());
        }

        [Fact]
        public void TestProperties()
        {
            var definition = new ActivityDefinition(
                LanguageMap.EnglishUS("name"),
                LanguageMap.EnglishUS("description"),
                new Uri("http://example.com/type"));
            var activity = new Activity(new Uri("http://example.com/id-2"), definition);
            Assert.Equal("Activity", activity.ObjectType);
            Assert.Equal(new Uri("http://example.com/id-2"), activity.Id);
            Assert.Equal(definition, activity.Definition);
            Assert.Equal(LanguageMap.EnglishUS("name"), activity.Definition.Value.Name);

            var iactivity = activity as IActivity;
            Assert.Equal("Activity", iactivity.ObjectType);
            Assert.Equal(new Uri("http://example.com/id-2"), iactivity.Id);
            Assert.Equal(definition, iactivity.Definition);
        }
    }
}
