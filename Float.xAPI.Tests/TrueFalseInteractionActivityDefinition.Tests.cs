// <copyright file="TrueFalseInteractionActivityDefinition.Tests.cs" company="Float">
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
    public class TrueFalseInteractionActivityDefinitionTests : IInitializationTests<TrueFalseInteractionActivityDefinition>, IPropertyTests
    {
        [Fact]
        public TrueFalseInteractionActivityDefinition TestValidInit()
        {
            var def1 = new TrueFalseInteractionActivityDefinition(
                LanguageMap.EnglishUS("Appendix C"),
                LanguageMap.EnglishUS("Does the xAPI include the concept of statements?"),
                true);

            var def2 = new TrueFalseInteractionActivityDefinition(
                LanguageMap.EnglishUS("Appendix C"),
                LanguageMap.EnglishUS("Does the xAPI include the concept of statements?"),
                true,
                new Uri("http://example.com/more"));

            return new TrueFalseInteractionActivityDefinition(
                LanguageMap.EnglishUS("Appendix C"), // todo: name should be optional
                LanguageMap.EnglishUS("Does the xAPI include the concept of statements?"),
                true,
                new Uri("http://example.com/more"),
                new Dictionary<Uri, string> { { new Uri("http://example.com/ext"), "ext" } });
        }

        [Fact]
        public void TestInvalidInit()
        {
            Assert.Throws<ArgumentNullException>(() => new TrueFalseInteractionActivityDefinition(null, null, false, null));
            Assert.Throws<ArgumentNullException>(() => new TrueFalseInteractionActivityDefinition(LanguageMap.EnglishUS("name"), null, false, null));
            Assert.Throws<ArgumentException>(() => new TrueFalseInteractionActivityDefinition(LanguageMap.EnglishUS("name"), LanguageMap.EnglishUS("description"), false, new Uri("http://example.com"), new Dictionary<Uri, string> { }));
        }

        [Fact]
        public void TestProperties()
        {
            var definition = TestValidInit();
            Assert.Equal(new ResponsePattern(true), definition.CorrectResponsesPattern);
            Assert.Equal(LanguageMap.EnglishUS("Does the xAPI include the concept of statements?"), definition.Description);
            Assert.Equal(new Uri("http://example.com/ext"), definition.Extensions.Value.First().Key); // todo: avoid Value
            Assert.Equal("ext", definition.Extensions.Value.First().Value);
            Assert.Equal(Interaction.TrueFalse, definition.InteractionType);
            Assert.Equal(new Uri("http://example.com/more"), definition.MoreInfo);
            Assert.Equal(LanguageMap.EnglishUS("Appendix C"), definition.Name);
            Assert.Equal(new Uri("http://adlnet.gov/expapi/activities/cmi.interaction"), definition.Type);

            var idefinition = definition as IInteractionActivityDefinition;
            Assert.Equal(new ResponsePattern(true), idefinition.CorrectResponsesPattern);
            Assert.Equal(LanguageMap.EnglishUS("Does the xAPI include the concept of statements?"), idefinition.Description);
            Assert.Equal(new Uri("http://example.com/ext"), idefinition.Extensions.Value.First().Key); // todo: avoid Value
            Assert.Equal("ext", idefinition.Extensions.Value.First().Value);
            Assert.Equal(Interaction.TrueFalse, idefinition.InteractionType);
            Assert.Equal(new Uri("http://example.com/more"), idefinition.MoreInfo);
            Assert.Equal(LanguageMap.EnglishUS("Appendix C"), idefinition.Name);
            Assert.Equal(new Uri("http://adlnet.gov/expapi/activities/cmi.interaction"), idefinition.Type);
        }
    }
}
