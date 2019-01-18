// <copyright file="InMemoryLRS.Tests.cs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

using System;
using Float.xAPI.Actor;
using Float.xAPI.Actor.Identifier;
using Xunit;
using static Float.xAPI.Tests.LRSTestHelper;

namespace Float.xAPI.Tests
{
    public class LRSTests
    {
        readonly Guid registration = Guid.NewGuid();
        readonly Guid statementId = Guid.NewGuid();

        [Fact]
        public void TestGetStatement()
        {
            var lrs = new InMemoryLRS();
            var statement = GenerateStatement(statementId);
            lrs.PutStatement(statement);

            var retrieved1 = lrs.GetStatement(statement.Id);
            Assert.Equal(statement.Id, retrieved1.Value.Id);

            var retrieved2 = lrs.GetStatement(Guid.NewGuid());
            Assert.Null(retrieved2);
        }

        [Fact]
        public void TestGetVoidedStatement()
        {
            var lrs = new InMemoryLRS();
            var statement = GenerateVoidingStatement();
            lrs.PutStatement(statement);

            var retrieved1 = lrs.GetVoidedStatement(statement.Id);
            Assert.Equal(statement.Id, retrieved1.Value.Id);

            var retrieved2 = lrs.GetStatement(statement.Id);
            Assert.Null(retrieved2);
        }

        [Fact]
        public void TestGetStatementsByVerb()
        {
            var lrs = new InMemoryLRS();
            lrs.PutStatement(GenerateStatement(statementId));

            var retrieved1 = lrs.GetStatements(verbId: new Uri("http://example.com/verb"));
            Assert.Single(retrieved1.Statements);
            Assert.Null(retrieved1.More);

            var retrieved2 = lrs.GetStatements(verbId: new Uri("http://example.com/sent"));
            Assert.Empty(retrieved2.Statements);
            Assert.Null(retrieved2.More);
        }

        [Fact]
        public void TestGetStatementsByActor()
        {
            var lrs = new InMemoryLRS();
            lrs.PutStatement(GenerateStatement(statementId));

            var retrieved1 = lrs.GetStatements(actor: new Agent(new OpenID(new Uri("http://example.com/agent"))));
            Assert.Single(retrieved1.Statements);

            var retrieved2 = lrs.GetStatements(actor: new Agent(new OpenID(new Uri("http://example.com/agent/2"))));
            Assert.Empty(retrieved2.Statements);
        }

        [Fact]
        public void TestGetStatementsByActivity()
        {
            var lrs = new InMemoryLRS();
            lrs.PutStatement(GenerateStatement(statementId));

            var retrieved1 = lrs.GetStatements(activityId: new Uri("http://example.com/activity"));
            Assert.Single(retrieved1.Statements);

            var retrieved2 = lrs.GetStatements(activityId: new Uri("http://example.com/activity/2"));
            Assert.Empty(retrieved2.Statements);
        }

        [Fact]
        public void TestGetStatementsByRegistration()
        {
            var lrs = new InMemoryLRS();
            lrs.PutStatement(GenerateStatement(statementId));

            var retrieved1 = lrs.GetStatements(registration: registration);
            Assert.Single(retrieved1.Statements);

            // todo: fix this
            // var retrieved2 = lrs.GetStatements(registration: Guid.NewGuid());
            // Assert.Empty(retrieved2.Statements);
        }
    }
}
