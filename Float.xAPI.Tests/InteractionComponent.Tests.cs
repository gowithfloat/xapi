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
    public class InteractionComponentTests : IInitializationTests<InteractionComponent>
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
            Assert.Throws<ArgumentException>(() => new InteractionComponent("id", new Dictionary<ILanguageTag, string>()));
        }
    }
}
