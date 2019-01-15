// <copyright file="NoopLRS.fs" company="Float">
// Copyright (c) 2019 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

namespace Float.xAPI

open System
open Float.xAPI.Activities
open Float.xAPI.Activities.Definitions
open Float.xAPI.Languages
open Float.xAPI.Resources
open Float.xAPI.Resources.Documents

/// <summary>
/// The "noop" LRS takes no action in response to statement requests.
/// Generally, this is only used for testing.
/// </summary>
type NoopLRS =
    /// <summary>
    /// Initializes a new instance of the <see cref="T:Float.xAPI.NoopLRS"/> object.
    /// </summary>
    new () = { }

    member this.CreateDocument = Document(StateId.StateId("noop"), DateTime.Now, Seq.singleton("contents", "contents")) :> IDocument

    interface ILRS with
        member this.PutStatement statement = ()
        member this.PostStatements statements = Seq.empty
        member this.GetStatement(statementId, format, attachments) = None
        member this.GetVoidedStatement(voidedStatementId, format, attachments) = None
        member this.GetStatements(agent, verb, activity, registration, relatedActivities, relatedAgents, since, until, limit, format, attachments, ascending) = StatementResult(Seq.empty) :> IStatementResult
        member this.GetActivity id = 
            Activity(
                Uri("http://noop.com"), 
                ActivityDefinition(
                    LanguageMap.EnglishUS("noop"),
                    LanguageMap.EnglishUS("noop"),
                    Uri("http://noop.com")
                )
            ) :> IActivity
        member this.GetPerson agent = Seq.empty
        member this.PutStateDocument document = ()
        member this.DeleteStateDocument(stateId, activityId, agent, guid) = ()
        member this.DeleteStateDocuments(activityId, agent, guid) = ()
        member this.GetStateDocument(stateId, activityId, agent, guid) = this.CreateDocument
        member this.GetStateDocuments(activityId, agent, guid, date) = Seq.empty
        member this.PutActivityProfileDocument document = ()
        member this.DeleteActivityProfileDocument(id, name) = ()
        member this.GetActivityProfileDocument(id, name) = this.CreateDocument
        member this.GetActivityProfileDocuments(id, date) = Seq.empty
        member this.PutProfileDocument document = ()
        member this.DeleteProfileDocument(agent, id) = ()
        member this.GetProfileDocument(agent, id) = this.CreateDocument
        member this.GetProfileDocuments(agent, date) = Seq.empty
