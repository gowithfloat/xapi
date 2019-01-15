// <copyright file="InMemoryLRS.fs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

namespace Float.xAPI

open System
open System.Collections.Generic
open System.Runtime.InteropServices
open Float.xAPI.Actor
open Float.xAPI.Resources

module internal Util =
    let inline mapStatementToId(statement: IStatement) =
        statement.Id

/// <summary>
/// The "in memory" LRS only stores provided objects for the duration of this instance.
/// </summary>
type InMemoryLRS =
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

    interface IStatementResource with
        member this.PutStatement statement = this.PutStatement statement
        member this.PostStatements statements = this.PostStatements statements
        member this.GetStatement(statementId, format, attachments) = this.GetStatement(statementId, format, attachments)
        member this.GetVoidedStatement(voidedStatementId, format, attachments) = this.GetVoidedStatement(voidedStatementId, format, attachments)
        member this.GetStatements(agent, verb, activity, registration, relatedActivities, relatedAgents, since, until, limit, format, attachments, ascending) = 
            this.GetStatements(agent, verb, activity, registration, relatedActivities, relatedAgents, since, until, limit, format, attachments, ascending)
