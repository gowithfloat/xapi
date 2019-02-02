// <copyright file="ProfileId.Tests.cs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

using System;
using Float.xAPI.Resources.Documents;
using Xunit;

namespace Float.xAPI.Tests
{
    public class ProfileIdTests : IInitializationTests<ProfileId>, IEqualityTests
    {
        [Fact]
        public ProfileId TestValidInit()
        {
            return new ProfileId("profile-id");
        }

        [Fact]
        public void TestInvalidInit()
        {
            Assert.Throws<ArgumentException>(() => new ProfileId(null));
            Assert.Throws<ArgumentException>(() => new ProfileId(string.Empty));
            Assert.Throws<ArgumentException>(() => new ProfileId(" "));
        }

        [Fact]
        public void TestEquality()
        {
            var pid1 = new ProfileId("profile-id-1");
            var pid2 = new ProfileId("profile-id-1");
            AssertHelper.Equality(pid1, pid2, (a, b) => a == b);
        }

        [Fact]
        public void TestInequality()
        {
            var pid1 = new ProfileId("profile-id-1");
            var pid2 = new ProfileId("profile-id-2");
            AssertHelper.Inequality(pid1, pid2, (a, b) => a != b);
        }
    }
}
