// <copyright file="ActivityDefinition.Tests.cs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using Float.xAPI.Activities.Definitions;
using Float.xAPI.Languages;
using Xunit;

namespace Float.xAPI.Tests
{
    public class ActivityDefinitionTests : IInitializationTests<ActivityDefinition>, IPropertyTests
    {
        [Fact]
        public ActivityDefinition TestValidInit()
        {
            var name = new LanguageMap(LanguageTag.EnglishUS, "Name");
            var description = new LanguageMap(LanguageTag.EnglishUS, "Description");
            var uri = new Uri("http://example.com");
            var moreInfo = new Uri("http://example.com/more");
            var extensions = new Dictionary<Uri, object>
            {
                { new Uri("http://example.com/ext1"), "ext1" },
            };

            var ad1 = new ActivityDefinition(name, description, uri);
            var ad2 = new ActivityDefinition(name, description, uri, moreInfo);
            var ad3 = new ActivityDefinition(name, description, uri, extensions: extensions);
            var ad4 = new ActivityDefinition(name, description, uri, moreInfo, extensions);

            return ad4;
        }

        [Fact]
        public void TestInvalidInit()
        {
            var name = new LanguageMap(LanguageTag.EnglishUS, "Name");
            var desc = new LanguageMap(LanguageTag.EnglishUS, "Description");
            Assert.Throws<UriFormatException>(() => new ActivityDefinition(name, desc, new Uri(string.Empty)));
        }

        [Fact]
        public void TestProperties()
        {
            var activityDefinition = new ActivityDefinition(
                LanguageMap.EnglishUS("name"),
                LanguageMap.EnglishUS("description"),
                new Uri("http://example.com/type"),
                new Uri("http://example.com/more"),
                new Dictionary<Uri, object> { { new Uri("http://example.com/ext"), "extension" } });
            Assert.Equal(LanguageMap.EnglishUS("description"), activityDefinition.Description);
            Assert.Equal("extension", activityDefinition.Extensions.Value.First().Value);
            Assert.Equal(new Uri("http://example.com/more"), activityDefinition.MoreInfo);
            Assert.Equal(new Uri("http://example.com/type"), activityDefinition.Type);
            Assert.Equal(LanguageMap.EnglishUS("name"), activityDefinition.Name);

            var iactivityDefinition = activityDefinition as IActivityDefinition;
            Assert.Equal(LanguageMap.EnglishUS("description").ToString(), iactivityDefinition.Description.Value.ToString());
            Assert.Equal(new Uri("http://example.com/ext"), iactivityDefinition.Extensions.Value.First().Key);
            Assert.Equal("http://example.com/more", iactivityDefinition.MoreInfo.Value.ToString());
            Assert.Equal("http://example.com/type", iactivityDefinition.Type.Value.ToString());
            Assert.Equal(LanguageMap.EnglishUS("name").ToString(), iactivityDefinition.Name.Value.ToString());
        }
    }
}
