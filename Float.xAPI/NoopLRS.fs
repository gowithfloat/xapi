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

type private NoopStatementEndpoint =
    new() = {}
    interface IStatementEndpoint with
        member this.PutStatement statement = ()
        member this.PostStatements statements = Seq.empty
        member this.GetStatement(statementId, format, attachments) = None
        member this.GetVoidedStatement(voidedStatementId, format, attachments) = None
        member this.GetStatements(agent, verb, activity, registration, relatedActivities, relatedAgents, since, until, limit, format, attachments, ascending) = StatementResult(Seq.empty) :> IStatementResult

type private NoopStateResource =
    new() = {}
    interface IStateResource with
        member this.PutStateDocument document = ()
        member this.DeleteStateDocument(stateId, activityId, agent, guid) = ()
        member this.DeleteStateDocuments(activityId, agent, guid) = ()
        member this.GetStateDocument(stateId, activityId, agent, guid) = None
        member this.GetStateDocuments(activityId, agent, guid, date) = Seq.empty

type private NoopActivityProfileResource =
    new() = {}
    interface IActivityProfileResource with
        member this.PutActivityProfileDocument document = ()
        member this.DeleteActivityProfileDocument(id, name) = ()
        member this.GetActivityProfileDocument(id, name) = None
        member this.GetActivityProfileDocuments(id, date) = Seq.empty

type private NoopActivityEndpoint =
    new() = {}
    interface IActivityEndpoint with
        member this.State = NoopStateResource() :> IStateResource
        member this.Profile = NoopActivityProfileResource() :> IActivityProfileResource
        member this.GetActivity id = 
            Activity(
                Uri("http://noop.com"), 
                ActivityDefinition(
                    LanguageMap.EnglishUS("noop"),
                    LanguageMap.EnglishUS("noop"),
                    Uri("http://noop.com")
                )
            ) :> IActivity

type private NoopAgentProfileResource =
    new() = {}
    interface IAgentProfileResource with
        member this.PutProfileDocument document = ()
        member this.DeleteProfileDocument(agent, id) = ()
        member this.GetProfileDocument(agent, id) = None
        member this.GetProfileDocuments(agent, date) = Seq.empty

type private NoopAgentEndpoint =
    new() = {}
    interface IAgentEndpoint with
        member this.Profile = NoopAgentProfileResource() :> IAgentProfileResource
        member this.GetPerson agent = Seq.empty

type private NoopAboutEndpoint =
    new() = {}
    interface IAboutEndpoint with
        member this.Information = "info"

/// <summary>
/// The "noop" LRS takes no action in response to statement requests.
/// Generally, this is only used for testing.
/// </summary>
type NoopLRS =
    /// <summary>
    /// Initializes a new instance of the <see cref="T:Float.xAPI.NoopLRS"/> object.
    /// </summary>
    new () = { }

    interface ILRS with
        member this.Statements = NoopStatementEndpoint() :> IStatementEndpoint
        member this.Activities = NoopActivityEndpoint() :> IActivityEndpoint
        member this.Agents = NoopAgentEndpoint() :> IAgentEndpoint
        member this.About = NoopAboutEndpoint() :> IAboutEndpoint
