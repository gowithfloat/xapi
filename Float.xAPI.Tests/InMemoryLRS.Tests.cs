// <copyright file="InMemoryLRS.Tests.cs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

using System;
using System.Linq;
using Float.xAPI.Activities;
using Float.xAPI.Actors;
using Float.xAPI.Actors.Identifier;
using Xunit;
using static Float.xAPI.Tests.LRSTestHelper;

namespace Float.xAPI.Tests
{
    public class InMemoryLRSTests
    {
        readonly InMemoryLRS lrs;
        readonly ILRS ilrs;

        public InMemoryLRSTests()
        {
            lrs = new InMemoryLRS();
            ilrs = lrs as ILRS;
        }

        //// IStatementResource

        [Fact]
        public void TestGetStatement()
        {
            var id1 = GenerateGuid();
            lrs.Statements.PutStatement(GenerateStatement(id1));

            var retrieved1 = lrs.Statements.GetStatement(id1);
            Assert.Equal(id1, retrieved1.Value.Id);

            var retrieved2 = lrs.Statements.GetStatement(GenerateGuid());
            Assert.Null(retrieved2);

            var id2 = GenerateGuid();
            ilrs.Statements.PutStatement(GenerateStatement(id2));

            var retrieved3 = ilrs.Statements.GetStatement(id2);
            Assert.Equal(id2, retrieved3.Value.Id);

            var retrieved4 = ilrs.Statements.GetStatement(GenerateGuid());
            Assert.Null(retrieved4);
        }

        [Fact]
        public void TestGetVoidedStatement()
        {
            var sid1 = GenerateGuid();
            lrs.Statements.PutStatement(GenerateStatement(sid1));
            lrs.Statements.PutStatement(GenerateVoidingStatement(sid1));

            var retrieved1 = lrs.Statements.GetVoidedStatement(sid1);
            Assert.Equal(sid1, retrieved1.Value.Id);

            var retrieved2 = lrs.Statements.GetStatement(sid1);
            Assert.Null(retrieved2);

            var sid2 = GenerateGuid();
            ilrs.Statements.PutStatement(GenerateStatement(sid2));
            ilrs.Statements.PutStatement(GenerateVoidingStatement(sid2));

            var retrieved3 = ilrs.Statements.GetVoidedStatement(sid2);
            Assert.Equal(sid2, retrieved3.Value.Id);

            var retrieved4 = ilrs.Statements.GetStatement(sid2);
            Assert.Null(retrieved4);
        }

        [Fact]
        public void TestGetStatementsByVerb()
        {
            lrs.Statements.PutStatement(GenerateStatement(GenerateGuid()));

            var retrieved1 = lrs.Statements.GetStatements(verbId: new VerbId("http://example.com/verb"));
            Assert.Single(retrieved1.Statements);
            Assert.Null(retrieved1.More);

            var retrieved2 = lrs.Statements.GetStatements(verbId: new VerbId("http://example.com/sent"));
            Assert.Empty(retrieved2.Statements);
            Assert.Null(retrieved2.More);

            var retrieved3 = ilrs.Statements.GetStatements(verbId: new VerbId("http://example.com/verb"));
            Assert.Single(retrieved3.Statements);
            Assert.Null(retrieved3.More);

            var retrieved4 = ilrs.Statements.GetStatements(verbId: new VerbId("http://example.com/sent"));
            Assert.Empty(retrieved4.Statements);
            Assert.Null(retrieved4.More);
        }

        [Fact]
        public void TestGetStatementsByActor()
        {
            lrs.Statements.PutStatement(GenerateStatement(GenerateGuid()));

            var retrieved1 = lrs.Statements.GetStatements(actor: new Agent(new OpenID(new Uri("http://example.com/agent"))));
            Assert.Single(retrieved1.Statements);

            var retrieved2 = lrs.Statements.GetStatements(actor: new Agent(new OpenID(new Uri("http://example.com/agent/2"))));
            Assert.Empty(retrieved2.Statements);

            var retrieved3 = ilrs.Statements.GetStatements(actor: new Agent(new OpenID(new Uri("http://example.com/agent"))));
            Assert.Single(retrieved3.Statements);

            var retrieved4 = ilrs.Statements.GetStatements(actor: new Agent(new OpenID(new Uri("http://example.com/agent/2"))));
            Assert.Empty(retrieved4.Statements);
        }

        [Fact]
        public void TestGetStatementsByActivity()
        {
            lrs.Statements.PutStatement(GenerateStatement(GenerateGuid()));

            var retrieved1 = lrs.Statements.GetStatements(activityId: new ActivityId("http://example.com/activity"));
            Assert.Single(retrieved1.Statements);

            var retrieved2 = lrs.Statements.GetStatements(activityId: new ActivityId("http://example.com/activity/2"));
            Assert.Empty(retrieved2.Statements);

            var retrieved3 = ilrs.Statements.GetStatements(activityId: new ActivityId("http://example.com/activity"));
            Assert.Single(retrieved3.Statements);

            var retrieved4 = ilrs.Statements.GetStatements(activityId: new ActivityId("http://example.com/activity/2"));
            Assert.Empty(retrieved4.Statements);
        }

        [Fact]
        public void TestGetStatementsByRegistration()
        {
            lrs.Statements.PutStatement(GenerateStatement(GenerateGuid()));

            var retrieved1 = lrs.Statements.GetStatements(registration: GenerateGuid());
            Assert.Single(retrieved1.Statements);

            // todo: fix this
            // var retrieved2 = lrs.GetStatements(registration: Guid.NewGuid());
            // Assert.Empty(retrieved2.Statements);
        }

        [Fact]
        public void TestPostStatements()
        {
            var id1 = GenerateGuid();
            var id2 = GenerateGuid();
            var statements = GenerateStatements(id1, id2);
            var results = lrs.Statements.PostStatements(statements);
            Assert.Equal(id1, results.First());
            Assert.Equal(id2, results.Last());

            var id3 = GenerateGuid();
            var id4 = GenerateGuid();
            var statements2 = GenerateStatements(id3, id4);
            var results2 = ilrs.Statements.PostStatements(statements2);
            Assert.Equal(id3, results2.First());
            Assert.Equal(id4, results2.Last());
        }

        //// IStateResource

        [Fact]
        public void TestPutStateDocument()
        {
            var doc1 = GenerateDocument();
            var sid1 = GenerateStateId("sid1");
            var aid1 = GenerateActivityId("aid1");
            var agent1 = GenerateAgent("agent1");
            lrs.Activities.State.PutStateDocument(doc1, sid1, aid1, agent1);

            var doc2 = GenerateDocument();
            var sid2 = GenerateStateId("sid2");
            var aid2 = GenerateActivityId("aid2");
            var agent2 = GenerateAgent("agent2");
            ilrs.Activities.State.PutStateDocument(doc2, sid2, aid2, agent2);
        }

        [Fact]
        public void TestDeleteStateDocument()
        {
            var doc1 = GenerateDocument();
            var sid1 = GenerateStateId();
            var aid1 = GenerateActivityId();
            var agent1 = GenerateAgent();
            lrs.Activities.State.PutStateDocument(doc1, sid1, aid1, agent1);

            var retrievedDoc1 = lrs.Activities.State.GetStateDocument(sid1, aid1, agent1);
            Assert.Equal(doc1, retrievedDoc1.Value); // todo: remove Value

            lrs.Activities.State.DeleteStateDocument(sid1, aid1, agent1);

            var retrievedDoc2 = lrs.Activities.State.GetStateDocument(sid1, aid1, agent1);
            Assert.Null(retrievedDoc2);
        }
    }
}
