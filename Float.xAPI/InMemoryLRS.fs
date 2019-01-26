// <copyright file="InMemoryLRS.fs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

namespace Float.xAPI

open System
open System.Collections.Generic
open System.Runtime.InteropServices
open System.Linq
open Float.xAPI
open Float.xAPI.Activities
open Float.xAPI.Actor
open Float.xAPI.Resources
open Float.xAPI.Resources.Documents

module internal Util =
    let mapStatementToId(statement: IStatement) =
        statement.Id

    let mapDocumentToId(document: IDocument) =
        document.Id

type private InMemoryStatementResource =
    val private Statements: List<IStatement>

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Float.xAPI.InMemoryLRS"/> object.
    /// </summary>
    new () =
        { Statements = List<IStatement>() }

    /// <inheritdoc />
    member this.PutStatement statement = 
        this.Statements.Add(statement)

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
        |> Seq.where (Filters.statementIdMatch statementId)
        |> Seq.where (Filters.statementNotVoidedIn this.Statements)
        |> Seq.tryHead

    /// <inheritdoc />
    member this.GetVoidedStatement(voidedStatementId: Guid, 
                                   [<Optional;DefaultParameterValue(StatementResultFormat.Exact)>] format: StatementResultFormat, 
                                   [<Optional;DefaultParameterValue(false)>] attachments: bool) =
        let voidingStatement = this.Statements 
                               |> Seq.where (Filters.statementVerbMatch (Some(Verb.Voided.Id)))
                               |> Seq.tryFind (Filters.statementReferenceIdMatch voidedStatementId)

        match voidingStatement with
        | None -> None
        | Some vs -> match vs.Object with
                     | :? IStatementReference as sref -> this.Statements
                                                         |> Seq.tryFind (Filters.statementIdMatch sref.Id)
                     | _ -> None

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
        |> Seq.where (Filters.statementActorMatch actor)
        |> Seq.where (Filters.statementVerbMatch verbId)
        |> Seq.where (Filters.statementActivityMatch activityId)
        |> Seq.where (Filters.statementRegistrationMatch registration)
        |> Seq.where (Filters.statementSinceMatch since)
        |> Seq.where (Filters.statementUntilMatch until)
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
    member this.DeleteStateDocument(stateId: StateId, [<Optional>] ?activityId: ActivityId option, [<Optional>] ?agent: IAgent option, [<Optional>] ?registration: Guid option) =
        // todo: filter by activity, agent, registration
        this.Documents.RemoveAll(fun doc -> 
            // todo: simplify this?
            doc.Id = stateId && match (activityId, agent, registration) with
                                | (Some id, Some agent, Some reg) -> true
                                | (Some id, Some agent, None) -> true
                                | (Some id, None, Some reg) -> true
                                | (None, Some agent, Some reg) -> true
                                | (Some id, None, None) -> true
                                | (None, Some agent, None) -> true
                                | (None, None, Some reg) -> true
                                | (None, None, None) -> true
        ) |> ignore

    /// <inheritdoc />
    member this.DeleteStateDocuments(id: ActivityId, agent: IAgent, [<Optional>] ?registration: Guid option) =
        this.Documents.RemoveAll(fun doc ->
            // todo: filter by activity, agent, registration
            match registration with
            | Some reg -> false
            | None -> false
        ) |> ignore

    /// <inheritdoc />
    member this.GetStateDocument(id: StateId, activityId: ActivityId, agent: IAgent, [<Optional>] ?registration: Guid option) =
        this.Documents
        |> List.ofSeq
        |> List.where (Filters.documentIdMatch id)
        // todo: filter by activity ID
        // todo: filter by agent
        // todo: filter by registration
        |> List.tryHead

    /// <inheritdoc />
    member this.GetStateDocuments(id: ActivityId, agent: IAgent, [<Optional>] ?registration: Guid option, [<Optional>] ?date: DateTime option) =
        this.Documents
        // todo: filter by activity ID
        // todo: filter by agent
        // todo: filter by registration
        // todo: filter by date
        |> Seq.map Util.mapDocumentToId

    interface IStateResource with
        member this.PutStateDocument document = this.PutStateDocument document
        member this.DeleteStateDocument(sid, aid, agent, reg) = this.DeleteStateDocument(sid, aid, agent, reg)
        member this.DeleteStateDocuments(aid, agent, reg) = this.DeleteStateDocuments(aid, agent, reg)
        member this.GetStateDocument(sid, aid, agent, reg) = this.GetStateDocument(sid, aid, agent, reg)
        member this.GetStateDocuments(aid, agent, reg, date) = this.GetStateDocuments(aid, agent, reg, date)

type private InMemoryActivityProfileResource =
    val private Documents: Dictionary<ActivityId * ProfileId, IDocument>

    new () =
        { Documents = Dictionary<ActivityId * ProfileId, IDocument>() }

    /// <inheritdoc />
    member this.PutActivityProfileDocument(document: IDocument, aid: ActivityId, pid: ProfileId) =
        this.Documents.[(aid, pid)] = document
        |> ignore

    /// <inheritdoc />
    member this.DeleteActivityProfileDocument(aid: ActivityId, pid: ProfileId) =
        this.Documents.Remove(aid, pid)
        |> ignore

    /// <inheritdoc />
    member this.GetActivityProfileDocument(aid: ActivityId, pid: ProfileId) =
        match this.Documents.ContainsKey((aid, pid)) with
        | true -> Some this.Documents.[(aid, pid)]
        | false -> None

    /// <inheritdoc />
    member this.GetActivityProfileDocuments(aid: ActivityId, date: DateTime option) =
        this.Documents.Where(fun keyval -> (fst keyval.Key) = aid)
        |> Seq.where(fun keyval ->
            match date with
            | Some d -> keyval.Value.Updated < d
            | None -> true)
        |> Seq.map(fun keyval -> snd keyval.Key)

    interface IActivityProfileResource with
        member this.PutActivityProfileDocument(document, aid, pid) = this.PutActivityProfileDocument(document, aid, pid)
        member this.DeleteActivityProfileDocument(aid, pid) = this.DeleteActivityProfileDocument(aid, pid)
        member this.GetActivityProfileDocument(aid, pid) = this.GetActivityProfileDocument(aid, pid)
        member this.GetActivityProfileDocuments(aid, date) = this.GetActivityProfileDocuments(aid, date)

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
    val private Documents: Dictionary<IAgent * ProfileId, IDocument>

    new () =
        { Documents = Dictionary<IAgent * ProfileId, IDocument>() }

    /// <inheritdoc />
    member this.PutProfileDocument(document: IDocument, agent: IAgent, pid: ProfileId) =
        this.Documents.[(agent, pid)] = document
        |> ignore

    /// <inheritdoc />
    member this.DeleteProfileDocument(agent: IAgent, pid: ProfileId) =
        this.Documents.Remove((agent, pid))
        |> ignore

    /// <inheritdoc />
    member this.GetProfileDocument(agent: IAgent, pid: ProfileId) =
        match this.Documents.ContainsKey((agent, pid)) with
        | true -> Some this.Documents.[(agent, pid)]
        | false -> None

    /// <inheritdoc />
    member this.GetProfileDocuments(agent: IAgent, date: DateTime option) =
        this.Documents.Where(fun keyval -> (fst keyval.Key) = agent)
        |> Seq.where(fun keyval ->
            match date with
            | Some d -> keyval.Value.Updated < d
            | None -> true)
        |> Seq.map(fun keyval -> snd keyval.Key)

    interface IAgentProfileResource with
        member this.PutProfileDocument(doc, agent, pid) = this.PutProfileDocument(doc, agent, pid)
        member this.DeleteProfileDocument(agent, pid) = this.DeleteProfileDocument(agent, pid)
        member this.GetProfileDocument(agent, pid) = this.GetProfileDocument(agent, pid)
        member this.GetProfileDocuments(agent, date) = this.GetProfileDocuments(agent, date)

type private InMemoryAgentEndpoint =
    val private AgentProfileResource: InMemoryAgentProfileResource

    new() =
        { AgentProfileResource = InMemoryAgentProfileResource() }

    /// <inheritdoc />
    member this.GetPerson(agent: IAgent) =
        Seq.empty // todo: implement

    interface IAgentEndpoint with
        member this.Profile = this.AgentProfileResource :> IAgentProfileResource
        member this.GetPerson agent = this.GetPerson agent

type private InMemoryAboutEndpoint =
    new() = { }

    /// <inheritdoc />
    member this.Information =
            ([Version(1u, 0u, 3u) :> IVersion] |> Seq.ofList, Seq.empty)

    interface IAboutEndpoint with
        member this.Information() = this.Information

/// <summary>
/// The "in memory" LRS only stores provided objects for the duration of this instance.
/// </summary>
[<NoEquality;NoComparison>]
type InMemoryLRS =
    val private StatementsEndpoint: InMemoryStatementResource
    val private ActivityEndpoint: InMemoryActivityEndpoint
    val private AgentEndpoint: InMemoryAgentEndpoint
    val private AboutEndpoint: InMemoryAboutEndpoint

    new() =
        { StatementsEndpoint = InMemoryStatementResource(); ActivityEndpoint = InMemoryActivityEndpoint(); AgentEndpoint = InMemoryAgentEndpoint(); AboutEndpoint = InMemoryAboutEndpoint() }

    /// <inheritdoc />
    member this.Statements = this.StatementsEndpoint :> IStatementEndpoint

    /// <inheritdoc />
    member this.Activities = this.ActivityEndpoint :> IActivityEndpoint

    /// <inheritdoc />
    member this.Agents = this.AgentEndpoint :> IAgentEndpoint

    /// <inheritdoc />
    member this.About = this.AboutEndpoint :> IAboutEndpoint

    interface ILRS with
        member this.Statements = this.Statements
        member this.Activities = this.Activities
        member this.Agents = this.Agents
        member this.About = this.About
