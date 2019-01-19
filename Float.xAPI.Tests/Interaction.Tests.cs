// <copyright file="Interaction.Tests.cs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

using Float.xAPI.Activities;
using Xunit;

namespace Float.xAPI.Tests
{
    public class InteractionTests : IEqualityTests
    {
        [Fact]
        public void TestEquality()
        {
            AssertHelper.Equality(Interaction.Choice, Interaction.Choice);
            AssertHelper.Equality(Interaction.FillIn, Interaction.FillIn);
            AssertHelper.Equality(Interaction.Likert, Interaction.Likert);
            AssertHelper.Equality(Interaction.LongFillIn, Interaction.LongFillIn);
            AssertHelper.Equality(Interaction.Matching, Interaction.Matching);
            AssertHelper.Equality(Interaction.Numeric, Interaction.Numeric);
            AssertHelper.Equality(Interaction.Other, Interaction.Other);
            AssertHelper.Equality(Interaction.Performance, Interaction.Performance);
            AssertHelper.Equality(Interaction.Sequencing, Interaction.Sequencing);
            AssertHelper.Equality(Interaction.TrueFalse, Interaction.TrueFalse);
        }

        [Fact]
        public void TestInequality()
        {
            AssertHelper.Inequality(Interaction.Choice, Interaction.FillIn);
            AssertHelper.Inequality(Interaction.FillIn, Interaction.Likert);
            AssertHelper.Inequality(Interaction.Likert, Interaction.LongFillIn);
            AssertHelper.Inequality(Interaction.LongFillIn, Interaction.Matching);
            AssertHelper.Inequality(Interaction.Matching, Interaction.Numeric);
            AssertHelper.Inequality(Interaction.Numeric, Interaction.Other);
            AssertHelper.Inequality(Interaction.Other, Interaction.Performance);
            AssertHelper.Inequality(Interaction.Performance, Interaction.Sequencing);
            AssertHelper.Inequality(Interaction.Sequencing, Interaction.TrueFalse);
            AssertHelper.Inequality(Interaction.TrueFalse, Interaction.Choice);
        }

        [Fact]
        public void TestType()
        {
            Assert.True(Interaction.Choice is Interaction);
        }
    }
}
