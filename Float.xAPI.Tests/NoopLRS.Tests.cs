// <copyright file="NoopLRS.Tests.cs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

using System;
using System.Collections.Generic;
using Xunit;
using static Float.xAPI.Tests.LRSTestHelper;

namespace Float.xAPI.Tests
{
    public class NoopLRSTests
    {
        readonly ILRS lrs = new NoopLRS();

        [Fact]
        public void TestPutStatement()
        {
            lrs.Statements.PutStatement(GenerateStatement(Guid.NewGuid()));
        }

        [Fact]
        public void TestPostStatement()
        {
            lrs.Statements.PostStatements(new List<IStatement>
            {
                GenerateStatement(GenerateGuid())
            });
        }

        [Fact]
        public void TestGetStatement()
        {
            lrs.Statements.GetStatement(GenerateGuid());
        }

        [Fact]
        public void TestGetVoidedStatement()
        {
            lrs.Statements.GetVoidedStatement(GenerateGuid());
        }

        [Fact]
        public void TestGetStatements()
        {
            lrs.Statements.GetStatements();
        }

        [Fact]
        public void TestGetActivity()
        {
            lrs.Activities.GetActivity(GenerateUri("activity"));
        }

        [Fact]
        public void TestGetPerson()
        {
            lrs.Agents.GetPerson(GenerateAgent());
        }

        [Fact]
        public void TestPutStateDocument()
        {
            lrs.Activities.State.PutStateDocument(GenerateDocument());
        }

        [Fact]
        public void TestDeleteStateDocument()
        {
            lrs.Activities.State.DeleteStateDocument(GenerateStateId());
        }

        [Fact]
        public void TestDeleteStateDocuments()
        {
            lrs.Activities.State.DeleteStateDocuments(GenerateActivityId(), GenerateAgent());
        }

        [Fact]
        public void TestGetStateDocument()
        {
            lrs.Activities.State.GetStateDocument(GenerateStateId(), GenerateActivityId(), GenerateAgent());
        }

        [Fact]
        public void TestGetStateDocuments()
        {
            lrs.Activities.State.GetStateDocuments(GenerateActivityId(), GenerateAgent());
        }

        [Fact]
        public void TestPutActivityProfileDocument()
        {
            lrs.Activities.Profile.PutActivityProfileDocument(GenerateDocument());
        }

        [Fact]
        public void TestDeleteActivityProfileDocument()
        {
            lrs.Activities.Profile.DeleteActivityProfileDocument(GenerateActivityId(), GenerateProfileId());
        }

        [Fact]
        public void TestGetActivityProfileDocument()
        {
            lrs.Activities.Profile.GetActivityProfileDocument(GenerateActivityId(), GenerateProfileId());
        }

        [Fact]
        public void TestGetActivityProfileDocuments()
        {
            lrs.Activities.Profile.GetActivityProfileDocuments(GenerateActivityId(), default(DateTime));
        }

        [Fact]
        public void TestPutProfileDocument()
        {
            lrs.Agents.Profile.PutProfileDocument(GenerateDocument());
        }

        [Fact]
        public void TestDeleteProfileDocument()
        {
            lrs.Agents.Profile.DeleteProfileDocument(GenerateAgent(), GenerateProfileId());
        }

        [Fact]
        public void TestGetProfileDocument()
        {
            lrs.Agents.Profile.GetProfileDocument(GenerateAgent(), GenerateProfileId());
        }

        [Fact]
        public void TestGetProfileDocuments()
        {
            lrs.Agents.Profile.GetProfileDocuments(GenerateAgent());
        }
    }
}
