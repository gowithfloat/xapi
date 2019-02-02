// <copyright file="ActivityId.Tests.cs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

using Float.xAPI.Activities;
using Xunit;

namespace Float.xAPI.Tests
{
    public class ActivityIdTests : IEqualityTests
    {
        [Fact]
        public void TestEquality()
        {
            var vid1 = new ActivityId("https://gowithfloat.com/2018/12/looking-forward-four-2019-trends-for-elearning/");
            var vid2 = new ActivityId("https://gowithfloat.com/2018/12/looking-forward-four-2019-trends-for-elearning/");
            AssertHelper.Equality(vid1, vid2, (a, b) => a == b);
        }

        [Fact]
        public void TestInequality()
        {
            var vid1 = new ActivityId("https://gowithfloat.com/2019/01/top-6-things-we-are-looking-forward-to-at-atdtk/");
            var vid2 = new ActivityId("https://gowithfloat.com/2018/11/google-pixel-buds-gateway-language-barriers/");
            AssertHelper.Inequality(vid1, vid2, (a, b) => a != b);
        }
    }
}
