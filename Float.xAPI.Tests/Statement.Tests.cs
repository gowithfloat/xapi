// <copyright file="Statement.Tests.cs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Net.Mime;
using System.Security.Cryptography;
using Float.xAPI.Activities;
using Float.xAPI.Activities.Definitions;
using Float.xAPI.Actor;
using Float.xAPI.Actor.Identifier;
using Float.xAPI.Languages;
using Microsoft.FSharp.Core;
using Xunit;

namespace Float.xAPI.Tests
{
    public class StatementTests : IInitializationTests, IEqualityTests, IToStringTests
    {
        [Fact]
        public void TestValidInit()
        {
            var actor = new Agent(new Mailbox(new MailAddress("xapi@adlnet.gov")));
            var verb = new Verb(new Uri("http://adlnet.gov/expapi/verbs/created"), new LanguageMap(LanguageTag.EnglishUS, "created"));
            var obj = new Activity(new Uri("http://example.adlnet.gov/xapi/example/activity"));
            var statement = new Statement(actor, verb, obj);
            Assert.Equal("Agent", statement.Actor.ObjectType);
            Assert.Equal("Activity", statement.Object.ObjectType);
            Assert.Equal("Statement", statement.ObjectType);
            Assert.Null(statement.Actor.Name);
            Assert.Equal("xapi@adlnet.gov", ((statement.Actor as IAgent).IFI as IMailbox).Address.Address);
        }

        [Fact]
        public void TestInvalidInit()
        {
            var actor = new Agent(new OpenID(new Uri("http://example.com")));
            var verb = new Verb(new Uri("http://example.com"), LanguageMap.EnglishUS("test"));
            var activity = new Activity(new Uri("http://example.com"));

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
            var verb1 = new Verb(new Uri("http://example.com/verb"), LanguageMap.EnglishUS("verb"));
            var activity1 = new Activity(new Uri("http://example.com/activity"));
            var actor2 = new Agent(new Account("agent", new Uri("http://example.com/other-account")));
            var verb2 = new Verb(new Uri("http://example.com/different-verb"), LanguageMap.EnglishUS("verbed"));
            var activity2 = new Activity(new Uri("http://example.com/another-activity"));
            var id = Guid.NewGuid();
            var statement1 = new Statement(actor1, verb1, activity1, id);
            var statement2 = new Statement(actor1, verb1, activity1, id);
            var statement3 = new Statement(actor2, verb2, activity2, id);
            Assert.Equal(statement1, statement2);
            Assert.Equal(statement1, statement3);
            Assert.Equal(statement2, statement3);
        }

        [Fact]
        public void TestInequality()
        {
            var actor1 = new Agent(new Account("agent", new Uri("http://example.com/account")));
            var verb1 = new Verb(new Uri("http://example.com/verb"), LanguageMap.EnglishUS("verb"));
            var activity1 = new Activity(new Uri("http://example.com/activity"));
            var actor2 = new Agent(new Account("agent", new Uri("http://example.com/other-account")));
            var verb2 = new Verb(new Uri("http://example.com/different-verb"), LanguageMap.EnglishUS("verbed"));
            var activity2 = new Activity(new Uri("http://example.com/another-activity"));
            var statement1 = new Statement(actor1, verb1, activity1);
            var statement2 = new Statement(actor1, verb1, activity1);
            var statement3 = new Statement(actor2, verb2, activity2, Guid.NewGuid());
            Assert.NotEqual(statement1, statement2);
            Assert.NotEqual(statement1, statement3);
            Assert.NotEqual(statement2, statement3);
        }

        [Fact]
        public void TestToString()
        {
            var id = Guid.NewGuid();
            var timestamp = DateTime.Now;
            var actor1 = new Agent(new Account("agent", new Uri("http://example.com/account")));
            var verb1 = new Verb(new Uri("http://example.com/verb"), LanguageMap.EnglishUS("verb"));
            var activity1 = new Activity(new Uri("http://example.com/activity"));
            var statement1 = new Statement(actor1, verb1, activity1, id, timestamp: timestamp);
            Assert.Equal($"<Statement: Id {id} Actor {actor1.ToString()} Verb {verb1.ToString()} Object {activity1.ToString()} Timestamp {timestamp}>", statement1.ToString());
        }

        [Fact]
        public void TestConvenienceInitializedStatement()
        {
            var mailbox = new Mailbox(new MailAddress("example@gowithfloat.com"));
            var actor = new Agent(mailbox, "Example Learner");
            var verb = new Verb(new Uri("http://adlnet.gov/expapi/verbs/completed"), new LanguageMap(LanguageTag.EnglishUS, "completed"));

            var name = new LanguageMap(LanguageTag.EnglishUS, "Example Activity");
            var description = new LanguageMap(LanguageTag.EnglishUS, "An example activity.");
            var theType = new Uri("http://adlnet.gov/expapi/activities/course");
            var definition = new ActivityDefinition(name, description, theType);
            var activityId = new Uri("http://www.example.com/example-activity");
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
            var timestamp = DateTime.Parse("2015-11-18T12:17:00+00:00");
            var address = new MailAddress("user@example.com");
            var mailbox = new Mailbox(address);
            var actor = new Agent(mailbox, "Project Tin Can API");
            var verbUri = new Uri("http://example.com/xapi/verbs#sent-a-statement");

            var verbMap = new LanguageMap(LanguageTag.EnglishUS, "sent");
            var verb = new Verb(verbUri, verbMap);
            var nameMap = new LanguageMap(LanguageTag.EnglishUS, "simple statement");
            var descriptionMap = new LanguageMap(LanguageTag.EnglishUS, "A simple Experience API statement. Note that the LRS does not need to have any prior information about the Actor(learner), the verb, or the Activity/ object.");

            var activityId = new Uri("http://example.com/xapi/activity/simplestatement");
            var thetype = new Uri("http://adlnet.gov/expapi/activities/media");
            var definition = new ActivityDefinition(nameMap, descriptionMap, thetype, FSharpOption<Uri>.None, FSharpOption<IDictionary<Uri, string>>.None);
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
            var timestamp = DateTime.Parse("2015-12-18T12:17:00+00:00");
            var mbox = new Mailbox(new MailAddress("example.learner@adlnet.gov"));
            var actor = new Agent(mbox, "Example Learner");
            var display = new LanguageMap(LanguageTag.EnglishUS, "attempted");
            var verb = new Verb(new Uri("http://adlnet.gov/expapi/verbs/attempted"), display);

            var id2 = new Uri("http://example.adlnet.gov/xapi/example/simpleCBT");
            var name = new LanguageMap(LanguageTag.EnglishUS, "simple CBT course");
            var description = new LanguageMap(LanguageTag.EnglishUS, "A fictitious example CBT course.");
            var thetype = new Uri("http://adlnet.gov/expapi/activities/media");
            var definition = new ActivityDefinition(name, description, thetype, FSharpOption<Uri>.None, FSharpOption<IDictionary<Uri, string>>.None);
            var activity = new Activity(id2, definition);
            var result = new Result(new Score(0.95, 0.0, 1.0, 1.0), true, true, duration: new TimeSpan(0, 0, 1234));

            var statement = new Statement( actor, verb, activity, id, result, timestamp: timestamp);
        }

        [Fact]
        public void TestStatementWithAttachments()
        {
            var actor = new Agent(new Mailbox(new MailAddress("sample.agent@example.com")), "Sample Agent");
            var verb = new Verb(new Uri("http://adlnet.gov/expapi/verbs/answered"), 
                                new LanguageMap(LanguageTag.EnglishUS, "answered"));
            var activity = new Activity(
                new Uri("http://www.example.com/tincan/activities/multipart"), 
                new ActivityDefinition(new LanguageMap(LanguageTag.EnglishUS, "Multi Part Activity"), 
                                       new LanguageMap(LanguageTag.EnglishUS, "Multi Part Activity Description"),
                                       new Uri("http://www.example.com/tincan/activities/multipart")));
            var attachment = new Attachment(
                new Uri("http://example.com/attachment-usage/test"),
                new LanguageMap(LanguageTag.EnglishUS, "A test attachment"),
                new ContentType("text/plan; charset=ascii"),
                27,
                SHA256.Create(),
                new LanguageMap(LanguageTag.EnglishUS, "A test attachment (description)"),
                null
            );

            var statement = new Statement(actor,
                                          verb,
                                          activity,
                                          Guid.NewGuid(),
                                          attachments: new IAttachment[] { attachment });
        }

        [Fact]
        public void TestVoid()
        {
            var actor = new Agent(new Mailbox(new MailAddress("admin@example.adlnet.gov")), "Example Admin");
            var obj = new StatementReference(new Guid("e05aa883-acaf-40ad-bf54-02c8ce485fb0"));
            var statement = new Statement(actor, Verb.Voided, obj);

            Assert.Equal(actor, statement.Actor);
            Assert.Equal(Verb.Voided, statement.Verb);
            Assert.Equal(obj, statement.Object);
            Assert.Equal("Statement", statement.ObjectType);
            Assert.Equal("StatementRef", statement.Object.ObjectType);
            Assert.Equal("Agent", statement.Actor.ObjectType);
            Assert.Equal("example.adlnet.gov", ((statement.Actor as IAgent).IFI as IMailbox).Address.Host);
            Assert.Equal("admin", ((statement.Actor as IAgent).IFI as IMailbox).Address.User);
        }

        [Fact]
        public void TestWithResult()
        {
            var actor = new Agent(new Mailbox(new MailAddress("test@example.com")), null);
            var verb = new Verb(new Uri("http://example.com/commented"), new LanguageMap(LanguageTag.EnglishUS, "commented"));
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
            var verb = new Verb(new Uri("http://adlnet.gov/expapi/verbs/failed"), new LanguageMap(LanguageTag.EnglishUS, "failed"));
            var activity = new Activity(new Uri("https://example.adlnet.gov/AUidentifier"));
            var extensions = new Dictionary<Uri, string>
            {
                {
                    new Uri("https://w3id.org/xapi/cmi5/result/extensions/progress"), "100"

                }
            };
            var timespan = new TimeSpan(0, 30, 0);
            var result = new Result(new Score(), false, duration: timespan, extensions: extensions);
            var categories = new List<IActivity>
            {
                new Activity(new Uri("https://w3id.org/xapi/cmi5/context/categories/moveon")),
                new Activity(new Uri("https://w3id.org/xapi/cmi5/context/categories/cmi5"))
            };
            var contextActivities = new ContextActivities(category: categories);
            var ctxExtensions = new Dictionary<Uri, string>
            {
                {
                    new Uri("https://w3id.org/xapi/cmi5/context/extensions/sessionid"), "458240298378231"
                }
            };
            var context = new Context(new Guid("ec231277-b27b-4c15-8291-d29225b2b8f7"), contextActivities: contextActivities, extensions: ctxExtensions);
            var timestamp = DateTime.Parse("2012-06-01T19:09:13.245+00:00");
            var statement = new Statement(agent, verb, activity, id, result, context, timestamp);
        }
    }
}
