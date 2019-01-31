// <copyright file="Filters.fs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

namespace Float.xAPI

open System
open System.Collections.Generic
open Float.xAPI.Activities
open Float.xAPI.Actor
open Float.xAPI.Resources.Documents

/// <summary>
/// Functions that can be used to filter statements by LRS implementations.
/// </summary>
module internal Filters =
    /// <summary>
    /// Returns true if the given ID matches the given statement's ID.
    /// </summary>
    let statementIdMatch id (statement: IStatement) =
        statement.Id.Equals(id)

    /// <summary>
    /// Returns true if the given statement's object is a statement reference, and the statement reference's ID matches the given ID.
    /// </summary>
    let statementReferenceIdMatch id (statement: IStatement) =
        match statement.Object with
        | :? IStatementReference as sref -> sref.Id = id
        | _ -> false

    /// <summary>
    /// Returns false if the statement has an identified actor and it doesn't match the given identified actor.
    /// </summary>
    let statementActorMatch (actor: IIdentifiedActor option) (statement: IStatement) =
        match statement.Actor with
        | :? IIdentifiedActor as statementActor ->
            match actor with
            | Some act -> statementActor.IFI = act.IFI
            | None -> true
        | _ -> true

    /// <summary>
    /// Returns false if the statement's verb ID doesn't match the given verb ID.
    /// </summary>
    let statementVerbMatch (verbId: Uri option) (statement: IStatement) =
        match verbId with
        | Some id -> statement.Verb.Id = id
        | None -> true

    /// <summary>
    /// Returns true if the statement's verb ID doesn't match the given verb ID.
    /// </summary>
    let statementVerbMismatch (verbId: Uri option) (statement: IStatement) =
        match verbId with
        | Some id -> statement.Verb.Id <> id
        | None -> false

    /// <summary>
    /// Returns true if the given statement is voided by any statements in the sequence.
    /// </summary>
    let statementNotVoidedIn (statements: IStatement seq) (statement: IStatement) =
        statements 
        |> Seq.where (statementVerbMatch (Some(Verb.Voided.Id)))
        |> Seq.where (statementReferenceIdMatch statement.Id)
        |> Seq.isEmpty

    /// <summary>
    /// Returns false if the statement has an activity as the object, and the activity ID doesn't match the given ID.
    /// </summary>
    let statementActivityMatch (activityId: Uri option) (statement: IStatement) =
        match statement.Object with
        | :? IActivity as statementActivity ->
            match activityId with
            | Some id -> statementActivity.Id = id
            | None -> true
        | _ -> true

    /// <summary>
    /// Returns false if the statement has a context object with a registration property, and the given registration doesn't match that property.
    /// </summary>
    let statementRegistrationMatch (registration: Guid option) (statement: IStatement) =
        match statement.Context with
        | Some context ->
            match context.Registration with
            | Some contextReg ->
                match registration with
                | Some reg -> contextReg = reg
                | None -> true
            | None -> true
        | None -> true
        
    /// <summary>
    /// Returns false if the statement has a timestamp that is before the given time.
    /// </summary>
    let statementSinceMatch (since: DateTime option) (statement: IStatement) =
        match statement.Timestamp with
        | Some timestamp ->
            match since with
            | Some sinc -> timestamp < sinc
            | None -> true
        | None -> true

    /// <summary>
    /// Returns false if the statement has a timestamp that is after the given time.
    /// </summary>
    let statementUntilMatch (until: DateTime option) (statement: IStatement) =
        match statement.Timestamp with
        | Some timestamp ->
            match until with
            | Some unti -> timestamp < unti
            | None -> true
        | None -> true

    /// <summary>
    /// Returns true if the given state ID matches the given document's state ID.
    /// </summary>
    let documentIdMatch (id: StateId) (document: IDocument) =
        id = document.Id

    /// <summary>
    /// Returns the object of the given statement if it is a statement reference, none otherwise.
    /// </summary>
    let getStatementReference (statement: IStatement option) =
        match statement with
        | Some stmt -> match stmt.Object with
                       | :? IStatementReference as sref -> Some sref
                       | _ -> None
        | _ -> None

    /// <summary>
    /// Like Seq.tryFind, but it accepts an optional. If none, this always returns none.
    /// </summary>
    let tryFindOpt toFind sequence =
        match toFind with
        | Some tf -> Seq.tryFind tf sequence
        | None -> None
        
    /// <summary>
    /// Try to find the statement to which a statement reference refers, in a sequence of statements.
    /// </summary>
    let tryFindStatementReferenceSource (statements: IStatement seq) (srefopt: IStatementReference option) =
        match srefopt with
        | Some sref -> statements |> Seq.tryFind (statementIdMatch sref.Id)
        | None -> None
        
    /// <summary>
    /// Remove all of the given keys from the given dictionary.
    /// </summary>
    let removeFrom (dict: Dictionary<'a, 'b>) (keys: 'a seq) =
        for key in keys do
            dict.Remove(key)
            |> ignore

    /// <summary>
    /// Return just the ID for a statement.
    /// </summary>
    let statementToId(statement: IStatement) =
        statement.Id
