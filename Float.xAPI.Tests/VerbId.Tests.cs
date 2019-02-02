// <copyright file="VerbId.Tests.cs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

using Xunit;

namespace Float.xAPI.Tests
{
    public class VerbIdTests : IEqualityTests
    {
        [Fact]
        public void TestEquality()
        {
            var vid1 = new VerbId("http://adlnet.gov/expapi/verbs/experienced");
            var vid2 = new VerbId("http://adlnet.gov/expapi/verbs/experienced");
            AssertHelper.Equality(vid1, vid2, (a, b) => a == b);
        }

        [Fact]
        public void TestInequality()
        {
            var vid1 = new VerbId("http://activitystrea.ms/schema/1.0/acknowledge");
            var vid2 = new VerbId("http://id.tincanapi.com/verb/mentored");
            AssertHelper.Inequality(vid1, vid2, (a, b) => a != b);
        }
    }
}
