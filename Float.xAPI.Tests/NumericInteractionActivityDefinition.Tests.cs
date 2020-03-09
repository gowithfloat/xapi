// <copyright file="NumericInteractionActivityDefinition.Tests.cs" company="Float">
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
    public class NumericInteractionActivityDefinitionTests : IInitializationTests<NumericInteractionActivityDefinition>, IPropertyTests
    {
        [Fact]
        public NumericInteractionActivityDefinition TestValidInit()
        {
            var def1 = new NumericInteractionActivityDefinition(
                LanguageMap.EnglishUS("Jokes"),
                LanguageMap.EnglishUS("How many jokes is Chris the butt of each day?"),
                new ResponsePattern(new CharacterStringNumeric(4)));
            var def2 = new NumericInteractionActivityDefinition(
                LanguageMap.EnglishUS("Name"),
                LanguageMap.EnglishUS("Description"),
                new ResponsePattern(new CharacterStringNumeric(4)),
                new Uri("http://example.com"));
            return new NumericInteractionActivityDefinition(
                LanguageMap.EnglishUS("Name"),
                LanguageMap.EnglishUS("Description"),
                new ResponsePattern(new CharacterStringNumeric(4)),
                new Uri("http://example.com"),
                new Dictionary<Uri, object> { { new Uri("http://extension.com"), "extension" } });
        }

        [Fact]
        public void TestInvalidInit()
        {
            Assert.Throws<ArgumentNullException>(() => new NumericInteractionActivityDefinition(null, null, null, null));
            Assert.Throws<ArgumentNullException>(() => new NumericInteractionActivityDefinition(LanguageMap.EnglishUS("name"), null, null, null));
            Assert.Throws<ArgumentNullException>(() => new NumericInteractionActivityDefinition(LanguageMap.EnglishUS("name"), LanguageMap.EnglishUS("description"), null, null));
            Assert.Throws<ArgumentException>(() => new NumericInteractionActivityDefinition(LanguageMap.EnglishUS("name"), LanguageMap.EnglishUS("description"), new ResponsePattern(new CharacterStringNumeric(4)), new Uri("http://example.com"), new Dictionary<Uri, object> { }));
        }

        [Fact]
        public void TestProperties()
        {
            var definition = new NumericInteractionActivityDefinition(
                LanguageMap.EnglishUS("Name"),
                LanguageMap.EnglishUS("Description"),
                new ResponsePattern(new CharacterStringNumeric(4)),
                new Uri("http://example.com"),
                new Dictionary<Uri, object> { { new Uri("http://extension.com"), "extension" } });

            Assert.Equal(LanguageMap.EnglishUS("Name"), definition.Name);
            Assert.Equal(LanguageMap.EnglishUS("Description"), definition.Description);
            Assert.Equal(new ResponsePattern(new CharacterStringNumeric(4)), definition.CorrectResponsesPattern);
            Assert.Equal(new Uri("http://example.com"), definition.MoreInfo);
            Assert.Equal(new Uri("http://adlnet.gov/expapi/activities/cmi.interaction"), definition.Type);
            Assert.Equal(Interaction.Numeric, definition.InteractionType);
            Assert.Equal(new Uri("http://extension.com"), definition.Extensions.Value.First().Key); // todo: avoid Value
            Assert.Equal("extension", definition.Extensions.Value.First().Value);

            var idefinition = definition as IInteractionActivityDefinition;
            Assert.Equal(new ResponsePattern(new CharacterStringNumeric(4)), idefinition.CorrectResponsesPattern);
            Assert.Equal(LanguageMap.EnglishUS("Description"), idefinition.Description);
            Assert.Equal(new Uri("http://extension.com"), idefinition.Extensions.Value.First().Key);
            Assert.Equal(Interaction.Numeric, idefinition.InteractionType);
            Assert.Equal(new Uri("http://example.com"), idefinition.MoreInfo);
            Assert.Equal(LanguageMap.EnglishUS("Name"), idefinition.Name);
            Assert.Equal(new Uri("http://adlnet.gov/expapi/activities/cmi.interaction"), idefinition.Type);
        }
    }
}
