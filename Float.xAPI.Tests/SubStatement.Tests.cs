// <copyright file="SubStatement.Tests.cs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

using System;
using System.Net.Mail;
using Float.xAPI.Activities;
using Float.xAPI.Activities.Definitions;
using Float.xAPI.Actor;
using Float.xAPI.Actor.Identifier;
using Float.xAPI.Languages;
using Float.xAPI.Statements;
using Xunit;

namespace Float.xAPI.Tests
{
    public class SubStatementTests : IInitializationTests<SubStatement>, ISpecExampleTests, IPropertyTests
    {
        [Fact]
        public SubStatement TestValidInit()
        {
            var actor = new Agent(new Mailbox(new Uri("mailto:test@example.com")));
            var verb = Verb.Voided;
            var activity = new Activity(new ActivityId("http://example.com"));
            var result = new Result();
            var context = new Context();
            var timestamp = DateTime.Now;

            var substatement1 = new SubStatement(actor, verb, activity);
            var substatement2 = new SubStatement(actor, verb, activity, result);
            var substatement3 = new SubStatement(actor, verb, activity, result, context);
            return new SubStatement(actor, verb, activity, result, context, timestamp);
        }

        [Fact]
        public void TestInvalidInit()
        {
            var actor = new Agent(new Mailbox(new Uri("mailto:test@example.com")));
            var verb = Verb.Voided;
            var activity = new Activity(new ActivityId("http://example.com"));

            Assert.Throws<ArgumentNullException>(() => new SubStatement(null, null, null));
            Assert.Throws<ArgumentNullException>(() => new SubStatement(actor, null, null));
            Assert.Throws<ArgumentNullException>(() => new SubStatement(null, verb, null));
            Assert.Throws<ArgumentNullException>(() => new SubStatement(null, null, activity));
            Assert.Throws<ArgumentNullException>(() => new SubStatement(actor, verb, null));
            Assert.Throws<ArgumentNullException>(() => new SubStatement(actor, null, activity));
            Assert.Throws<ArgumentNullException>(() => new SubStatement(null, verb, activity));

            var substatement = new SubStatement(actor, verb, activity);
            Assert.Throws<ArgumentException>(() => new SubStatement(actor, verb, substatement));
        }

        [Fact]
        public void TestExample()
        {
            var actor = new Agent(new Mailbox(new Uri("mailto:test@example.com")), "Agent");
            var verb1 = new Verb(new VerbId("http://example.com/planned"), new LanguageMap(LanguageTag.EnglishUS, "planned"));
            var verb2 = new Verb(new VerbId("http://example.com/planned"), new LanguageMap(LanguageTag.EnglishUS, "will visit"));
            var definition = new ActivityDefinition(
                    new LanguageMap(LanguageTag.EnglishUS, "Some Awesome Website"),
                    new LanguageMap(LanguageTag.EnglishUS, "This is an awesome website"),
                    new Uri("http://adlnet.gov/expapi/activities/media"));
            var activity = new Activity(
                new ActivityId("http://example.com/website"),
                definition);
            var substatement = new SubStatement(actor, verb2, activity, null, null, null);
            var statement = new Statement(actor, verb1, substatement);
        }

        [Fact]
        public void TestProperties()
        {
            var substatement = TestValidInit();
            Assert.Equal(new Agent(new Mailbox(new Uri("mailto:test@example.com"))), substatement.Actor);
            Assert.Equal(new Context(), substatement.Context);
            Assert.Equal(new Activity(new ActivityId("http://example.com")), substatement.Object);
            Assert.Equal(ObjectType.SubStatement, substatement.ObjectType);
            Assert.Equal(new Result(), substatement.Result);
            Assert.Equal(DateTime.Now, substatement.Timestamp.Value, new TimeSpan(TimeSpan.TicksPerSecond)); // todo: avoid Value
            Assert.Equal(Verb.Voided, substatement.Verb);

            var isubstatement = substatement as ISubStatement;
            Assert.Equal(new Agent(new Mailbox(new Uri("mailto:test@example.com"))), isubstatement.Actor);
            Assert.Equal(new Context(), isubstatement.Context);
            Assert.Equal(new Activity(new ActivityId("http://example.com")), isubstatement.Object);
            Assert.Equal(ObjectType.SubStatement, isubstatement.ObjectType);
            Assert.Equal(new Result(), isubstatement.Result);
            Assert.Equal(DateTime.Now, isubstatement.Timestamp.Value, new TimeSpan(TimeSpan.TicksPerSecond)); // todo: avoid Value
            Assert.Equal(Verb.Voided, isubstatement.Verb);
        }
    }
}
