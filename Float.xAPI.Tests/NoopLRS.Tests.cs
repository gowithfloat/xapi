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
            lrs.PutStatement(GenerateStatement(Guid.NewGuid()));
        }

        [Fact]
        public void TestPostStatement()
        {
            lrs.PostStatements(new List<IStatement>
            {
                GenerateStatement(GenerateGuid())
            });
        }

        [Fact]
        public void TestGetStatement()
        {
            lrs.GetStatement(GenerateGuid());
        }

        [Fact]
        public void TestGetVoidedStatement()
        {
            lrs.GetVoidedStatement(GenerateGuid());
        }

        [Fact]
        public void TestGetStatements()
        {
            lrs.GetStatements();
        }

        [Fact]
        public void TestGetActivity()
        {
            lrs.GetActivity(GenerateUri("activity"));
        }

        [Fact]
        public void TestGetPerson()
        {
            lrs.GetPerson(GenerateAgent());
        }

        [Fact]
        public void TestPutStateDocument()
        {
            lrs.PutStateDocument(GenerateDocument());
        }

        [Fact]
        public void TestDeleteStateDocument()
        {
            lrs.DeleteStateDocument(GenerateStateId());
        }

        [Fact]
        public void TestDeleteStateDocuments()
        {
            lrs.DeleteStateDocuments(GenerateActivityId(), GenerateAgent());
        }

        [Fact]
        public void TestGetStateDocument()
        {
            lrs.GetStateDocument(GenerateStateId(), GenerateActivityId(), GenerateAgent());
        }

        [Fact]
        public void TestGetStateDocuments()
        {
            lrs.GetStateDocuments(GenerateActivityId(), GenerateAgent());
        }

        [Fact]
        public void TestPutActivityProfileDocument()
        {
            lrs.PutActivityProfileDocument(GenerateDocument());
        }

        [Fact]
        public void TestDeleteActivityProfileDocument()
        {
            lrs.DeleteActivityProfileDocument(GenerateActivityId(), "test");
        }

        [Fact]
        public void TestGetActivityProfileDocument()
        {
            lrs.GetActivityProfileDocument(GenerateActivityId(), "test");
        }

        [Fact]
        public void TestGetActivityProfileDocuments()
        {
            lrs.GetActivityProfileDocuments(GenerateActivityId(), default(DateTime));
        }

        [Fact]
        public void TestPutProfileDocument()
        {
            lrs.PutProfileDocument(GenerateDocument());
        }

        [Fact]
        public void TestDeleteProfileDocument()
        {
            lrs.DeleteProfileDocument(GenerateAgent(), GenerateProfileId());
        }

        [Fact]
        public void TestGetProfileDocument()
        {
            lrs.GetProfileDocument(GenerateAgent(), GenerateProfileId());
        }

        [Fact]
        public void TestGetProfileDocuments()
        {
            lrs.GetProfileDocuments(GenerateAgent());
        }
    }
}
