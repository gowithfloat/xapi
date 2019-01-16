// <copyright file="PerformanceInteractionActivityDefinition.Tests.cs" company="Float">
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
    public class PerformanceInteractionActivityDefinitionTests : IInitializationTests<PerformanceInteractionActivityDefinition>, IPropertyTests
    {
        [Fact]
        public PerformanceInteractionActivityDefinition TestValidInit()
        {
            var steps = new List<IInteractionComponent>
            {
                new InteractionComponent("pong", LanguageMap.EnglishUS("Net pong matches won")),
                new InteractionComponent("dg", LanguageMap.EnglishUS("Strokes over par in disc golf at Liberty")),
                new InteractionComponent("lunch", LanguageMap.EnglishUS("Lunch having been eaten"))
            };

            var pairs = new CharacterStringPair(new Dictionary<string, ICharacterString>
            {
                { "pong", new CharacterStringNumeric(min: 1) },
                { "dg", new CharacterStringNumeric(max: 10) },
                { "lunch", new CharacterString(true) }
            });

            var def1 = new PerformanceInteractionActivityDefinition(
                LanguageMap.EnglishUS("Appendix C"),
                LanguageMap.EnglishUS("This interaction measures performance over a day of RS sports:"),
                new ResponsePattern(pairs),
                steps);

            var def2 = new PerformanceInteractionActivityDefinition(
                LanguageMap.EnglishUS("Appendix C"),
                LanguageMap.EnglishUS("This interaction measures performance over a day of RS sports:"),
                new ResponsePattern(pairs),
                steps,
                new Uri("http://example.com/more"));

            return new PerformanceInteractionActivityDefinition(
                LanguageMap.EnglishUS("Appendix C"),
                LanguageMap.EnglishUS("This interaction measures performance over a day of RS sports:"),
                new ResponsePattern(pairs),
                steps,
                new Uri("http://example.com/more"),
                new Dictionary<Uri, string> { { new Uri("http://example.com/ext"), "ext" } });
        }

        [Fact]
        public void TestInvalidInit()
        {
            Assert.Throws<ArgumentNullException>(() => new PerformanceInteractionActivityDefinition(null, null, null, null));
            Assert.Throws<ArgumentNullException>(() => new PerformanceInteractionActivityDefinition(LanguageMap.EnglishUS("name"), null, null, null));
            Assert.Throws<ArgumentNullException>(() => new PerformanceInteractionActivityDefinition(LanguageMap.EnglishUS("name"), LanguageMap.EnglishUS("description"), null, null));
            Assert.Throws<ArgumentNullException>(() => new PerformanceInteractionActivityDefinition(LanguageMap.EnglishUS("name"), LanguageMap.EnglishUS("description"), new ResponsePattern(new CharacterStringNumeric(4)), null));
            Assert.Throws<ArgumentException>(() => new PerformanceInteractionActivityDefinition(LanguageMap.EnglishUS("name"), LanguageMap.EnglishUS("description"), new ResponsePattern(new CharacterStringNumeric(4)), new List<IInteractionComponent> { }, new Uri("http://example.com")));
            Assert.Throws<ArgumentException>(() => new PerformanceInteractionActivityDefinition(LanguageMap.EnglishUS("name"), LanguageMap.EnglishUS("description"), new ResponsePattern(new CharacterStringNumeric(4)), new List<IInteractionComponent> { new InteractionComponent("id") }, new Uri("http://example.com"), new Dictionary<Uri, string> { }));
        }

        [Fact]
        public void TestPairToString()
        {
            // todo: this is the example given in the docs for interaction definitions
            // however, this seems to break from the format
            // for example, `1:` isn't a valid numeric response, but `1[:]` is
            // also, the pattern for `lunch` is omitted
            // we should figure out why this is weird
            var result = "pong[.]1:[,]dg[.]:10[,]lunch[.]";

            var cs2 = new CharacterStringPair(new Dictionary<string, ICharacterString>
            {
                { "pong", new CharacterStringNumeric(min: 1) },
                { "dg", new CharacterStringNumeric(max: 10) },
                { "lunch", new CharacterString(true) }
            });

            // Assert.Equal(result, cs2.ToString());
            Assert.True(true);
        }

        [Fact]
        public void TestProperties()
        {
            var definition = TestValidInit();
            Assert.Equal("[\"pong[.]1[:][,]dg[.][:]10[,]lunch[.]true\"]", definition.CorrectResponsesPattern.ToString());
            Assert.Equal(LanguageMap.EnglishUS("This interaction measures performance over a day of RS sports:"), definition.Description);
            Assert.Equal(new Uri("http://example.com/ext"), definition.Extensions.Value.First().Key); // todo: avoid Value
            Assert.Equal("ext", definition.Extensions.Value.First().Value);
            Assert.Equal(Interaction.Performance, definition.InteractionType);
            Assert.Equal(new Uri("http://example.com/more"), definition.MoreInfo);
            Assert.Equal(LanguageMap.EnglishUS("Appendix C"), definition.Name);
            Assert.Equal("pong", definition.Steps.First().Id);
            Assert.Equal(LanguageMap.EnglishUS("Net pong matches won"), definition.Steps.First().Description);
            Assert.Equal(new Uri("http://adlnet.gov/expapi/activities/cmi.interaction"), definition.Type);

            var idefinition = definition as IPerformanceInteractionActivityDefinition;
            Assert.Equal("[\"pong[.]1[:][,]dg[.][:]10[,]lunch[.]true\"]", idefinition.CorrectResponsesPattern.ToString());
            Assert.Equal(LanguageMap.EnglishUS("This interaction measures performance over a day of RS sports:"), idefinition.Description);
            Assert.Equal(new Uri("http://example.com/ext"), idefinition.Extensions.Value.First().Key); // todo: avoid Value
            Assert.Equal("ext", idefinition.Extensions.Value.First().Value);
            Assert.Equal(Interaction.Performance, idefinition.InteractionType);
            Assert.Equal(new Uri("http://example.com/more"), idefinition.MoreInfo);
            Assert.Equal(LanguageMap.EnglishUS("Appendix C"), idefinition.Name);
            Assert.Equal("pong", idefinition.Steps.First().Id);
            Assert.Equal(LanguageMap.EnglishUS("Net pong matches won"), idefinition.Steps.First().Description);
            Assert.Equal(new Uri("http://adlnet.gov/expapi/activities/cmi.interaction"), idefinition.Type);
        }
    }
}
