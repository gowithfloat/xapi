// <copyright file="Statement.cs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

namespace Float.xAPI

open System
open Float.xAPI
open Float.xAPI.Actor

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
    abstract member Id: Guid

    /// <summary>
    /// Timestamp of when this Statement was recorded. Set by LRS.
    /// </summary>
    abstract member Stored: option<DateTime>

    /// <summary>
    /// Agent or Group who is asserting this Statement is true.
    /// Verified by the LRS based on authentication.
    /// Set by LRS if not provided or if a strong trust relationship between the Learning Record Provider and LRS has not been established.
    /// </summary>
    abstract member Authority: option<IActor>

    /// <summary>
    /// The Statement’s associated xAPI version, formatted according to Semantic Versioning 1.0.0.
    /// </summary>
    abstract member Version: option<IVersion>

    /// <summary>
    /// Attachments to this statement.
    /// </summary>
    abstract member Attachments: option<seq<IAttachment>>

    inherit IGenericStatement

[<NoComparison;CustomEquality>]
type public Statement = 
    struct
        /// <inheritdoc />
        val Id: Guid

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

        /// <inheritdoc />
        val Stored: option<DateTime>

        /// <inheritdoc />
        val Authority: option<IActor>

        /// <inheritdoc />
        val Version: option<IVersion>

        /// <inheritdoc />
        val Attachments: option<seq<IAttachment>>

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Float.xAPI.Statement"/> struct with the minimum required parameters.
        /// </summary>
        /// <param name="actor">Whom the Statement is about, as an Agent or Group Object.</param>
        /// <param name="verb">Action taken by the Actor.</param>
        /// <param name="object">Activity, Agent, or another Statement that is the Object of the Statement.</param>
        new(actor: IActor, verb: IVerb, object: IObject) =
            { Id = Guid.NewGuid(); Actor = actor; Verb = verb; Object = object; Result = None; Context = None; Timestamp = None; Stored = None; Authority = None; Version = None; Attachments = None }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Float.xAPI.Statement"/> struct.
        /// </summary>
        /// <param name="id">UUID assigned by LRS if not set by the Learning Record Provider.</param>
        /// <param name="actor">Whom the Statement is about, as an Agent or Group Object.</param>
        /// <param name="verb">Action taken by the Actor.</param>
        /// <param name="object">Activity, Agent, or another Statement that is the Object of the Statement.</param>
        /// <param name="result">Result Object, further details representing a measured outcome.</param>
        /// <param name="context">Context that gives the Statement more meaning.</param>
        /// <param name="timestamp">Timestamp of when the events described within this Statement occurred.</param>
        /// <param name="stored">Timestamp of when this Statement was recorded. Set by LRS.</param>
        /// <param name="authority">Agent or Group who is asserting this Statement is true.</param>
        /// <param name="version">The Statement’s associated xAPI version.</param>
        /// <param name="attachments">Attachments to this statement.</param>
        new(id, actor, verb, object, ?result, ?context, ?timestamp, ?stored, ?authority, ?version, ?attachments) =
            { Id = id; Actor = actor; Verb = verb; Object = object; Result = result; Context = context; Timestamp = timestamp; Stored = stored; Authority = authority; Version = version; Attachments = attachments }

        override this.GetHashCode() = hash this.Id
        override this.ToString() = sprintf "%A %A %A %A %A %A %A %A %A %A" this.Id this.Actor this.Object this.Result this.Context this.Timestamp this.Stored this.Authority this.Version this.Attachments
        override this.Equals(other) =
            match other with
            | :? IStatement as statement -> this.Id = statement.Id
            | _ -> false

        interface IEquatable<Statement> with
            member this.Equals other =
                this.Id = other.Id

        member this.ObjectType = (this :> IObject).ObjectType

        interface IStatement with
            member this.ObjectType = this.GetType().Name
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
    end
