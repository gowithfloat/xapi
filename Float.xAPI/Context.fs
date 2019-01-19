// <copyright file="Context.cs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

namespace Float.xAPI

open System
open System.Runtime.InteropServices
open Float.xAPI.Actor
open Float.xAPI.Activities
open Float.Common.Interop
open Float.xAPI.Languages

[<NoEquality;NoComparison;Struct>]
type public Context =
    /// <inheritdoc />
    val Registration: Guid option

    /// <inheritdoc />
    val Instructor: IActor option

    /// <inheritdoc />
    val Team: IGroup option

    /// <inheritdoc />
    val ContextActivities: IContextActivities option

    /// <inheritdoc />
    val Revision: string option

    /// <inheritdoc />
    val Platform: string option

    /// <inheritdoc />
    val Language: ILanguageTag option

    /// <inheritdoc />
    val Statement: IStatementReference option

    /// <inheritdoc />
    val Extensions: IExtensions option

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Float.xAPI.Context"/> struct.
    /// </summary>
    /// <param name="registration">The registration that the Statement is associated with.</param>
    /// <param name="instructor">Instructor that the Statement relates to, if not included as the Actor of the Statement.</param>
    /// <param name="team">Team that this Statement relates to, if not included as the Actor of the Statement.</param>
    /// <param name="contextActivities">A map of the types of learning activity context that this Statement is related to.</param>
    /// <param name="revision">Revision of the learning activity associated with this Statement. Format is free.</param>
    /// <param name="platform">Platform used in the experience of this learning activity.</param>
    /// <param name="language">Code representing the language in which the experience being recorded in this Statement (mainly) occurred in, if applicable and known.</param>
    /// <param name="statement">Another Statement to be considered as context for this Statement.</param>
    /// <param name="extensions">A map of any other domain-specific context relevant to this Statement.</param>
    new ([<Optional;DefaultParameterValue(null)>] ?registration, [<Optional;DefaultParameterValue(null)>] ?instructor, [<Optional;DefaultParameterValue(null)>] ?team, [<Optional;DefaultParameterValue(null)>] ?contextActivities, [<Optional;DefaultParameterValue(null)>] ?revision, [<Optional;DefaultParameterValue(null)>] ?platform, [<Optional;DefaultParameterValue(null)>] ?language, [<Optional;DefaultParameterValue(null)>] ?statement, [<Optional;DefaultParameterValue(null)>] ?extensions) =
        invalidOptionalStringArg revision "revision"
        invalidOptionalStringArg platform "platform"
        emptyOptionalSeqArg extensions "extensions"
        { Registration = registration; Instructor = instructor; Team = team; ContextActivities = contextActivities; Revision = revision; Platform = platform; Language = language; Statement = statement; Extensions = extensions }

    interface IContext with
        member this.Registration = this.Registration
        member this.Instructor = this.Instructor
        member this.Team = this.Team
        member this.ContextActivities = this.ContextActivities
        member this.Revision = this.Revision
        member this.Platform = this.Platform
        member this.Language = this.Language
        member this.Statement = this.Statement
        member this.Extensions = this.Extensions
