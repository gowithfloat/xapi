// <copyright file="FillInInteractionActivityDefinition.Tests.cs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

using System;
using System.Collections.Generic;
using Float.xAPI.Activities;
using Float.xAPI.Activities.Definitions;
using Float.xAPI.Languages;
using Xunit;

namespace Float.xAPI.Tests
{
    public class FillInInteractionActivityDefinitionTests : IInitializationTests<FillInInteractionActivityDefinition>, IPropertyTests
    {
        [Fact]
        public FillInInteractionActivityDefinition TestValidInit()
        {
            var name = LanguageMap.EnglishUS("name");
            var description = LanguageMap.EnglishUS("Ben is often heard saying: ");
            var correctResponsesPattern = new ResponsePattern(new CharacterString("Bob's your uncle"));
            var moreInfo = new Uri("http://example.com/more");
            var extensions = new Dictionary<Uri, object>
            {
                {
                    new Uri("http://example.com/ext"), "ext"
                },
            };
            var definition1 = new FillInInteractionActivityDefinition(name, description, correctResponsesPattern);
            var definition2 = new FillInInteractionActivityDefinition(name, description, correctResponsesPattern, moreInfo);
            return new FillInInteractionActivityDefinition(name, description, correctResponsesPattern, moreInfo, extensions);
        }

        [Fact]
        public void TestInvalidInit()
        {
            var map = LanguageMap.EnglishUS("test");
            var resp = new ResponsePattern(new CharacterString("test"));
            Assert.Throws<ArgumentNullException>(() => new FillInInteractionActivityDefinition(null, null, null));
            Assert.Throws<ArgumentNullException>(() => new FillInInteractionActivityDefinition(map, null, null));
            Assert.Throws<ArgumentNullException>(() => new FillInInteractionActivityDefinition(null, map, resp));
            Assert.Throws<ArgumentNullException>(() => new FillInInteractionActivityDefinition(map, null, resp));
            Assert.Throws<ArgumentNullException>(() => new FillInInteractionActivityDefinition(map, map, null));
        }

        [Fact]
        public void TestProperties()
        {
            var name = LanguageMap.EnglishUS("name");
            var description = LanguageMap.EnglishUS("Ben is often heard saying: ");
            var correctResponsesPattern = new ResponsePattern(new CharacterString("Bob's your uncle"));
            var moreInfo = new Uri("http://example.com/more");
            var extensions = new Dictionary<Uri, object>
            {
                {
                    new Uri("http://example.com/ext"), "ext"
                },
            };
            var definition = new FillInInteractionActivityDefinition(name, description, correctResponsesPattern, moreInfo, extensions);
            Assert.Equal(correctResponsesPattern, definition.CorrectResponsesPattern);
            Assert.Equal(description, definition.Description);
            Assert.Equal(extensions, definition.Extensions);
            Assert.Equal(Interaction.FillIn, definition.InteractionType);
            Assert.Equal(moreInfo, definition.MoreInfo);
            Assert.Equal(name, definition.Name);
            Assert.Equal(new Uri("http://adlnet.gov/expapi/activities/cmi.interaction"), definition.Type);

            var idefinition = definition as IInteractionActivityDefinition;
            Assert.Equal(correctResponsesPattern, idefinition.CorrectResponsesPattern);
            Assert.Equal(description, idefinition.Description);
            Assert.Equal(extensions, idefinition.Extensions);
            Assert.Equal(Interaction.FillIn, idefinition.InteractionType);
            Assert.Equal(moreInfo, idefinition.MoreInfo);
            Assert.Equal(name, idefinition.Name);
            Assert.Equal(new Uri("http://adlnet.gov/expapi/activities/cmi.interaction"), idefinition.Type);
        }
    }
}
