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
        readonly NoopLRS lrs;
        readonly ILRS ilrs;

        public NoopLRSTests()
        {
            lrs = new NoopLRS();
            ilrs = lrs as ILRS;
        }

        [Fact]
        public void TestPutStatement()
        {
            lrs.Statements.PutStatement(GenerateStatement(Guid.NewGuid()));
            ilrs.Statements.PutStatement(GenerateStatement(Guid.NewGuid()));
        }

        [Fact]
        public void TestPostStatement()
        {
            var list = GenerateStatements(GenerateGuid());
            lrs.Statements.PostStatements(list);
            ilrs.Statements.PostStatements(list);
        }

        [Fact]
        public void TestGetStatement()
        {
            lrs.Statements.GetStatement(GenerateGuid());
            ilrs.Statements.GetStatement(GenerateGuid());
        }

        [Fact]
        public void TestGetVoidedStatement()
        {
            lrs.Statements.GetVoidedStatement(GenerateGuid());
            ilrs.Statements.GetVoidedStatement(GenerateGuid());
        }

        [Fact]
        public void TestGetStatements()
        {
            lrs.Statements.GetStatements();
            ilrs.Statements.GetStatements();
        }

        [Fact]
        public void TestGetActivity()
        {
            lrs.Activities.GetActivity(GenerateActivityId("activity"));
            ilrs.Activities.GetActivity(GenerateActivityId("activity"));
        }

        [Fact]
        public void TestGetPerson()
        {
            lrs.Agents.GetPerson(GenerateAgent());
            ilrs.Agents.GetPerson(GenerateAgent());
        }

        [Fact]
        public void TestPutStateDocument()
        {
            lrs.Activities.State.PutStateDocument(GenerateDocument(), GenerateStateId(), GenerateActivityId(), GenerateAgent());
            ilrs.Activities.State.PutStateDocument(GenerateDocument(), GenerateStateId(), GenerateActivityId(), GenerateAgent());
        }

        [Fact]
        public void TestDeleteStateDocument()
        {
            lrs.Activities.State.DeleteStateDocument(GenerateStateId(), GenerateActivityId(), GenerateAgent());
            ilrs.Activities.State.DeleteStateDocument(GenerateStateId(), GenerateActivityId(), GenerateAgent());
        }

        [Fact]
        public void TestDeleteStateDocuments()
        {
            lrs.Activities.State.DeleteStateDocuments(GenerateActivityId(), GenerateAgent());
            ilrs.Activities.State.DeleteStateDocuments(GenerateActivityId(), GenerateAgent());
        }

        [Fact]
        public void TestGetStateDocument()
        {
            lrs.Activities.State.GetStateDocument(GenerateStateId(), GenerateActivityId(), GenerateAgent());
            ilrs.Activities.State.GetStateDocument(GenerateStateId(), GenerateActivityId(), GenerateAgent());
        }

        [Fact]
        public void TestGetStateDocuments()
        {
            lrs.Activities.State.GetStateDocuments(GenerateActivityId(), GenerateAgent());
            ilrs.Activities.State.GetStateDocuments(GenerateActivityId(), GenerateAgent());
        }

        [Fact]
        public void TestPutActivityProfileDocument()
        {
            lrs.Activities.Profile.PutActivityProfileDocument(GenerateDocument(), GenerateActivityId(), GenerateProfileId());
            ilrs.Activities.Profile.PutActivityProfileDocument(GenerateDocument(), GenerateActivityId(), GenerateProfileId());
        }

        [Fact]
        public void TestDeleteActivityProfileDocument()
        {
            lrs.Activities.Profile.DeleteActivityProfileDocument(GenerateActivityId(), GenerateProfileId());
            ilrs.Activities.Profile.DeleteActivityProfileDocument(GenerateActivityId(), GenerateProfileId());
        }

        [Fact]
        public void TestGetActivityProfileDocument()
        {
            lrs.Activities.Profile.GetActivityProfileDocument(GenerateActivityId(), GenerateProfileId());
            ilrs.Activities.Profile.GetActivityProfileDocument(GenerateActivityId(), GenerateProfileId());
        }

        [Fact]
        public void TestGetActivityProfileDocuments()
        {
            lrs.Activities.Profile.GetActivityProfileDocuments(GenerateActivityId(), default(DateTime));
            ilrs.Activities.Profile.GetActivityProfileDocuments(GenerateActivityId(), default(DateTime));
        }

        [Fact]
        public void TestPutProfileDocument()
        {
            lrs.Agents.Profile.PutProfileDocument(GenerateDocument(), GenerateAgent(), GenerateProfileId());
            ilrs.Agents.Profile.PutProfileDocument(GenerateDocument(), GenerateAgent(), GenerateProfileId());
        }

        [Fact]
        public void TestDeleteProfileDocument()
        {
            lrs.Agents.Profile.DeleteProfileDocument(GenerateAgent(), GenerateProfileId());
            ilrs.Agents.Profile.DeleteProfileDocument(GenerateAgent(), GenerateProfileId());
        }

        [Fact]
        public void TestGetProfileDocument()
        {
            lrs.Agents.Profile.GetProfileDocument(GenerateAgent(), GenerateProfileId());
            ilrs.Agents.Profile.GetProfileDocument(GenerateAgent(), GenerateProfileId());
        }

        [Fact]
        public void TestGetProfileDocuments()
        {
            lrs.Agents.Profile.GetProfileDocuments(GenerateAgent());
            ilrs.Agents.Profile.GetProfileDocuments(GenerateAgent());
        }

        [Fact]
        public void TestAbout()
        {
            lrs.About.Information();
            ilrs.About.Information();
        }
    }
}
