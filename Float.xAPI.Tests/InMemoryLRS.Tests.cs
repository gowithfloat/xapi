// <copyright file="InMemoryLRS.Tests.cs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

using System;
using System.Linq;
using Float.xAPI.Actor;
using Float.xAPI.Actor.Identifier;
using Xunit;
using static Float.xAPI.Tests.LRSTestHelper;

namespace Float.xAPI.Tests
{
    public class LRSTests
    {
        readonly Guid registration = GenerateGuid();
        readonly Guid statementId = GenerateGuid();

        [Fact]
        public void TestGetStatement()
        {
            var lrs = new InMemoryLRS();
            var statement = GenerateStatement(statementId);
            lrs.Statements.PutStatement(statement);

            var retrieved1 = lrs.Statements.GetStatement(statement.Id);
            Assert.Equal(statement.Id, retrieved1.Value.Id);

            var retrieved2 = lrs.Statements.GetStatement(GenerateGuid());
            Assert.Null(retrieved2);

            var ilrs = lrs as ILRS;

            var id2 = GenerateGuid();
            var statement2 = GenerateStatement(id2);
            ilrs.Statements.PutStatement(statement2);

            var retrieved3 = ilrs.Statements.GetStatement(statement.Id);
            Assert.Equal(id2, retrieved3.Value.Id);

            var retrieved4 = ilrs.Statements.GetStatement(GenerateGuid());
            Assert.Null(retrieved4);
        }

        [Fact]
        public void TestGetVoidedStatement()
        {
            var lrs = new InMemoryLRS();
            var statement = GenerateVoidingStatement();
            lrs.Statements.PutStatement(statement);

            var retrieved1 = lrs.Statements.GetVoidedStatement(statement.Id);
            Assert.Equal(statement.Id, retrieved1.Value.Id);

            var retrieved2 = lrs.Statements.GetStatement(statement.Id);
            Assert.Null(retrieved2);

            var ilrs = lrs as ILRS;
            var statement2 = GenerateVoidingStatement();

            var retrieved3 = ilrs.Statements.GetVoidedStatement(statement2.Id);
            Assert.Equal(statement2.Id, retrieved3.Value.Id);

            var retrieved4 = ilrs.Statements.GetStatement(statement2.Id);
            Assert.Null(retrieved4);
        }

        [Fact]
        public void TestGetStatementsByVerb()
        {
            var lrs = new InMemoryLRS();
            lrs.Statements.PutStatement(GenerateStatement(statementId));

            var retrieved1 = lrs.Statements.GetStatements(verbId: new Uri("http://example.com/verb"));
            Assert.Single(retrieved1.Statements);
            Assert.Null(retrieved1.More);

            var retrieved2 = lrs.Statements.GetStatements(verbId: new Uri("http://example.com/sent"));
            Assert.Empty(retrieved2.Statements);
            Assert.Null(retrieved2.More);

            var ilrs = lrs as ILRS;

            var retrieved3 = ilrs.Statements.GetStatements(verbId: new Uri("http://example.com/verb"));
            Assert.Single(retrieved3.Statements);
            Assert.Null(retrieved3.More);

            var retrieved4 = ilrs.Statements.GetStatements(verbId: new Uri("http://example.com/sent"));
            Assert.Empty(retrieved4.Statements);
            Assert.Null(retrieved4.More);
        }

        [Fact]
        public void TestGetStatementsByActor()
        {
            var lrs = new InMemoryLRS();
            lrs.Statements.PutStatement(GenerateStatement(statementId));

            var retrieved1 = lrs.Statements.GetStatements(actor: new Agent(new OpenID(new Uri("http://example.com/agent"))));
            Assert.Single(retrieved1.Statements);

            var retrieved2 = lrs.Statements.GetStatements(actor: new Agent(new OpenID(new Uri("http://example.com/agent/2"))));
            Assert.Empty(retrieved2.Statements);

            var ilrs = lrs as ILRS;
            var retrieved3 = ilrs.Statements.GetStatements(actor: new Agent(new OpenID(new Uri("http://example.com/agent"))));
            Assert.Single(retrieved3.Statements);

            var retrieved4 = ilrs.Statements.GetStatements(actor: new Agent(new OpenID(new Uri("http://example.com/agent/2"))));
            Assert.Empty(retrieved4.Statements);
        }

        [Fact]
        public void TestGetStatementsByActivity()
        {
            var lrs = new InMemoryLRS();
            lrs.Statements.PutStatement(GenerateStatement(statementId));

            var retrieved1 = lrs.Statements.GetStatements(activityId: new Uri("http://example.com/activity"));
            Assert.Single(retrieved1.Statements);

            var retrieved2 = lrs.Statements.GetStatements(activityId: new Uri("http://example.com/activity/2"));
            Assert.Empty(retrieved2.Statements);

            var ilrs = lrs as ILRS;
            var retrieved3 = ilrs.Statements.GetStatements(activityId: new Uri("http://example.com/activity"));
            Assert.Single(retrieved3.Statements);

            var retrieved4 = ilrs.Statements.GetStatements(activityId: new Uri("http://example.com/activity/2"));
            Assert.Empty(retrieved4.Statements);
        }

        [Fact]
        public void TestGetStatementsByRegistration()
        {
            var lrs = new InMemoryLRS();
            lrs.Statements.PutStatement(GenerateStatement(statementId));

            var retrieved1 = lrs.Statements.GetStatements(registration: registration);
            Assert.Single(retrieved1.Statements);

            // todo: fix this
            // var retrieved2 = lrs.GetStatements(registration: Guid.NewGuid());
            // Assert.Empty(retrieved2.Statements);
        }

        [Fact]
        public void TestPostStatements()
        {
            var lrs = new InMemoryLRS();
            var id1 = GenerateGuid();
            var id2 = GenerateGuid();
            var statements = GenerateStatements(id1, id2);
            var results = lrs.Statements.PostStatements(statements);
            Assert.Equal(id1, results.First());
            Assert.Equal(id2, results.Last());

            var ilrs = lrs as ILRS;
            var id3 = GenerateGuid();
            var id4 = GenerateGuid();
            var statements2 = GenerateStatements(id3, id4);
            var results2 = ilrs.Statements.PostStatements(statements2);
            Assert.Equal(id3, results2.First());
            Assert.Equal(id4, results2.Last());
        }
    }
}
