// <copyright file="InteractionComponent.Tests.cs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

using System;
using System.Collections.Generic;
using Float.xAPI.Activities.Definitions;
using Float.xAPI.Languages;
using Xunit;

namespace Float.xAPI.Tests
{
    public class InteractionComponentTests : IInitializationTests<InteractionComponent>, IEqualityTests
    {
        [Fact]
        public InteractionComponent TestValidInit()
        {
            var comp1 = new InteractionComponent("id");
            var comp2 = new InteractionComponent("id", LanguageMap.EnglishUS("description"));
            return comp2;
        }

        [Fact]
        public void TestInvalidInit()
        {
            Assert.Throws<ArgumentException>(() => new InteractionComponent(null));
            Assert.Throws<ArgumentException>(() => new InteractionComponent(string.Empty));
            Assert.Throws<ArgumentException>(() => new InteractionComponent(" "));
            Assert.Throws<ArgumentException>(() => new InteractionComponent("id", new LanguageMap(new Dictionary<ILanguageTag, string>())));
        }

        [Fact]
        public void TestEquality()
        {
            var comp1 = new InteractionComponent("id1");
            var comp2 = new InteractionComponent("id1");
            AssertHelper.Equality<InteractionComponent, IInteractionComponent>(comp1, comp1, (a, b) => a == b);
        }

        [Fact]
        public void TestInequality()
        {
            var comp1 = new InteractionComponent("id1");
            var comp2 = new InteractionComponent("id2");
            AssertHelper.Inequality<InteractionComponent, IInteractionComponent>(comp1, comp2, (a, b) => a != b);
        }

        [Fact]
        public void TestProperties()
        {
            var comp = new InteractionComponent("likert_0", LanguageMap.EnglishUS("It's OK"));
            Assert.Equal("likert_0", comp.Id);
            Assert.Equal(new LanguageMap(new LanguageTag(Language.English, Region.UnitedStates), "It's OK"), comp.Description);

            var icomp = comp as IInteractionComponent;
            Assert.Equal("likert_0", icomp.Id);
            Assert.Equal(new LanguageMap(new LanguageTag(Language.English, Region.UnitedStates), "It's OK"), icomp.Description);
        }
    }
}
