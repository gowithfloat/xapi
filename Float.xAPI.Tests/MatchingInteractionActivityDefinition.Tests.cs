﻿// <copyright file="MatchingInteractionActivityDefinition.Tests.cs" company="Float">
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
    public class MatchingInteractionActivityDefinitionTests : IInitializationTests<MatchingInteractionActivityDefinition>
    {
        [Fact]
        public MatchingInteractionActivityDefinition TestValidInit()
        {
            var pairs = new CharacterStringPair(new Dictionary<string, string>
            {
                { "ben", "3" },
                { "chris", "2" },
                { "troy", "4" },
                { "freddie", "1" }
            });
            var source = new List<IInteractionComponent>
            {
                new InteractionComponent("ben", LanguageMap.EnglishUS("Ben")),
                new InteractionComponent("chris", LanguageMap.EnglishUS("Chris")),
                new InteractionComponent("troy", LanguageMap.EnglishUS("Troy")),
                new InteractionComponent("freddie", LanguageMap.EnglishUS("Freddie"))
            };
            var target = new List<IInteractionComponent>
            {
                new InteractionComponent("1", LanguageMap.EnglishUS("Swift Kick in the Grass")),
                new InteractionComponent("2", LanguageMap.EnglishUS("We got Runs")),
                new InteractionComponent("3", LanguageMap.EnglishUS("Duck")),
                new InteractionComponent("4", LanguageMap.EnglishUS("Van Delay Industries"))
            };
            var definition1 = new MatchingInteractionActivityDefinition(
                LanguageMap.EnglishUS("Long Fill-in"),
                LanguageMap.EnglishUS("Match these people to their kickball team:"),
                new ResponsePattern(pairs),
                source,
                target);
            var definition2 = new MatchingInteractionActivityDefinition(
                LanguageMap.EnglishUS("Long Fill-in"),
                LanguageMap.EnglishUS("Match these people to their kickball team:"),
                new ResponsePattern(pairs),
                source,
                target,
                new Uri("http://www.example.com/more"));
            return new MatchingInteractionActivityDefinition(
                LanguageMap.EnglishUS("Long Fill-in"),
                LanguageMap.EnglishUS("Match these people to their kickball team:"),
                new ResponsePattern(pairs),
                source,
                target,
                new Uri("http://www.example.com/more"),
                new Dictionary<Uri, string> { { new Uri("http://www.example.com/ext"), "ext" } });
        }

        [Fact]
        public void TestInvalidInit()
        {
            Assert.Throws<ArgumentNullException>(() => new MatchingInteractionActivityDefinition(null, null, null, null, null));
            Assert.Throws<ArgumentNullException>(() => new MatchingInteractionActivityDefinition(LanguageMap.EnglishUS("a"), null, null, null, null));
            Assert.Throws<ArgumentNullException>(() => new MatchingInteractionActivityDefinition(LanguageMap.EnglishUS("a"), LanguageMap.EnglishUS("b"), new ResponsePattern("a"), null, null));
            Assert.Throws<ArgumentException>(() => new MatchingInteractionActivityDefinition(LanguageMap.EnglishUS("a"), LanguageMap.EnglishUS("b"), new ResponsePattern("a"), new List<IInteractionComponent> { }, null));
            Assert.Throws<ArgumentNullException>(() => new MatchingInteractionActivityDefinition(LanguageMap.EnglishUS("a"), LanguageMap.EnglishUS("b"), new ResponsePattern("a"), new List<IInteractionComponent> { new InteractionComponent("id") }, null));
            Assert.Throws<ArgumentException>(() => new MatchingInteractionActivityDefinition(LanguageMap.EnglishUS("a"), LanguageMap.EnglishUS("b"), new ResponsePattern("a"), new List<IInteractionComponent> { new InteractionComponent("id") }, new List<IInteractionComponent> { }));
        }

        [Fact]
        public void TestProperties()
        {
            var pairs = new CharacterStringPair(new Dictionary<string, string>
            {
                { "ben", "3" },
                { "chris", "2" },
                { "troy", "4" },
                { "freddie", "1" }
            });
            var source = new List<IInteractionComponent>
            {
                new InteractionComponent("ben", LanguageMap.EnglishUS("Ben")),
                new InteractionComponent("chris", LanguageMap.EnglishUS("Chris")),
                new InteractionComponent("troy", LanguageMap.EnglishUS("Troy")),
                new InteractionComponent("freddie", LanguageMap.EnglishUS("Freddie"))
            };
            var target = new List<IInteractionComponent>
            {
                new InteractionComponent("1", LanguageMap.EnglishUS("Swift Kick in the Grass")),
                new InteractionComponent("2", LanguageMap.EnglishUS("We got Runs")),
                new InteractionComponent("3", LanguageMap.EnglishUS("Duck")),
                new InteractionComponent("4", LanguageMap.EnglishUS("Van Delay Industries"))
            };
            var extensions = new Dictionary<Uri, string> { { new Uri("http://www.example.com/ext"), "ext" } };
            var definition = new MatchingInteractionActivityDefinition(
                LanguageMap.EnglishUS("Long Fill-in"),
                LanguageMap.EnglishUS("Match these people to their kickball team:"),
                new ResponsePattern(pairs),
                source,
                target,
                new Uri("http://www.example.com/more"),
                extensions);
            Assert.Equal(new ResponsePattern(pairs), definition.CorrectResponsesPattern);
            Assert.Equal(LanguageMap.EnglishUS("Match these people to their kickball team:"), definition.Description);
            Assert.Equal(extensions, definition.Extensions);
            Assert.Equal(Interaction.Matching, definition.InteractionType);
            Assert.Equal(new Uri("http://www.example.com/more"), definition.MoreInfo);
            Assert.Equal(LanguageMap.EnglishUS("Long Fill-in"), definition.Name);
            Assert.Equal(source, definition.Source);
            Assert.Equal(target, definition.Target);
            Assert.Equal(new Uri("http://adlnet.gov/expapi/activities/cmi.interaction"), definition.Type);

            var idefinition = definition as IMatchingInteractionActivityDefinition;
            Assert.Equal(new ResponsePattern(pairs), idefinition.CorrectResponsesPattern);
            Assert.Equal(LanguageMap.EnglishUS("Match these people to their kickball team:"), idefinition.Description);
            Assert.Equal(extensions, idefinition.Extensions);
            Assert.Equal(Interaction.Matching, idefinition.InteractionType);
            Assert.Equal(new Uri("http://www.example.com/more"), idefinition.MoreInfo);
            Assert.Equal(LanguageMap.EnglishUS("Long Fill-in"), idefinition.Name);
            Assert.Equal(source, idefinition.Source);
            Assert.Equal(target, idefinition.Target);
            Assert.Equal(new Uri("http://adlnet.gov/expapi/activities/cmi.interaction"), idefinition.Type);
        }
    }
}