// <copyright file="Statement.Tests.cs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Security.Cryptography;
using Float.xAPI.Activities;
using Float.xAPI.Activities.Definitions;
using Float.xAPI.Actors;
using Float.xAPI.Actors.Identifier;
using Float.xAPI.Languages;
using Float.xAPI.Statements;
using Microsoft.FSharp.Core;
using Xunit;

namespace Float.xAPI.Tests
{
    public class StatementTests : IInitializationTests<Statement>, IEqualityTests, IPropertyTests
    {
        [Fact]
        public Statement TestValidInit()
        {
            var actor = new Agent(new Mailbox(new Uri("mailto:xapi@adlnet.gov")));
            var verb = new Verb(new VerbId("http://adlnet.gov/expapi/verbs/created"), new LanguageMap(LanguageTag.EnglishUS, "created"));
            var obj = new Activity(new ActivityId("http://example.adlnet.gov/xapi/example/activity"));
            var statement = new Statement(actor, verb, obj);
            Assert.Equal(ObjectType.Agent, statement.Actor.Item.ObjectType);
            Assert.Equal(ObjectType.Activity, statement.Object.ObjectType);
            Assert.Null(statement.Actor.Item.Name);
            Assert.Equal("mailto:xapi@adlnet.gov", ((statement.Actor.Item as IAgent).IFI.Item as IMailbox).Address.AbsoluteUri);
            return statement;
        }

        [Fact]
        public void TestInvalidInit()
        {
            var actor = new Agent(new OpenID(new Uri("http://example.com")));
            var verb = new Verb(new VerbId("http://example.com"), LanguageMap.EnglishUS("test"));
            var activity = new Activity(new ActivityId("http://example.com"));

            Assert.Throws<ArgumentNullException>(() => new Statement(null, null, null));
            Assert.Throws<ArgumentNullException>(() => new Statement(actor, null, null));
            Assert.Throws<ArgumentNullException>(() => new Statement(null, verb, null));
            Assert.Throws<ArgumentNullException>(() => new Statement(null, null, activity));
            Assert.Throws<ArgumentNullException>(() => new Statement(actor, verb, null));
            Assert.Throws<ArgumentNullException>(() => new Statement(actor, null, activity));
            Assert.Throws<ArgumentNullException>(() => new Statement(null, verb, activity));
        }

        [Fact]
        public void TestEquality()
        {
            var actor1 = new Agent(new Account("agent", new Uri("http://example.com/account")));
            var verb1 = new Verb(new VerbId("http://example.com/verb"), LanguageMap.EnglishUS("verb"));
            var activity1 = new Activity(new ActivityId("http://example.com/activity"));
            var actor2 = new Agent(new Account("agent", new Uri("http://example.com/other-account")));
            var verb2 = new Verb(new VerbId("http://example.com/different-verb"), LanguageMap.EnglishUS("verbed"));
            var activity2 = new Activity(new ActivityId("http://example.com/another-activity"));
            var id = Guid.NewGuid();
            var statement1 = new Statement(actor1, verb1, activity1, id);
            var statement2 = new Statement(actor1, verb1, activity1, id);
            var statement3 = new Statement(actor2, verb2, activity2, id);
            AssertHelper.Equality<Statement, IStatement>(statement1, statement2, (a, b) => a == b);
            AssertHelper.Equality<Statement, IStatement>(statement1, statement3, (a, b) => a == b);
            AssertHelper.Equality<Statement, IStatement>(statement2, statement3, (a, b) => a == b);
        }

        [Fact]
        public void TestInequality()
        {
            var actor1 = new Agent(new Account("agent", new Uri("http://example.com/account")));
            var verb1 = new Verb(new VerbId("http://example.com/verb"), LanguageMap.EnglishUS("verb"));
            var activity1 = new Activity(new ActivityId("http://example.com/activity"));
            var actor2 = new Agent(new Account("agent", new Uri("http://example.com/other-account")));
            var verb2 = new Verb(new VerbId("http://example.com/different-verb"), LanguageMap.EnglishUS("verbed"));
            var activity2 = new Activity(new ActivityId("http://example.com/another-activity"));
            var statement1 = new Statement(actor1, verb1, activity1);
            var statement2 = new Statement(actor1, verb1, activity1);
            var statement3 = new Statement(actor2, verb2, activity2, Guid.NewGuid());
            AssertHelper.Inequality<Statement, IStatement>(statement1, statement2, (a, b) => a != b);
            AssertHelper.Inequality<Statement, IStatement>(statement1, statement3, (a, b) => a != b);
            AssertHelper.Inequality<Statement, IStatement>(statement2, statement3, (a, b) => a != b);
        }

        [Fact]
        public void TestConvenienceInitializedStatement()
        {
            var mailbox = new Mailbox(new Uri("mailto:example@gowithfloat.com"));
            var actor = new Agent(mailbox, "Example Learner");
            var verb = new Verb(new VerbId("http://adlnet.gov/expapi/verbs/completed"), new LanguageMap(LanguageTag.EnglishUS, "completed"));

            var name = new LanguageMap(LanguageTag.EnglishUS, "Example Activity");
            var description = new LanguageMap(LanguageTag.EnglishUS, "An example activity.");
            var theType = new Uri("http://adlnet.gov/expapi/activities/course");
            var definition = new ActivityDefinition(name, description, theType);
            var activityId = new ActivityId("http://www.example.com/example-activity");
            var activity = new Activity(activityId, definition);
            var statement = new Statement(actor, verb, activity);
        }

        /// <summary>
        /// Attempt to create a statement using data from Appendix A.
        /// </summary>
        [Fact]
        public void TestExample()
        {
            var id = new Guid("fd41c918-b88b-4b20-a0a5-a4c32391aaa0");
            var timestamp = new DateTimeOffset(new DateTime(2015, 11, 18, 12, 17, 0));
            var address = new Uri("mailto:user@example.com");
            var mailbox = new Mailbox(address);
            var actor = new Agent(mailbox, "Project Tin Can API");
            var verbUri = new VerbId("http://example.com/xapi/verbs#sent-a-statement");

            var verbMap = new LanguageMap(LanguageTag.EnglishUS, "sent");
            var verb = new Verb(verbUri, verbMap);
            var nameMap = new LanguageMap(LanguageTag.EnglishUS, "simple statement");
            var descriptionMap = new LanguageMap(LanguageTag.EnglishUS, "A simple Experience API statement. Note that the LRS does not need to have any prior information about the Actor(learner), the verb, or the Activity/ object.");

            var activityId = new ActivityId("http://example.com/xapi/activity/simplestatement");
            var thetype = new Uri("http://adlnet.gov/expapi/activities/media");
            var definition = new ActivityDefinition(nameMap, descriptionMap, thetype, FSharpOption<Uri>.None);
            var activity = new Activity(activityId, definition);

            var statement = new Statement(actor, verb, activity, id, timestamp: timestamp);

            Assert.NotNull(statement.Actor);
            Assert.NotNull(statement.Object);
            Assert.NotNull(statement.Timestamp);
            Assert.True(statement.Object is Activity);
            Assert.Null(statement.Authority);
        }

        [Fact]
        public void TestExampleStatement2()
        {
            var id = new Guid("7ccd3322-e1a5-411a-a67d-6a735c76f119");
            var timestamp = new DateTimeOffset(new DateTime(2015, 12, 18, 12, 17, 0));
            var mbox = new Mailbox(new Uri("mailto:example.learner@adlnet.gov"));
            var actor = new Agent(mbox, "Example Learner");
            var display = new LanguageMap(LanguageTag.EnglishUS, "attempted");
            var verb = new Verb(new VerbId("http://adlnet.gov/expapi/verbs/attempted"), display);

            var id2 = new ActivityId("http://example.adlnet.gov/xapi/example/simpleCBT");
            var name = new LanguageMap(LanguageTag.EnglishUS, "simple CBT course");
            var description = new LanguageMap(LanguageTag.EnglishUS, "A fictitious example CBT course.");
            var thetype = new Uri("http://adlnet.gov/expapi/activities/media");
            var definition = new ActivityDefinition(name, description, thetype, FSharpOption<Uri>.None);
            var activity = new Activity(id2, definition);
            var result = new Result(new Score(0.95), true, true, duration: new TimeSpan(0, 0, 1234));

            var statement = new Statement(actor, verb, activity, id, result, timestamp: timestamp);
        }

        [Fact]
        public void TestStatementWithAttachments()
        {
            var actor = new Agent(new Mailbox(new Uri("mailto:sample.agent@example.com")), "Sample Agent");
            var verb = new Verb(
                new VerbId("http://adlnet.gov/expapi/verbs/answered"),
                new LanguageMap(LanguageTag.EnglishUS, "answered"));
            var definition = new ActivityDefinition(
                new LanguageMap(LanguageTag.EnglishUS, "Multi Part Activity"),
                new LanguageMap(LanguageTag.EnglishUS, "Multi Part Activity Description"),
                new Uri("http://www.example.com/tincan/activities/multipart"));
            var activity = new Activity(
                new ActivityId("http://www.example.com/tincan/activities/multipart"),
                definition);
            var attachment = new Statements.Attachment(
                new Uri("http://example.com/attachment-usage/test"),
                new LanguageMap(LanguageTag.EnglishUS, "A test attachment"),
                new ContentType("text/plan; charset=ascii"),
                27,
                new SHAHash("text", SHA256.Create()),
                new LanguageMap(LanguageTag.EnglishUS, "A test attachment (description)"),
                null);

            var statement = new Statement(
                actor,
                verb,
                activity,
                Guid.NewGuid(),
                attachments: new IAttachment[] { attachment });
        }

        [Fact]
        public void TestVoid()
        {
            var actor = new Agent(new Mailbox(new Uri("mailto:admin@example.adlnet.gov")), "Example Admin");
            var obj = new StatementReference(new Guid("e05aa883-acaf-40ad-bf54-02c8ce485fb0"));
            var statement = new Statement(actor, Verb.Voided, obj);

            Assert.Equal(actor, statement.Actor.Item);
            Assert.Equal(Verb.Voided, statement.Verb);
            Assert.Equal(obj, statement.Object);
            Assert.Equal(ObjectType.StatementReference, statement.Object.ObjectType);
            Assert.Equal(ObjectType.Agent, statement.Actor.Item.ObjectType);
            Assert.Equal("example.adlnet.gov", ((statement.Actor.Item as IAgent).IFI.Item as IMailbox).Address.Host);
            Assert.Equal("admin", ((statement.Actor.Item as IAgent).IFI.Item as IMailbox).Address.UserInfo);
        }

        [Fact]
        public void TestWithResult()
        {
            var actor = new Agent(new Mailbox(new Uri("mailto:test@example.com")), null);
            var verb = new Verb(new VerbId("http://example.com/commented"), new LanguageMap(LanguageTag.EnglishUS, "commented"));
            var statementRef = new StatementReference(new Guid("8f87ccde-bb56-4c2e-ab83-44982ef22df0"));
            var result = new Result(response: "Wow, nice work!");
            var statement = new Statement(actor, verb, statementRef, result: result);
        }

        [Fact]
        public void TestAboutExample()
        {
            var id = new Guid("2a41c918-b88b-4220-20a5-a4c32391a240");
            var account = new Account("1625378", new Uri("http://example.adlnet.gov"));
            var agent = new Agent(account, "Gert Frobe");
            var verb = new Verb(new VerbId("http://adlnet.gov/expapi/verbs/failed"), new LanguageMap(LanguageTag.EnglishUS, "failed"));
            var activity = new Activity(new ActivityId("https://example.adlnet.gov/AUidentifier"));
            var extensions = new Dictionary<Uri, object>
            {
                {
                    new Uri("https://w3id.org/xapi/cmi5/result/extensions/progress"), "100"
                },
            };
            var timespan = new TimeSpan(0, 30, 0);
            var result = new Result(new Score(), false, duration: timespan, extensions: extensions);
            var categories = new List<IActivity>
            {
                new Activity(new ActivityId("https://w3id.org/xapi/cmi5/context/categories/moveon")),
                new Activity(new ActivityId("https://w3id.org/xapi/cmi5/context/categories/cmi5")),
            };
            var contextActivities = new ContextActivities(category: categories);
            var ctxExtensions = new Dictionary<Uri, object>
            {
                {
                    new Uri("https://w3id.org/xapi/cmi5/context/extensions/sessionid"), "458240298378231"
                },
            };
            var context = new Context(new Guid("ec231277-b27b-4c15-8291-d29225b2b8f7"), contextActivities: contextActivities, extensions: ctxExtensions);
            var timestamp = new DateTimeOffset(new DateTime(2012, 6, 1, 19, 13, 24));
            var statement = new Statement(agent, verb, activity, id, result, context, timestamp);
        }

        [Fact]
        public void TestProperties()
        {
            var actor = new Agent(new OpenID(new Uri("http://example.com/actor")));
            var verb = new Verb(new VerbId("http://example.com/verb"), LanguageMap.EnglishUS("verbed"));
            var activity = new Activity(new ActivityId("http://example.com/activity"));
            var id = Guid.NewGuid();
            var result = new Result(new Score(0.5));
            var contextId = Guid.NewGuid();
            var context = new Context(contextId);
            var timestamp = DateTimeOffset.Now;
            var auth = new Agent(new OpenID(new Uri("http://example.com/authority")));
            var version = new Version(1, 2, 3);
            var attachments = new List<IAttachment>
            {
                new Statements.Attachment(
                    new Uri("http://example.com/usageType"),
                    LanguageMap.EnglishUS("display"),
                    new ContentType("text/plain"),
                    16,
                    new SHAHash("shahash")),
            };

            var statement = new Statement(actor, verb, activity, id, result, context, timestamp, timestamp, auth, version, attachments);
            Assert.Equal(actor, statement.Actor.Item);
            Assert.Equal(attachments, statement.Attachments);
            Assert.Equal(auth, statement.Authority.Value.Item);
            Assert.Equal(contextId, statement.Context.Value.Registration);
            Assert.Equal(id, statement.Id);
            Assert.Equal(activity, statement.Object);
            Assert.Equal(result, statement.Result);
            Assert.Equal(timestamp, statement.Stored);
            Assert.Equal(timestamp, statement.Timestamp);
            Assert.Equal(verb.Id, statement.Verb.Id);
            Assert.Equal(version, statement.Version);

            var istatement = statement as IStatement;
            Assert.Equal(actor, istatement.Actor.Item);
            Assert.Equal(attachments, istatement.Attachments);
            Assert.Equal(auth, istatement.Authority.Value.Item);
            Assert.Equal(contextId, istatement.Context.Value.Registration);
            Assert.Equal(id, istatement.Id);
            Assert.Equal(activity, istatement.Object);
            Assert.Equal(result, istatement.Result);
            Assert.Equal(timestamp, istatement.Stored);
            Assert.Equal(timestamp, istatement.Timestamp);
            Assert.Equal(verb.Id, istatement.Verb.Id);
            Assert.Equal(version, istatement.Version);
        }
    }
}
