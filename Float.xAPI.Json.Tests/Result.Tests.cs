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

        [Fact]
        public void TestDeserializeEmpty()
        {
            var result = Deserialize.ParseResult("{}").Value;
            Assert.Null(result.Completion);
            Assert.Null(result.Duration);
            Assert.Null(result.Extensions);
            Assert.Null(result.Response);
            Assert.Null(result.Score);
            Assert.Null(result.Success);
        }

        [Fact]
        public void TestDeserializeMinimal()
        {
            var result = Deserialize.ParseResult("{\"score\":{\"scaled\":0.23}}").Value;
            Assert.Null(result.Completion);
            Assert.Null(result.Duration);
            Assert.Null(result.Extensions);
            Assert.Null(result.Response);
            Assert.NotNull(result.Score);
            Assert.Equal(0.23, result.Score.Value.Scaled);
            Assert.Null(result.Score.Value.Max);
            Assert.Null(result.Score.Value.Min);
            Assert.Null(result.Score.Value.Raw);
            Assert.Null(result.Success);
        }

        [Fact]
        public void TestDeserializeMaximal()
        {
            var result = Deserialize.ParseResult("{\"score\":{\"scaled\":0.74,\"raw\":37,\"min\":0,\"max\":50},\"success\":true,\"completion\":false,\"duration\":\"PT1H13M17S\"}").Value;
            Assert.True(result.Success.Value);
            Assert.False(result.Completion.Value);
            Assert.Equal(1, result.Duration.Value.Hours);
            Assert.Equal(13, result.Duration.Value.Minutes);
            Assert.Equal(17, result.Duration.Value.Seconds);
            Assert.Equal(0.74, result.Score.Value.Scaled);
            Assert.Equal(37, result.Score.Value.Raw);
            Assert.Equal(0, result.Score.Value.Min);
            Assert.Equal(50, result.Score.Value.Max);
        }
    }
}
