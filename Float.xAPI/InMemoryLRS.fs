// <copyright file="InMemoryLRS.fs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

namespace Float.xAPI

open System
open System.Collections.Generic
open System.Runtime.InteropServices
open System.Linq
open Float.xAPI.Activities
open Float.xAPI.Activities.Definitions
open Float.xAPI.Actor
open Float.xAPI.Resources
open Float.xAPI.Resources.Documents

module internal Util =
    let mapStatementToId(statement: IStatement) =
        statement.Id

type private InMemoryStatementResource =
    val private Statements: List<IStatement>

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Float.xAPI.InMemoryLRS"/> object.
    /// </summary>
    new () =
        { Statements = List<IStatement>() }

    /// <inheritdoc />
    member this.PutStatement statement = this.Statements.Add(statement)

    /// <inheritdoc />
    member this.PostStatements statements =
        this.Statements.AddRange(statements)
        statements 
            |> Seq.map Util.mapStatementToId

    /// <inheritdoc />
    member this.GetStatement(statementId: Guid, 
                             [<Optional;DefaultParameterValue(StatementResultFormat.Exact)>] format: StatementResultFormat, 
                             [<Optional;DefaultParameterValue(false)>] attachments: bool) =
        this.Statements
            |> List.ofSeq 
            |> List.where (Filters.statementVerbMismatch (Some(Verb.Voided.Id)))
            |> List.tryFind (Filters.statementIdMatch statementId)

    /// <inheritdoc />
    member this.GetVoidedStatement(voidedStatementId: Guid, 
                                   [<Optional;DefaultParameterValue(StatementResultFormat.Exact)>] format: StatementResultFormat, 
                                   [<Optional;DefaultParameterValue(false)>] attachments: bool) =
        this.Statements 
            |> List.ofSeq 
            |> List.where (Filters.statementVerbMatch (Some(Verb.Voided.Id)))
            |> List.tryFind (Filters.statementIdMatch voidedStatementId)

    /// <inheritdoc />
    member this.GetStatements([<Optional>] actor: IIdentifiedActor option, 
                              [<Optional>] verbId: Uri option, 
                              [<Optional>] activityId: Uri option, 
                              [<Optional>] registration: Guid option, 
                              [<Optional>] relatedActivities: bool, 
                              [<Optional>] relatedAgents: bool, 
                              [<Optional>] since: DateTime option, 
                              [<Optional>] until: DateTime option, 
                              [<Optional;DefaultParameterValue(0)>] limit: int,
                              [<Optional;DefaultParameterValue(StatementResultFormat.Exact)>] format: StatementResultFormat, 
                              [<Optional;DefaultParameterValue(false)>] attachments: bool, 
                              [<Optional;DefaultParameterValue(false)>] ascending: bool) =
        this.Statements 
            |> List.ofSeq 
            |> List.where (Filters.statementActorMatch actor)
            |> List.where (Filters.statementVerbMatch verbId)
            |> List.where (Filters.statementActivityMatch activityId)
            |> List.where (Filters.statementRegistrationMatch registration)
            |> List.where (Filters.statementSinceMatch since)
            |> List.where (Filters.statementUntilMatch until)
            |> StatementResult
            :> IStatementResult

    interface IStatementEndpoint with
        member this.PutStatement statement = this.PutStatement statement
        member this.PostStatements statements = this.PostStatements statements
        member this.GetStatement(statementId, format, attachments) = this.GetStatement(statementId, format, attachments)
        member this.GetVoidedStatement(voidedStatementId, format, attachments) = this.GetVoidedStatement(voidedStatementId, format, attachments)
        member this.GetStatements(agent, verb, activity, registration, relatedActivities, relatedAgents, since, until, limit, format, attachments, ascending) = 
            this.GetStatements(agent, verb, activity, registration, relatedActivities, relatedAgents, since, until, limit, format, attachments, ascending)

type private InMemoryStateResource =
    val private Documents: List<IDocument>

    new () =
        { Documents = List<IDocument>() }

    /// <inheritdoc />
    member this.PutStateDocument(document: IDocument) =
        this.Documents.Add(document)

    /// <inheritdoc />
    member this.DeleteStateDocument(id: StateId, [<Optional>] ?activityId: ActivityId option, [<Optional>] ?agent: IAgent option, [<Optional>] ?registration: Guid option) =
        this.Documents.RemoveAll(fun doc -> doc.Id = id)
        |> ignore
        // todo: filter by activity, agent, registration

    /// <inheritdoc />
    member this.DeleteStateDocuments(id: ActivityId, agent: IAgent, [<Optional>] ?registration: Guid option) =
        () // todo: implement

    /// <inheritdoc />
    member this.GetStateDocument(id: StateId, activityId: ActivityId, agent: IAgent, [<Optional>] ?registration: Guid option) =
        None // todo: implement

    /// <inheritdoc />
    member this.GetStateDocuments(id: ActivityId, agent: IAgent, [<Optional>] ?guid: Guid option, [<Optional>] ?date: DateTime option) =
        Seq.empty // todo: implement

    interface IStateResource with
        member this.PutStateDocument document = this.PutStateDocument document
        member this.DeleteStateDocument(sid, aid, agent, reg) = this.DeleteStateDocument(sid, aid, agent, reg)
        member this.DeleteStateDocuments(aid, agent, reg) = this.DeleteStateDocuments(aid, agent, reg)
        member this.GetStateDocument(sid, aid, agent, reg) = this.GetStateDocument(sid, aid, agent, reg)
        member this.GetStateDocuments(aid, agent, reg, date) = this.GetStateDocuments(aid, agent, reg, date)

type private InMemoryActivityProfileResource =
    val private Documents: List<IDocument>

    new () =
        { Documents = List<IDocument>() }

    /// <inheritdoc />
    member this.PutActivityProfileDocument(document: IDocument) =
        this.Documents.Add(document)

    /// <inheritdoc />
    member this.DeleteActivityProfileDocument(aid: ActivityId, pid: ProfileId) =
        () // todo: implement

    /// <inheritdoc />
    member this.GetActivityProfileDocument(aid: ActivityId, pid: ProfileId) =
        None // todo: implement

    /// <inheritdoc />
    member this.GetActivityProfileDocuments(aid: ActivityId, date: DateTime) =
        Seq.empty // todo: implement

    interface IActivityProfileResource with
        member this.PutActivityProfileDocument document = this.PutActivityProfileDocument document
        member this.DeleteActivityProfileDocument(aid, pid) = this.DeleteActivityProfileDocument(aid, pid)
        member this.GetActivityProfileDocument(aid, pid) = this.GetActivityProfileDocument(aid, pid)
        member this.GetActivityProfileDocuments(aid, pid) = this.GetActivityProfileDocuments(aid, pid)

type private InMemoryActivityEndpoint =
    val private Activities: List<IActivity>

    new () =
        { Activities = List<IActivity>() }

    /// <inheritdoc />
    member this.GetActivity(id: Uri) =
        this.Activities.Where(fun activity -> activity.Id = id).First()

    interface IActivityEndpoint with
        member this.State = InMemoryStateResource() :> IStateResource
        member this.Profile = InMemoryActivityProfileResource() :> IActivityProfileResource
        member this.GetActivity id = this.GetActivity id

type private InMemoryAgentProfileResource =
    val private Documents: List<IDocument>

    new () =
        { Documents = List<IDocument>() }

    /// <inheritdoc />
    member this.PutProfileDocument(document: IDocument) =
        this.Documents.Add(document)

    /// <inheritdoc />
    member this.DeleteProfileDocument(agent: IAgent, id: ProfileId) =
        this.Documents.RemoveAll(fun doc -> doc.Id = StateId(""))
        |> ignore

    /// <inheritdoc />
    member this.GetProfileDocument(agent: IAgent, id: ProfileId) =
        None // todo: implement

    /// <inheritdoc />
    member this.GetProfileDocuments(agent: IAgent, [<Optional>] ?date: DateTime option) =
        Seq.empty

    interface IAgentProfileResource with
        member this.PutProfileDocument doc = this.PutProfileDocument doc
        member this.DeleteProfileDocument(agent, id) = this.DeleteProfileDocument(agent, id)
        member this.GetProfileDocument(agent, id) = this.GetProfileDocument(agent, id)
        member this.GetProfileDocuments(agent, date) = this.GetProfileDocuments(agent, date)

type private InMemoryAgentEndpoint =
    new() = { }

    /// <inheritdoc />
    member this.GetPerson(agent: IAgent) =
        Seq.empty // todo: implement

    interface IAgentEndpoint with
        member this.Profile = InMemoryAgentProfileResource() :> IAgentProfileResource
        member this.GetPerson agent = this.GetPerson agent

type private InMemoryAboutEndpoint =
    new() = { }

    /// <inheritdoc />
    member this.Information =
            "hi"

    interface IAboutEndpoint with
        member this.Information = this.Information

/// <summary>
/// The "in memory" LRS only stores provided objects for the duration of this instance.
/// </summary>
[<NoEquality;NoComparison>]
type InMemoryLRS =
    val private StatementsResource: InMemoryStatementResource
    val private ActivityEndpoint: InMemoryActivityEndpoint
    val private AgentEndpoint: InMemoryAgentEndpoint
    val private AboutEndpoint: InMemoryAboutEndpoint

    new() =
        { StatementsResource = InMemoryStatementResource(); ActivityEndpoint = InMemoryActivityEndpoint(); AgentEndpoint = InMemoryAgentEndpoint(); AboutEndpoint = InMemoryAboutEndpoint() }

    /// <inheritdoc />
    member this.Statements = this.StatementsResource :> IStatementEndpoint

    /// <inheritdoc />
    member this.Activities = this.ActivityEndpoint :> IActivityEndpoint

    /// <inheritdoc />
    member this.Agents = this.AgentEndpoint :> IAgentEndpoint

    /// <inheritdoc />
    member this.About = this.AboutEndpoint :> IAboutEndpoint

    interface ILRS with
        member this.Statements = InMemoryStatementResource() :> IStatementEndpoint
        member this.Activities = InMemoryActivityEndpoint() :> IActivityEndpoint
        member this.Agents = InMemoryAgentEndpoint() :> IAgentEndpoint
        member this.About = InMemoryAboutEndpoint() :> IAboutEndpoint
