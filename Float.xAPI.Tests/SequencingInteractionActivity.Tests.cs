// <copyright file="SequencingInteractionActivity.Tests.cs" company="Float">
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
    public class SequencingInteractionActivityDefinitionTests : IInitializationTests<SequencingInteractionActivityDefinition>, IPropertyTests
    {
        [Fact]
        public SequencingInteractionActivityDefinition TestValidInit()
        {
            var sequence = new CharacterString(new List<string>
            {
                "tim",
                "mike",
                "ells",
                "ben",
            });

            var choices = new List<IInteractionComponent>
            {
                new InteractionComponent("tim", LanguageMap.EnglishUS("Tim")),
                new InteractionComponent("ben", LanguageMap.EnglishUS("Ben")),
                new InteractionComponent("ells", LanguageMap.EnglishUS("Ells")),
                new InteractionComponent("mike", LanguageMap.EnglishUS("Mike")),
            };

            var def1 = new SequencingInteractionActivityDefinition(
                LanguageMap.EnglishUS("Appendix C"),
                LanguageMap.EnglishUS("Order players by their pong ladder position:"),
                new ResponsePattern(sequence),
                choices);

            var def2 = new SequencingInteractionActivityDefinition(
                LanguageMap.EnglishUS("Appendix C"),
                LanguageMap.EnglishUS("Order players by their pong ladder position:"),
                new ResponsePattern(sequence),
                choices,
                new Uri("http://example.com/more"));

            return new SequencingInteractionActivityDefinition(
                LanguageMap.EnglishUS("Appendix C"),
                LanguageMap.EnglishUS("Order players by their pong ladder position:"),
                new ResponsePattern(sequence),
                choices,
                new Uri("http://example.com/more"),
                new Dictionary<Uri, string> { { new Uri("http://example.com/ext"), "ext" } });
        }

        [Fact]
        public void TestInvalidInit()
        {
            Assert.Throws<ArgumentNullException>(() => new SequencingInteractionActivityDefinition(null, null, null, null));
            Assert.Throws<ArgumentNullException>(() => new SequencingInteractionActivityDefinition(LanguageMap.EnglishUS("name"), null, null, null));
            Assert.Throws<ArgumentNullException>(() => new SequencingInteractionActivityDefinition(LanguageMap.EnglishUS("name"), LanguageMap.EnglishUS("description"), null, null));
            Assert.Throws<ArgumentNullException>(() => new SequencingInteractionActivityDefinition(LanguageMap.EnglishUS("name"), LanguageMap.EnglishUS("description"), new ResponsePattern(new CharacterStringNumeric(4)), null));
            Assert.Throws<ArgumentException>(() => new SequencingInteractionActivityDefinition(LanguageMap.EnglishUS("name"), LanguageMap.EnglishUS("description"), new ResponsePattern(new CharacterStringNumeric(4)), new List<IInteractionComponent> { }, new Uri("http://example.com")));
            Assert.Throws<ArgumentException>(() => new SequencingInteractionActivityDefinition(LanguageMap.EnglishUS("name"), LanguageMap.EnglishUS("description"), new ResponsePattern(new CharacterStringNumeric(4)), new List<IInteractionComponent> { new InteractionComponent("id") }, new Uri("http://example.com"), new Dictionary<Uri, string> { }));
        }

        [Fact]
        public void TestProperties()
        {
            var definition = TestValidInit();
            Assert.Equal("[\"tim[,]mike[,]ells[,]ben\"]", definition.CorrectResponsesPattern.ToString());
            Assert.Equal(LanguageMap.EnglishUS("Order players by their pong ladder position:"), definition.Description);
            Assert.Equal(new Uri("http://example.com/ext"), definition.Extensions.Value.First().Key); // todo: avoid Value
            Assert.Equal("ext", definition.Extensions.Value.First().Value);
            Assert.Equal(Interaction.Sequencing, definition.InteractionType);
            Assert.Equal(new Uri("http://example.com/more"), definition.MoreInfo);
            Assert.Equal(LanguageMap.EnglishUS("Appendix C"), definition.Name);
            Assert.Equal("tim", definition.Choices.First().Id);
            Assert.Equal(LanguageMap.EnglishUS("Tim"), definition.Choices.First().Description);
            Assert.Equal(new Uri("http://adlnet.gov/expapi/activities/cmi.interaction"), definition.Type);

            var idefinition = definition as ISequencingInteractionActivityDefinition;
            Assert.Equal("[\"tim[,]mike[,]ells[,]ben\"]", idefinition.CorrectResponsesPattern.ToString());
            Assert.Equal(LanguageMap.EnglishUS("Order players by their pong ladder position:"), idefinition.Description);
            Assert.Equal(new Uri("http://example.com/ext"), idefinition.Extensions.Value.First().Key); // todo: avoid Value
            Assert.Equal("ext", idefinition.Extensions.Value.First().Value);
            Assert.Equal(Interaction.Sequencing, idefinition.InteractionType);
            Assert.Equal(new Uri("http://example.com/more"), idefinition.MoreInfo);
            Assert.Equal(LanguageMap.EnglishUS("Appendix C"), idefinition.Name);
            Assert.Equal("tim", idefinition.Choices.First().Id);
            Assert.Equal(LanguageMap.EnglishUS("Tim"), idefinition.Choices.First().Description);
            Assert.Equal(new Uri("http://adlnet.gov/expapi/activities/cmi.interaction"), idefinition.Type);
        }
    }
}
