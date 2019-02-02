// <copyright file="LRSTestHelper.cs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using Float.xAPI.Activities;
using Float.xAPI.Actor;
using Float.xAPI.Actor.Identifier;
using Float.xAPI.Languages;
using Float.xAPI.Resources.Documents;

namespace Float.xAPI.Tests
{
    internal static class LRSTestHelper
    {
        internal static IStatement GenerateVoidingStatement(Guid id)
        {
            return new Statement(GenerateActor(), Verb.Voided, GenerateStatementRef(id));
        }

        internal static IStatementReference GenerateStatementRef(Guid id)
        {
            return new StatementReference(id);
        }

        internal static IIdentifiedActor GenerateActor()
        {
            return new Agent(new OpenID(GenerateUri("agent")));
        }

        internal static IAgent GenerateAgent(string suffix = "agent")
        {
            return new Agent(new OpenID(GenerateUri(suffix)));
        }

        internal static IVerb GenerateVerb()
        {
            return new Verb(GenerateUri("verb"), LanguageMap.EnglishUS("verb"));
        }

        internal static IActivity GenerateActivity()
        {
            return new Activity(GenerateActivityId("activity"));
        }

        internal static IStatement GenerateStatement(Guid statementId)
        {
            return new Statement(GenerateActor(), GenerateVerb(), GenerateActivity(), statementId);
        }

        internal static IEnumerable<IStatement> GenerateStatements(params Guid[] statementIds)
        {
            return statementIds.Select(GenerateStatement);
        }

        internal static IContext GenerateContext(Guid registrationId)
        {
            return new Context(registrationId);
        }

        internal static Guid GenerateGuid()
        {
            return Guid.NewGuid();
        }

        internal static Uri GenerateUri(string suffix)
        {
            return new Uri($"http://example.com/{suffix}");
        }

        internal static ActivityId GenerateActivityId(string suffix = "activity_id")
        {
            return new ActivityId($"http://example.com/{suffix}");
        }

        internal static ILanguageMap GenerateLanguageMap()
        {
            return LanguageMap.EnglishUS("verb");
        }

        internal static IDocument GenerateDocument()
        {
            return new Document(
                GenerateStateId(),
                DateTime.Now,
                new List<Tuple<string, string>> { new Tuple<string, string>("contents", "contents") });
        }

        internal static StateId GenerateStateId(string value = "state_id")
        {
            return new StateId(value);
        }

        internal static ProfileId GenerateProfileId(string value = "profile_id")
        {
            return new ProfileId(value);
        }
    }
}
