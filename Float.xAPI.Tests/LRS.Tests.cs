// <copyright file="LRS.Tests.cs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

using System;
using Float.xAPI.Activities;
using Float.xAPI.Actor;
using Float.xAPI.Actor.Identifier;
using Float.xAPI.Languages;
using Xunit;

namespace Float.xAPI.Tests
{
    public class LRSTests
    {
        readonly Guid Registration = Guid.NewGuid();
        readonly Guid StatementId = Guid.NewGuid();

        [Fact]
        public void TestGetStatement()
        {
            var lrs = new InMemoryLRS();
            var statement = GenerateStatement();
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
            lrs.PutStatement(GenerateStatement());

            var retrieved = lrs.GetStatements(verbId: new Uri("http://example.com/verb"));
            Assert.Single(retrieved.Statements);
        }

        [Fact]
        public void TestGetStatementsByActor()
        {
            var lrs = new InMemoryLRS();
            lrs.PutStatement(GenerateStatement());

            var retrieved = lrs.GetStatements(actor: new Agent(new OpenID(new Uri("http://example.com/agent"))));
            Assert.Single(retrieved.Statements);
        }

        [Fact]
        public void TestGetStatementsByActivity()
        {
            var lrs = new InMemoryLRS();
            lrs.PutStatement(GenerateStatement());

            var retrieved = lrs.GetStatements(activityId: new Uri("http://example.com/activity"));
            Assert.Single(retrieved.Statements);
        }

        [Fact]
        public void TestGetStatementsByRegistration()
        {
            var lrs = new InMemoryLRS();
            lrs.PutStatement(GenerateStatement());

            var retrieved = lrs.GetStatements(registration: Registration);
            Assert.Single(retrieved.Statements);
        }

        IStatement GenerateVoidingStatement()
        {
            return new Statement
            (
                GenerateActor(),
                Verb.Voided,
                GenerateStatementRef()
            );
        }

        IStatement GenerateStatement()
        {
            return new Statement
            (
                GenerateActor(),
                GenerateVerb(),
                GenerateActivity(),
                StatementId
            );
        }

        IStatementReference GenerateStatementRef()
        {
            return new StatementReference
            (
                Guid.NewGuid()
            );
        }

        IIdentifiedActor GenerateActor()
        {
            return new Agent
            (
                new OpenID
                (
                    new Uri("http://example.com/agent")
                )
            );
        }

        IVerb GenerateVerb()
        {
            return new Verb
            (
                new Uri("http://example.com/verb"),
                LanguageMap.EnglishUS("verb")
            );
        }

        IActivity GenerateActivity()
        {
            return new Activity
            (
                new Uri("http://example.com/activity")
            );
        }

        IContext GenerateContext()
        {
            return new Context
            (
                Registration
            );
        }
    }
}
