// <copyright file="ChoiceInteractionActivityDefinition.Tests.cs" company="Float">
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
    public class ChoiceInteractionActivityDefinitionTests : IInitializationTests<ChoiceInteractionActivityDefinition>, IPropertyTests
    {
        [Fact]
        public ChoiceInteractionActivityDefinition TestValidInit()
        {
            var name = LanguageMap.EnglishUS("name");
            var description = LanguageMap.EnglishUS("Which of these prototypes are available at the beta site?");
            var correctResponsesPattern = new ResponsePattern(new CharacterString(new string[] { "golf", "tetris" }));
            var choices = new List<IInteractionComponent>
            {
                new InteractionComponent("golf", LanguageMap.EnglishUS("Golf Example")),
                new InteractionComponent("facebook", LanguageMap.EnglishUS("Facebook App")),
                new InteractionComponent("tetris", LanguageMap.EnglishUS("Tetris Example")),
                new InteractionComponent("scrabble", LanguageMap.EnglishUS("Scrabble Example")),
            };
            var moreInfo = new Uri("http://www.example.com/more");
            var extensions = new Dictionary<Uri, string>
            {
                {
                    new Uri("http://example.com/extension"), "extension"
                },
            };
            var definition1 = new ChoiceInteractionActivityDefinition(name, description, correctResponsesPattern, choices);
            var definition2 = new ChoiceInteractionActivityDefinition(name, description, correctResponsesPattern, choices, moreInfo);
            return new ChoiceInteractionActivityDefinition(name, description, correctResponsesPattern, choices, moreInfo, extensions);
        }

        [Fact]
        public void TestInvalidInit()
        {
            var map = LanguageMap.EnglishUS("test");
            var resp = new ResponsePattern(new CharacterString("test"));
            var choice = new IInteractionComponent[] { new InteractionComponent("test") };
            Assert.Throws<ArgumentNullException>(() => new ChoiceInteractionActivityDefinition(null, null, null, null));
            Assert.Throws<ArgumentNullException>(() => new ChoiceInteractionActivityDefinition(map, null, null, null));
            Assert.Throws<ArgumentNullException>(() => new ChoiceInteractionActivityDefinition(map, map, resp, null));
            Assert.Throws<ArgumentNullException>(() => new ChoiceInteractionActivityDefinition(null, map, resp, choice));
            Assert.Throws<ArgumentNullException>(() => new ChoiceInteractionActivityDefinition(map, null, resp, choice));
            Assert.Throws<ArgumentNullException>(() => new ChoiceInteractionActivityDefinition(map, map, null, choice));
        }

        [Fact]
        public void TestProperties()
        {
            var name = LanguageMap.EnglishUS("name");
            var description = LanguageMap.EnglishUS("Which of these prototypes are available at the beta site?");
            var correctResponsesPattern = new ResponsePattern(new CharacterString(new string[] { "golf", "tetris" }));
            var choices = new List<IInteractionComponent>
            {
                new InteractionComponent("golf", LanguageMap.EnglishUS("Golf Example")),
                new InteractionComponent("facebook", LanguageMap.EnglishUS("Facebook App")),
                new InteractionComponent("tetris", LanguageMap.EnglishUS("Tetris Example")),
                new InteractionComponent("scrabble", LanguageMap.EnglishUS("Scrabble Example")),
            };
            var moreInfo = new Uri("http://www.example.com/more");
            var extensions = new Dictionary<Uri, string>
            {
                {
                    new Uri("http://example.com/extension"), "extension"
                },
            };
            var definition1 = new ChoiceInteractionActivityDefinition(name, description, correctResponsesPattern, choices, moreInfo, extensions);

            Assert.Equal(choices, definition1.Choices);
            Assert.Equal(correctResponsesPattern, definition1.CorrectResponsesPattern);
            Assert.Equal(description, definition1.Description);
            Assert.Equal(extensions, definition1.Extensions);
            Assert.Equal(Interaction.Choice, definition1.InteractionType);
            Assert.Equal(moreInfo, definition1.MoreInfo);
            Assert.Equal(name, definition1.Name);
            Assert.Equal(new Uri("http://adlnet.gov/expapi/activities/cmi.interaction"), definition1.Type);

            var idefinition = definition1 as IChoiceInteractionActivityDefinition;
            Assert.Equal(choices, idefinition.Choices);
            Assert.Equal(correctResponsesPattern, idefinition.CorrectResponsesPattern);
            Assert.Equal(description, idefinition.Description);
            Assert.Equal(extensions, idefinition.Extensions);
            Assert.Equal(Interaction.Choice, idefinition.InteractionType);
            Assert.Equal(moreInfo, idefinition.MoreInfo);
            Assert.Equal(name, idefinition.Name);
            Assert.Equal(new Uri("http://adlnet.gov/expapi/activities/cmi.interaction"), idefinition.Type);
        }
    }
}
