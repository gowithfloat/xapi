// <copyright file="NoopLRS.fs" company="Float">
// Copyright (c) 2019 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

namespace Float.xAPI

open System
open Float.xAPI
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
        member this.PutStateDocument(doc, sid, aid, agent, reg) = ()
        member this.DeleteStateDocument(sid, aid, agent, reg) = ()
        member this.DeleteStateDocuments(aid, agent, reg) = ()
        member this.GetStateDocument(sid, aid, agent, reg) = None
        member this.GetStateDocuments(aid, agent, reg, since) = Seq.empty

type private NoopActivityProfileResource =
    new() = {}
    interface IActivityProfileResource with
        member this.PutActivityProfileDocument(document, id, name) = ()
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
        member this.PutProfileDocument(document, agent, pid) = ()
        member this.DeleteProfileDocument(agent, pid) = ()
        member this.GetProfileDocument(agent, pid) = None
        member this.GetProfileDocuments(agent, date) = Seq.empty

type private NoopAgentEndpoint =
    new() = {}
    interface IAgentEndpoint with
        member this.Profile = NoopAgentProfileResource() :> IAgentProfileResource
        member this.GetPerson agent = Seq.empty

type private NoopAboutEndpoint =
    new() = { }

    interface IAboutEndpoint with
        member this.Information() = (Seq.empty, Seq.empty)

/// <summary>
/// The "noop" LRS takes no action in response to statement requests.
/// Generally, this is only used for testing.
/// </summary>
type NoopLRS =
    val private StatementEndpoint: NoopStatementEndpoint
    val private ActivityEndpoint: NoopActivityEndpoint
    val private AgentEndpoint: NoopAgentEndpoint
    val private AboutEndpoint: NoopAboutEndpoint

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Float.xAPI.NoopLRS"/> object.
    /// </summary>
    new () = 
        { StatementEndpoint = NoopStatementEndpoint() ; ActivityEndpoint = NoopActivityEndpoint() ; AgentEndpoint = NoopAgentEndpoint() ; AboutEndpoint = NoopAboutEndpoint() }
        
    member this.Statements = this.StatementEndpoint :> IStatementEndpoint
    member this.Activities = this.ActivityEndpoint :> IActivityEndpoint
    member this.Agents = this.AgentEndpoint :> IAgentEndpoint
    member this.About = this.AboutEndpoint :> IAboutEndpoint

    interface ILRS with
        member this.Statements = this.Statements
        member this.Activities = this.Activities
        member this.Agents = this.Agents
        member this.About = this.About
