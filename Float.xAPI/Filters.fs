// <copyright file="Filters.fs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

namespace Float.xAPI

open System
open Float.xAPI.Activities
open Float.xAPI.Actor
open Float.xAPI.Resources

/// <summary>
/// Functions that can be used to filter statements by LRS implementations.
/// </summary>
module internal Filters =
    /// <summary>
    /// Returns true if the given ID matches the given statement's ID.
    /// </summary>
    let inline statementIdMatch id (statement: IStatement) = statement.Id = id

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
    /// An overly complicated filter method to return true if the given statement matches the given properties.
    /// </summary>
    let inline statementPropertyMatch (agent: IIdentifiedActor option) (verb: Uri option) (activity: Uri option) (registration: Guid option) (relatedActivities: bool option) (relatedAgents: bool option) (since: DateTime option) (until: DateTime option) (limit: uint option) (format: StatementResultFormat option) (attachments: bool option) (ascending: bool option) (statement: IStatement) =
        match statementActorMatch agent statement with
        | false -> false
        | true ->
            match statementVerbMatch verb statement with
            | false -> false
            | true ->
                match statementActivityMatch activity statement with
                | false -> false
                | true ->
                    match statementRegistrationMatch registration statement with
                    | false -> false
                    | true -> 
                        match statementSinceMatch since statement with
                        | false -> false
                        | true ->
                            match statementUntilMatch until statement with
                            | false -> false
                            | true -> true
