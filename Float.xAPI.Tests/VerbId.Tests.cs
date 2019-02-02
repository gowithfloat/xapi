// <copyright file="VerbId.Tests.cs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

using System;
using Xunit;

namespace Float.xAPI.Tests
{
    public class VerbIdTests : IInitializationTests<VerbId>, IEqualityTests
    {
        [Fact]
        public VerbId TestValidInit()
        {
            var vid1 = new VerbId("http://activitystrea.ms/schema/1.0/win");
            return new VerbId(new Uri("http://activitystrea.ms/schema/1.0/make-friend"));
        }

        [Fact]
        public void TestInvalidInit()
        {
            Assert.Throws<UriFormatException>(() => new VerbId(string.Empty));
            Assert.Throws<UriFormatException>(() => new VerbId(" "));
            Assert.Throws<UriFormatException>(() => new VerbId("htp/:/missing.slash"));
            Assert.Throws<UriFormatException>(() => new VerbId("gowithfloat.com/not-absolute"));
            Assert.Throws<UriFormatException>(() => new VerbId(new Uri(string.Empty)));
            Assert.Throws<UriFormatException>(() => new VerbId(new Uri("ftp//missing")));
            Assert.Throws<UriFormatException>(() => new VerbId(new Uri("invalid-uri")));
        }

        [Fact]
        public void TestEquality()
        {
            var vid1 = new VerbId("http://adlnet.gov/expapi/verbs/experienced");
            var vid2 = new VerbId(new Uri("http://adlnet.gov/expapi/verbs/experienced"));
            AssertHelper.Equality(vid1, vid2, (a, b) => a == b);
        }

        [Fact]
        public void TestInequality()
        {
            var vid1 = new VerbId("http://activitystrea.ms/schema/1.0/acknowledge");
            var vid2 = new VerbId(new Uri("http://id.tincanapi.com/verb/mentored"));
            AssertHelper.Inequality(vid1, vid2, (a, b) => a != b);
        }
    }
}
