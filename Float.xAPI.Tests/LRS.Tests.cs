// <copyright file="LRS.Tests.cs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

using System;
using Float.xAPI.Activities;
using Float.xAPI.Actor;
using Float.xAPI.Actor.Identifier;
using Float.xAPI.Languages;
using Float.xAPI.Resources;
using Xunit;

namespace Float.xAPI.Tests
{
    public class LRSTests
    {
        [Fact]
        public void TestInit()
        {
            var lrs = new InMemoryLRS();
            var statement = GetStatement();
            lrs.PutStatement(statement);

            var retrieved = lrs.GetStatement(statement.Id, StatementResultFormat.Exact, false);
            Assert.Equal(statement.Id, retrieved.Id);

            var retrieved2 = lrs.GetStatements(verb: new Uri("http://example.com/verb"));
            Assert.Single(retrieved2.Statements);
        }

        IStatement GetStatement()
        {
            return new Statement
            (
                new Agent
                (
                    new OpenID
                    (
                        new Uri("http://example.com/agent")
                    )
                ),
                new Verb
                (
                    new Uri("http://example.com/verb"),
                    LanguageMap.EnglishUS("verb")
                ),
                new Activity
                (
                    new Uri("http://example.com/activity")
                )
            );
        }
    }
}
