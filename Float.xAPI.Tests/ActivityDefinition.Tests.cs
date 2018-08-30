// <copyright file="ActivityDefinition.Tests.cs" company="">
// Copyright (c) 2018 , All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

using System;
using System.Collections.Generic;
using Float.xAPI.Activities.Definitions;
using Xunit;

namespace Float.xAPI.Tests
{
    public class ActivityDefinitionTests : IInitializationTests, IToStringTests
    {
        [Fact]
        public void TestValidInit()
        {
            var name = new LanguageMap("en-US", "Name");
            var description = new LanguageMap("en-US", "Description");
            var uri = new Uri("http://example.com");
            var moreInfo = new Uri("http://example.com/more");
            var extensions = new Dictionary<Uri, string>
            {
                { new Uri("http://example.com/ext1"), "ext1" }
            };

            var ad1 = new ActivityDefinition(name, description, uri);
            var ad2 = new ActivityDefinition(name, description, uri, moreInfo);
            var ad3 = new ActivityDefinition(name, description, uri, extensions: extensions);
            var ad4 = new ActivityDefinition(name, description, uri, moreInfo, extensions);
        }

        [Fact]
        public void TestInvalidInit()
        {
            var name = new LanguageMap("en-US", "Name");
            var desc = new LanguageMap("en-US", "Description");
            Assert.Throws<ArgumentNullException>(() => new ActivityDefinition(null, null, null));
            Assert.Throws<ArgumentNullException>(() => new ActivityDefinition(name, null, null));
            Assert.Throws<ArgumentNullException>(() => new ActivityDefinition(null, desc, null));
            Assert.Throws<ArgumentNullException>(() => new ActivityDefinition(name, desc, null));
            Assert.Throws<UriFormatException>(() => new ActivityDefinition(name, desc, new Uri("")));
        }

        [Fact]
        public void TestToString()
        {
            var name = new LanguageMap("en-US", "Name");
            var description = new LanguageMap("en-US", "Description");
            var uri = new Uri("http://example.com");
            var ad1 = new ActivityDefinition(name, description, uri);
            // todo: need a good dict to string method
            //Assert.Equal("<ActivityDefinition: Name Description Type>", ad1.ToString());
        }
    }
}
