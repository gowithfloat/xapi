// <copyright file="Statement.cs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

namespace Float.xAPI.Statements

open System
open System.Runtime.InteropServices
open Float.xAPI
open Float.xAPI.Actor
open Float.Interop

/// <summary>
/// Statements are the evidence for any sort of experience or event which is to be tracked in xAPI.
/// While Statements follow a machine readable JSON format, they can also easily be described using natural language.
/// This can be extremely useful for the design process.
/// Statements are meant to be aggregated and analyzed to provide larger meaning for the overall experience than just the sum of its parts.
/// </summary>
type public IStatement =
    /// <summary>
    /// UUID assigned by LRS if not set by the Learning Record Provider.
    /// </summary>
    abstract member Id: Guid // todo: should this be a lifted type?

    /// <summary>
    /// Timestamp of when this Statement was recorded. Set by LRS.
    /// </summary>
    abstract member Stored: DateTimeOffset option

    /// <summary>
    /// Agent or Group who is asserting this Statement is true.
    /// Verified by the LRS based on authentication.
    /// Set by LRS if not provided or if a strong trust relationship between the Learning Record Provider and LRS has not been established.
    /// </summary>
    abstract member Authority: IActor option

    /// <summary>
    /// The Statement’s associated xAPI version, formatted according to Semantic Versioning 1.0.0.
    /// </summary>
    abstract member Version: IVersion option

    /// <summary>
    /// Attachments to this statement.
    /// </summary>
    abstract member Attachments: IAttachment seq option

    inherit IGenericStatement
    inherit IEquatable<IStatement>

[<NoComparison;CustomEquality;Struct>]
type public Statement = 
    /// <inheritdoc />
    val Id: Guid

    /// <inheritdoc />
    val Actor: Actor

    /// <inheritdoc />
    val Verb: IVerb

    /// <inheritdoc />
    val Object: IObject

    /// <inheritdoc />
    val Result: IResult option

    /// <inheritdoc />
    val Context: IContext option

    /// <inheritdoc />
    val Timestamp: DateTimeOffset option

    /// <inheritdoc />
    val Stored: DateTimeOffset option

    /// <inheritdoc />
    val Authority: IActor option

    /// <inheritdoc />
    val Version: IVersion option

    /// <inheritdoc />
    val Attachments: IAttachment seq option

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Float.xAPI.Statement"/> struct.
    /// </summary>
    /// <param name="actor">Whom the Statement is about, as an Agent or Group Object.</param>
    /// <param name="verb">Action taken by the Actor.</param>
    /// <param name="object">Activity, Agent, or another Statement that is the Object of the Statement.</param>
    /// <param name="id">UUID assigned by LRS if not set by the Learning Record Provider.</param>
    /// <param name="result">Result Object, further details representing a measured outcome.</param>
    /// <param name="context">Context that gives the Statement more meaning.</param>
    /// <param name="timestamp">Timestamp of when the events described within this Statement occurred.</param>
    /// <param name="stored">Timestamp of when this Statement was recorded. Set by LRS.</param>
    /// <param name="authority">Agent or Group who is asserting this Statement is true.</param>
    /// <param name="version">The Statement’s associated xAPI version.</param>
    /// <param name="attachments">Attachments to this statement.</param>
    new(actor, verb, object, [<Optional;DefaultParameterValue(null)>] ?id, [<Optional;DefaultParameterValue(null)>] ?result, [<Optional;DefaultParameterValue(null)>] ?context, [<Optional;DefaultParameterValue(null)>] ?timestamp, [<Optional;DefaultParameterValue(null)>] ?stored, [<Optional;DefaultParameterValue(null)>] ?authority, [<Optional;DefaultParameterValue(null)>] ?version, [<Optional;DefaultParameterValue(null)>] ?attachments) =
        nullArg actor "actor"
        nullArg verb "verb"
        nullArg object "object"
        { Id = (id |? Guid.NewGuid()); Actor = actor; Verb = verb; Object = object; Result = result; Context = context; Timestamp = Some (timestamp |? DateTimeOffset.Now); Stored = stored; Authority = authority; Version = version; Attachments = attachments }

    /// <inheritdoc />
    override this.GetHashCode() = hash this.Id

    /// <inheritdoc />
    override this.Equals other =
        match other with
        | :? IStatement as statement -> this.Id = statement.Id
        | _ -> false

    static member op_Equality (lhs: IStatement, rhs: IStatement) = lhs.Equals(rhs)
    static member op_Inequality (lhs: IStatement, rhs: IStatement) = not(lhs.Equals(rhs))

    interface IStatement with
        member this.Id = this.Id
        member this.Stored = this.Stored
        member this.Authority = this.Authority
        member this.Version = this.Version
        member this.Actor = this.Actor
        member this.Verb = this.Verb
        member this.Object = this.Object
        member this.Result = this.Result
        member this.Context = this.Context
        member this.Timestamp = this.Timestamp
        member this.Attachments = this.Attachments
        member this.Equals other = this.Equals other
