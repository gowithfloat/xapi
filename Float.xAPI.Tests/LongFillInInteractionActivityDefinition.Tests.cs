// <copyright file="LongFillInInteractionActivityDefinition.Tests.cs" company="Float">
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
    public class LongFillInInteractionActivityDefinitionTests : IInitializationTests<LongFillInInteractionActivityDefinition>
    {
        [Fact]
        public LongFillInInteractionActivityDefinition TestValidInit()
        {
            var definition1 = new LongFillInInteractionActivityDefinition(
                LanguageMap.EnglishUS("Long Fill-in"),
                LanguageMap.EnglishUS("What is the purpose of the xAPI?"),
                new ResponsePattern(new CharacterString("To store and provide access to learning experiences.", new LanguageTag(Language.English)), false));
            var definition2 = new LongFillInInteractionActivityDefinition(
                LanguageMap.EnglishUS("Long Fill-in"),
                LanguageMap.EnglishUS("What is the purpose of the xAPI?"),
                new ResponsePattern(new CharacterString("To store and provide access to learning experiences.", LanguageTag.EnglishUS), false),
                new Uri("http://www.example.com/more"));
            return new LongFillInInteractionActivityDefinition(
                LanguageMap.EnglishUS("Long Fill-in"),
                LanguageMap.EnglishUS("What is the purpose of the xAPI?"),
                new ResponsePattern(new CharacterString("To store and provide access to learning experiences.", LanguageTag.EnglishUS), false),
                new Uri("http://www.example.com/more"),
                new Dictionary<Uri, string> { { new Uri("a://b.c"), "extension" } });
        }

        [Fact]
        public void TestInvalidInit()
        {
            Assert.Throws<ArgumentNullException>(() => new LongFillInInteractionActivityDefinition(null, null, null));
            Assert.Throws<ArgumentNullException>(() => new LongFillInInteractionActivityDefinition(LanguageMap.EnglishUS("a"), null, null));
            Assert.Throws<ArgumentNullException>(() => new LongFillInInteractionActivityDefinition(LanguageMap.EnglishUS("a"), LanguageMap.EnglishUS("b"), null));
            Assert.Throws<ArgumentException>(() => new LongFillInInteractionActivityDefinition(LanguageMap.EnglishUS("a"), LanguageMap.EnglishUS("b"), new ResponsePattern("c"), new Uri("a://b.c"), new Dictionary<Uri, string>()));
        }

        [Fact]
        public void TestProperties()
        {
            var definition = new LongFillInInteractionActivityDefinition(
                LanguageMap.EnglishUS("Long Fill-in"),
                LanguageMap.EnglishUS("What is the purpose of the xAPI?"),
                new ResponsePattern(new CharacterString("To store and provide access to learning experiences.", LanguageTag.EnglishUS), false),
                new Uri("http://www.example.com/more"),
                new Dictionary<Uri, string> { { new Uri("a://b.c"), "extension" } });

            Assert.Single(definition.CorrectResponsesPattern.CharacterStrings);
            Assert.Equal(LanguageMap.EnglishUS("What is the purpose of the xAPI?"), definition.Description);
            Assert.Equal(new Dictionary<Uri, string> { { new Uri("a://b.c"), "extension" } }, definition.Extensions.Value);
            Assert.Equal(Interaction.LongFillIn, definition.InteractionType);
            Assert.Equal(new Uri("http://www.example.com/more"), definition.MoreInfo);
            Assert.Equal(LanguageMap.EnglishUS("Long Fill-in"), definition.Name);
            Assert.Equal(new Uri("http://adlnet.gov/expapi/activities/cmi.interaction"), definition.Type);

            var idefinition = definition as IInteractionActivityDefinition;
            Assert.Single(idefinition.CorrectResponsesPattern.CharacterStrings);
            Assert.Equal(LanguageMap.EnglishUS("What is the purpose of the xAPI?"), idefinition.Description);
            Assert.Equal(new Dictionary<Uri, string> { { new Uri("a://b.c"), "extension" } }, idefinition.Extensions.Value);
            Assert.Equal(Interaction.LongFillIn, idefinition.InteractionType);
            Assert.Equal(new Uri("http://www.example.com/more"), idefinition.MoreInfo);
            Assert.Equal(LanguageMap.EnglishUS("Long Fill-in"), idefinition.Name);
            Assert.Equal(new Uri("http://adlnet.gov/expapi/activities/cmi.interaction"), idefinition.Type);
        }
    }
}
