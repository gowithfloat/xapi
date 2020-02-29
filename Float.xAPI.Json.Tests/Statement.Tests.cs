// <copyright file="Statement.Tests.cs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

using System;
using System.Linq;
using System.Xml;
using Float.xAPI.Activities;
using Float.xAPI.Actor;
using Float.xAPI.Actor.Identifier;
using Xunit;
using static Float.xAPI.Json.Tests.TestHelpers;

namespace Float.xAPI.Json.Tests
{
    public class StatementTests
    {
        [Fact]
        public void TestSerialize()
        {

        }

        [Fact]
        public void TestDeserialize()
        {
            var statementJson = ReadFile("about-example-statement.json");
            var statement = Json.DeserializeStatement(statementJson);

            // id
            Assert.Equal(new Guid("2a41c918-b88b-4220-20a5-a4c32391a240"), statement.Id);

            // actor
            Assert.Equal("Gert Frobe", statement.Actor.Name);
            Assert.Equal(ObjectType.Agent, statement.Actor.ObjectType);
            Assert.IsType<Agent>(statement.Actor);
            Assert.IsType<Account>(((Agent)statement.Actor).IFI);
            Assert.Equal("http://example.adlnet.gov/", ((Account)((Agent)statement.Actor).IFI).HomePage.AbsoluteUri);
            Assert.Equal("1625378", ((Account)((Agent)statement.Actor).IFI).Name);

            // verb
            Assert.Equal("http://adlnet.gov/expapi/verbs/failed", statement.Verb.Id.Iri.AbsoluteUri);
            Assert.Equal("en-US", statement.Verb.Display.Keys.First().ToString());
            Assert.Equal("failed", statement.Verb.Display.Values.First());

            // object
            Assert.Equal(ObjectType.Activity, statement.Object.ObjectType);
            Assert.IsType<Activity>(statement.Object);
            Assert.Equal("https://example.adlnet.gov/AUidentifier", ((Activity)statement.Object).Id.Iri.AbsoluteUri);

            // result
            Assert.NotNull(statement.Result);
            Assert.Equal(0.65, statement.Result.Value.Score.Value.Scaled); // todo: avoid ".Value"
            Assert.Equal(65, statement.Result.Value.Score.Value.Raw);
            Assert.Equal(0, statement.Result.Value.Score.Value.Min);
            Assert.Equal(100, statement.Result.Value.Score.Value.Max);
            Assert.False(statement.Result.Value.Success.Value);
            Assert.Equal(XmlConvert.ToTimeSpan("PT30M"), statement.Result.Value.Duration.Value);
            Assert.Equal(new Uri("https://w3id.org/xapi/cmi5/result/extensions/progress"), statement.Result.Value.Extensions.Value.First().Key);
            Assert.Equal("100", statement.Result.Value.Extensions.Value.First().Value);
        }
    }
}
