// <copyright file="Statement.Tests.cs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Mail;
using System.Net.Mime;
using System.Security.Cryptography;
using Float.xAPI.Activities;
using Float.xAPI.Activities.Definitions;
using Float.xAPI.Actor;
using Float.xAPI.Actor.Identifier;
using Microsoft.FSharp.Core;
using Xunit;

namespace Float.xAPI.Tests
{
    public class StatementTests : IInitializationTests, IEqualityTests, IToStringTests
    {
        [Fact]
        public void TestValidInit()
        {
            var actor = new Agent(new Mailbox(new MailAddress("xapi@adlnet.gov")), string.Empty);
            var verb = new Verb(new Uri("http://adlnet.gov/expapi/verbs/created"), new LanguageMap("en-US", "created"));
            var obj = new Activity(new Uri("http://example.adlnet.gov/xapi/example/activity"), FSharpOption<IActivityDefinition>.None);
            var statement = new Statement(actor, verb, obj);
        }

        [Fact]
        public void TestInvalidInit()
        {

        }

        [Fact]
        public void TestEquality()
        {

        }

        [Fact]
        public void TestInequality()
        {

        }

        [Fact]
        public void TestToString()
        {

        }

        [Fact]
        public void TestConvenienceInitializedStatement()
        {
            var mailbox = new Mailbox(new MailAddress("example@gowithfloat.com"));
            var actor = new Agent(mailbox, "Example Learner");
            var verb = new Verb(new Uri("http://adlnet.gov/expapi/verbs/completed"), new LanguageMap("en-US", "completed"));

            var name = new LanguageMap("en-US", "Example Activity");
            var description = new LanguageMap("en-US", "An example activity.");
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
            var enUS = new CultureInfo("en-US");

            var verbMap = new LanguageMap("en-US", "sent");
            var verb = new Verb(verbUri, verbMap);
            var nameMap = new LanguageMap(enUS, "simple statement");
            var descriptionMap = new LanguageMap(enUS, "A simple Experience API statement. Note that the LRS does not need to have any prior information about the Actor(learner), the verb, or the Activity/ object.");

            var activityId = new Uri("http://example.com/xapi/activity/simplestatement");
            var thetype = new Uri("http://adlnet.gov/expapi/activities/media");
            var definition = new ActivityDefinition(nameMap, descriptionMap, thetype, FSharpOption<Uri>.None, FSharpOption<IDictionary<Uri, string>>.None);
            var activity = new Activity(activityId, definition);

            var statement = new Statement(
                actor,
                verb,
                activity,
                id,
                null,
                null,
                timestamp,
                null,
                null,
                null,
                null
            );

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
            var display = new LanguageMap("en-US", "attempted");
            var verb = new Verb(new Uri("http://adlnet.gov/expapi/verbs/attempted"), display);

            var id2 = new Uri("http://example.adlnet.gov/xapi/example/simpleCBT");
            var name = new LanguageMap("en-US", "simple CBT course");
            var description = new LanguageMap("en-US", "A fictitious example CBT course.");
            var thetype = new Uri("http://adlnet.gov/expapi/activities/media");
            var definition = new ActivityDefinition(name, description, thetype, FSharpOption<Uri>.None, FSharpOption<IDictionary<Uri, string>>.None);
            var activity = new Activity(id2, definition);
            //var result = new Result(new Score(0.95, 0.0, 1.0, 1.0), true, true, new TimeSpan(0, 0, 1234),);

            //var statement = new Statement(id, actor, verb, activity, result, null, timestamp, null, null, null);
        }

        [Fact]
        public void TestStatementWithAttachments()
        {
            var actor = new Agent(new Mailbox(new MailAddress("sample.agent@example.com")), "Sample Agent");
            var verb = new Verb(new Uri("http://adlnet.gov/expapi/verbs/answered"), new LanguageMap("en-US", "answered"));
            var activity = new Activity(
                new Uri("http://www.example.com/tincan/activities/multipart"), 
                new ActivityDefinition(new LanguageMap("en-US", "Multi Part Activity"), 
                                       new LanguageMap("en_US", "Multi Part Activity Description"),
                                       new Uri("http://www.example.com/tincan/activities/multipart"), 
                                       null, 
                                       null
                                      ));
            var attachment = new Attachment(
                new Uri("http://example.com/attachment-usage/test"),
                new LanguageMap("en-US", "A test attachment"),
                new ContentType("text/plan; charset=ascii"),
                27,
                SHA256.Create(),
                new LanguageMap("en-US", "A test attachment (description)"),
                null
            );

            var statement = new Statement(actor,
                                          verb,
                                          activity,
                                          Guid.NewGuid(),
                                          null, null, null, null, null, null,
                                          new IAttachment[] { attachment });
        }

        [Fact]
        public void TestVoid()
        {
            var actor = new Agent(new Mailbox(new MailAddress("admin@example.adlnet.gov")), "Example Admin");
            var obj = new StatementReference(new Guid("e05aa883-acaf-40ad-bf54-02c8ce485fb0"));
            var statement = new Statement(actor, Verb.Voided, obj);

            Assert.Equal(actor, statement.Actor);
            //Assert.Equal(Verb.Voided, statement.Verb);
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
            var verb = new Verb(new Uri("http://example.com/commented"), new LanguageMap("en-US", "commented"));
            var statementRef = new StatementReference(new Guid("8f87ccde-bb56-4c2e-ab83-44982ef22df0"));
            var result = new Result(response: "Wow, nice work!");
            var statement = new Statement(actor, verb, statementRef, result: result);
        }
    }
}
