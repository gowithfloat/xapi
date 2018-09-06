// <copyright file="InMemoryLRS.fs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

namespace Float.xAPI

open System
open System.Collections.Generic
open Float.xAPI.Activities
open Float.xAPI.Activities.Definitions
open Float.xAPI.Actor
open Float.xAPI.Actor.Identifier
open Float.xAPI.Languages
open Float.xAPI.Resources
open Float.xAPI.Resources.Documents

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
    member this.GetStatement statementId format attachments =
        this.Statements
            |> List.ofSeq 
            |> List.find (Filters.statementIdMatch statementId)

    /// <inheritdoc />
    member this.GetVoidedStatement voidedStatementId format attachments =
        this.Statements 
            |> List.ofSeq 
            |> List.find (Filters.statementIdMatch voidedStatementId)

    /// <inheritdoc />
    member this.GetStatements agent verb activity registration relatedActivities relatedAgents since until limit format attachments ascending =
        this.Statements 
            |> List.ofSeq 
            |> List.where (Filters.statementPropertyMatch agent verb activity registration relatedActivities relatedAgents since until limit format attachments ascending) 
            |> StatementResult
            :> IStatementResult

    interface IStatementResource with
        member this.PutStatement statement = this.PutStatement statement
        member this.PostStatements statements = this.PostStatements statements
        member this.GetStatement statementId format attachments = this.GetStatement statementId format attachments
        member this.GetVoidedStatement voidedStatementId format attachments = this.GetVoidedStatement voidedStatementId format attachments
        member this.GetStatements agent verb activity registration relatedActivities relatedAgents since until limit format attachments ascending = this.GetStatements agent verb activity registration relatedActivities relatedAgents since until limit format attachments ascending
