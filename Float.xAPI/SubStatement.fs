// <copyright file="SubStatement.cs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

namespace Float.xAPI

open System
open System.Runtime.InteropServices
open Float.xAPI
open Float.xAPI.Actor
open Float.Common.Interop

/// <summary>
/// A SubStatement is like a StatementRef in that it is included as part of a containing Statement, but unlike a StatementRef, it does not represent an event that has occurred.
/// It can be used to describe, for example, a predication of a potential future Statement or the behavior a teacher looked for when evaluating a student (without representing the student actually doing that behavior).
/// </summary>
type public ISubStatement =
    /// <summary>
    /// A substatement is an object.
    /// </summary>
    inherit IObject

    /// <summary>
    /// A substatement is a statement without an ID.
    /// </summary>
    inherit IGenericStatement

[<NoComparison;NoEquality;Struct>]
type public SubStatement =
    /// <inheritdoc />
    val Actor: IActor

    /// <inheritdoc />
    val Verb: IVerb

    /// <inheritdoc />
    val Object: IObject

    /// <inheritdoc />
    val Result: IResult option

    /// <inheritdoc />
    val Context: IContext option

    /// <inheritdoc />
    val Timestamp: DateTime option

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
        nullArg actor "actor"
        nullArg verb "verb"
        nullArg object "object"
        { Actor = actor; Verb = verb; Object = object; Result = result; Context = context; Timestamp = timestamp }

    /// <inheritdoc />
    member this.ObjectType = ObjectType.SubStatement

    interface ISubStatement with
        member this.ObjectType = this.ObjectType
        member this.Actor = this.Actor
        member this.Verb = this.Verb
        member this.Object = this.Object
        member this.Result = this.Result
        member this.Context = this.Context
        member this.Timestamp = this.Timestamp
