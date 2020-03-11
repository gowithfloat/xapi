// <copyright file="Result.Tests.cs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>


using System;
using Float.xAPI.Statements;
using Xunit;

namespace Float.xAPI.Json.Tests
{
    public class ResultTests
    {
        [Fact]
        public void TestSerializeEmpty()
        {
            var result = new Result();
            var json = Serialize.Result(result);
            Assert.Equal("{}", json);
        }

        [Fact]
        public void TestSerializeMinimal()
        {
            var score = new Score(0.23);
            var result = new Result(score);
            var json = Serialize.Result(result);
            Assert.Equal("{\"score\":{\"scaled\":0.23}}", json);
        }

        [Fact]
        public void TestSerializeMaximal()
        {
            var score = new Score(37, 0, 50);
            var result = new Result(score, true, false, "response", new TimeSpan(1, 13, 17));
            var json = Serialize.Result(result);
            Assert.Equal("{\"score\":{\"scaled\":0.74,\"raw\":37,\"min\":0,\"max\":50},\"success\":true,\"completion\":false,\"duration\":\"PT1H13M17S\"}", json);
        }
    }
}
