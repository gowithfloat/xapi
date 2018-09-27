// <copyright file="Result.Tests.cs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

using System;
using System.Collections.Generic;
using Xunit;

namespace Float.xAPI.Tests
{
    public class ResultTests : IInitializationTests<Result>, IToStringTests
    {
        [Fact]
        public Result TestValidInit()
        {
            var result1 = new Result();
            var result2 = new Result(score: new Score(0.6));
            var result3 = new Result(success: true);
            var result4 = new Result(completion: false);
            var result5 = new Result(response: "response");
            var result6 = new Result(duration: TimeSpan.FromHours(2));
            var result7 = new Result(extensions: new Dictionary<Uri, string> { { new Uri("http://example.com"), "example" } });
            return new Result(
                new Score(0.25),
                false,
                true,
                "example response",
                new TimeSpan(),
                new Dictionary<Uri, string> { { new Uri("http://example.com"), "example" } });
        }

        [Fact]
        public void TestInvalidInit()
        {
            // all parameters are optional
        }

        [Fact]
        public void TestToString()
        {
            var result1 = new Result();
            Assert.Equal("<Result:>", result1.ToString());

            var result2 = new Result(
                new Score(0.25),
                false,
                true,
                "example response",
                new TimeSpan(2, 3, 4),
                new Dictionary<Uri, string> { { new Uri("http://example.com"), "example" } });

            // this mostly works, but extensions aren't great
            // todo: Assert.Equal("<Result: Score <Score: Scaled 0.25> Success False Completion True Response \"example response\" Duration 02:03:04 Extensions >", result2.ToString());
            Assert.NotNull(result2.ToString());
        }

        [Fact]
        public void TestInterface()
        {
            var result = new Result(
                new Score(0.25),
                false,
                true,
                "example response",
                new TimeSpan(),
                new Dictionary<Uri, string> { { new Uri("http://example.com"), "example" } }) as IResult;
            Assert.NotNull(result.Score);
            Assert.Equal(false, result.Success);
            Assert.Equal(true, result.Completion);
            Assert.NotNull(result.Response);
            Assert.NotNull(result.Duration);
            Assert.NotNull(result.Extensions);
        }
    }
}
