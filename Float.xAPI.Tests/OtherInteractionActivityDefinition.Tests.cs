﻿// <copyright file="OtherInteractionActivityDefinition.Tests.cs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using Float.xAPI.Activities;
using Float.xAPI.Activities.Definitions;
using Float.xAPI.Languages;
using Xunit;

namespace Float.xAPI.Tests
{
    public class OtherInteractionActivityDefinitionTests : IInitializationTests<OtherInteractionActivityDefinition>, IPropertyTests
    {
        [Fact]
        public OtherInteractionActivityDefinition TestValidInit()
        {
            var definition = new OtherInteractionActivityDefinition(
                LanguageMap.EnglishUS("Name"),
                LanguageMap.EnglishUS("On this map, please mark Franklin, TN"),
                new ResponsePattern("(35.937432,-86.868896)"));
            var definition2 = new OtherInteractionActivityDefinition(
                LanguageMap.EnglishUS("Name"),
                LanguageMap.EnglishUS("On this map, please mark Franklin, TN"),
                new ResponsePattern("(35.937432,-86.868896)"),
                new Uri("http://example.com"));
            return new OtherInteractionActivityDefinition(
                LanguageMap.EnglishUS("Name"),
                LanguageMap.EnglishUS("On this map, please mark Franklin, TN"),
                new ResponsePattern("(35.937432,-86.868896)"),
                new Uri("http://example.com"),
                new Dictionary<Uri, string> { { new Uri("http://example.com"), "extension" } });
        }

        [Fact]
        public void TestInvalidInit()
        {
            Assert.Throws<ArgumentNullException>(() => new OtherInteractionActivityDefinition(null, null, null));
            Assert.Throws<ArgumentNullException>(() => new OtherInteractionActivityDefinition(LanguageMap.EnglishUS("name"), null, null));
            Assert.Throws<ArgumentNullException>(() => new OtherInteractionActivityDefinition(LanguageMap.EnglishUS("name"), LanguageMap.EnglishUS("description"), null, null));
            Assert.Throws<ArgumentException>(() => new OtherInteractionActivityDefinition(LanguageMap.EnglishUS("name"), LanguageMap.EnglishUS("description"), new ResponsePattern(new CharacterStringNumeric(4)), new Uri("http://example.com"), new Dictionary<Uri, string> { }));
        }

        [Fact]
        public void TestProperties()
        {
            var definition = new OtherInteractionActivityDefinition(
                LanguageMap.EnglishUS("Name"),
                LanguageMap.EnglishUS("On this map, please mark Franklin, TN"),
                new ResponsePattern("(35.937432,-86.868896)"),
                new Uri("http://example.com"),
                new Dictionary<Uri, string> { { new Uri("http://example.com"), "extension" } });

            Assert.Equal(LanguageMap.EnglishUS("Name"), definition.Name);
            Assert.Equal(LanguageMap.EnglishUS("On this map, please mark Franklin, TN"), definition.Description);
            Assert.Equal(new ResponsePattern("(35.937432,-86.868896)"), definition.CorrectResponsesPattern);
            Assert.Equal(new Uri("http://example.com"), definition.MoreInfo);
            Assert.Equal(new Uri("http://adlnet.gov/expapi/activities/cmi.interaction"), definition.Type);
            Assert.Equal(Interaction.Other, definition.InteractionType);
            Assert.Equal(new Uri("http://example.com"), definition.Extensions.Value.First().Key); // todo: avoid Value
            Assert.Equal("extension", definition.Extensions.Value.First().Value);

            var idefinition = definition as IInteractionActivityDefinition;
            Assert.Equal(new ResponsePattern("(35.937432,-86.868896)"), idefinition.CorrectResponsesPattern);
            Assert.Equal(LanguageMap.EnglishUS("On this map, please mark Franklin, TN"), idefinition.Description);
            Assert.Equal(new Uri("http://example.com"), idefinition.Extensions.Value.First().Key);
            Assert.Equal(Interaction.Other, idefinition.InteractionType);
            Assert.Equal(new Uri("http://example.com"), idefinition.MoreInfo);
            Assert.Equal(LanguageMap.EnglishUS("Name"), idefinition.Name);
            Assert.Equal(new Uri("http://adlnet.gov/expapi/activities/cmi.interaction"), idefinition.Type);
        }
    }
}