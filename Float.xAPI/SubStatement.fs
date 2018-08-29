// <copyright file="SubStatement.cs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

namespace Float.xAPI

open System
open System.Runtime.InteropServices
open Float.xAPI
open Float.xAPI.Actor

/// <summary>
/// A SubStatement is like a StatementRef in that it is included as part of a containing Statement, but unlike a StatementRef, it does not represent an event that has occurred.
/// It can be used to describe, for example, a predication of a potential future Statement or the behavior a teacher looked for when evaluating a student (without representing the student actually doing that behavior).
/// </summary>
type public ISubStatement =
    /// <summary>
    /// A substatement is a statement without an ID.
    /// </summary>
    inherit IGenericStatement

[<NoComparison;NoEquality>]
type public SubStatement =
    struct
        /// <inheritdoc />
        val Actor: IActor

        /// <inheritdoc />
        val Verb: IVerb

        /// <inheritdoc />
        val Object: IObject

        /// <inheritdoc />
        val Result: option<IResult>

        /// <inheritdoc />
        val Context: option<IContext>

        /// <inheritdoc />
        val Timestamp: option<DateTime>

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Float.xAPI.SubStatement"/> struct.
        /// </summary>
        /// <param name="actor">Whom the Statement is about, as an Agent or Group Object.</param>
        /// <param name="verb">Action taken by the Actor.</param>
        /// <param name="object">Activity, Agent, or another Statement that is the Object of the Statement.</param>
        /// <param name="result">Result Object, further details representing a measured outcome.</param>
        /// <param name="context">Context that gives the Statement more meaning.</param>
        /// <param name="timestamp">Timestamp of when the events described within this Statement occurred.</param>
        new (actor, verb, object, [<Optional;DefaultParameterValue(null)>] ?result, [<Optional;DefaultParameterValue(null)>] ?context, [<Optional;DefaultParameterValue(null)>] ?timestamp) =
            if box object :? ISubStatement then invalidArg "object" "Substatements cannot contain substatements"
            { Actor = actor; Verb = verb; Object = object; Result = result; Context = context; Timestamp = timestamp }

        override this.ToString() = sprintf "<%O: Actor %A Verb %A Object %A Result %A Context %A Timestamp %A>" (this.GetType().Name) this.Actor this.Verb this.Object this.Result this.Context this.Timestamp

        member this.ObjectType = (this :> IObject).ObjectType

        interface ISubStatement with
            member this.ObjectType = this.GetType().Name
            member this.Actor = this.Actor
            member this.Verb = this.Verb
            member this.Object = this.Object
            member this.Result = this.Result
            member this.Context = this.Context
            member this.Timestamp = this.Timestamp
    end
