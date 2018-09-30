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

// todo: remove this (F# seems to think null is not valid as a default parameter below)
#nowarn "3211"

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
    member this.GetStatements([<Optional;DefaultParameterValue(null)>] actor: IIdentifiedActor option, 
                              [<Optional;DefaultParameterValue(null)>] verbId: Uri option, 
                              [<Optional;DefaultParameterValue(null)>] activityId: Uri option, 
                              [<Optional;DefaultParameterValue(null)>] registration: Guid option, 
                              [<Optional;DefaultParameterValue(null)>] relatedActivities: bool, 
                              [<Optional;DefaultParameterValue(null)>] relatedAgents: bool, 
                              [<Optional;DefaultParameterValue(null)>] since: DateTime option, 
                              [<Optional;DefaultParameterValue(null)>] until: DateTime option, 
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
