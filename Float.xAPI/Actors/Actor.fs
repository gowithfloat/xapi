// <copyright file="Actor.fs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

namespace Float.xAPI.Actors

/// <summary>
/// A discriminated union for every possible actor.
/// </summary>
type public Actor = 
    | Agent of IAgent
    | AnonymousGroup of IAnonymousGroup
    | IdentifiedGroup of IIdentifiedGroup

type public Actor with
    /// <summary>
    /// Retrieve the actor in this instance.
    /// </summary>
    member this.Item =
        match this with
        | Agent agent -> agent :> IActor
        | AnonymousGroup agrp -> agrp :> IActor
        | IdentifiedGroup igrp -> igrp :> IActor

    /// <summary>
    /// A function to create an Actor object from any IActor.
    /// </summary>
    static member From (actor: IActor) =
        match actor with
        | :? IAgent as agent -> Agent agent
        | :? IAnonymousGroup as agrp -> AnonymousGroup agrp
        | :? IIdentifiedGroup as igrp -> IdentifiedGroup igrp
        | _ -> invalidArg "ifi" "Unknown actor"
