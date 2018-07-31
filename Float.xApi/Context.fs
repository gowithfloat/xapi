﻿// <copyright file="Context.cs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

namespace Float.xAPI

open System
open System.Globalization
open Float.xAPI.Actor
open Float.xAPI.Activities

[<NoEquality;NoComparison>]
type public Context =
    struct
        /// <inheritdoc />
        val Registration: option<Guid>

        /// <inheritdoc />
        val Instructor: option<IActor>

        /// <inheritdoc />
        val Team: option<IGroup<obj>>

        /// <inheritdoc />
        val ContextActivities: option<IContextActivities>

        /// <inheritdoc />
        val Revision: option<string>

        /// <inheritdoc />
        val Platform: option<string>

        /// <inheritdoc />
        val Language: option<CultureInfo>

        /// <inheritdoc />
        val Statement: option<IStatementReference>

        /// <inheritdoc />
        val Extensions: option<IExtensions>

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
        new (?registration, ?instructor, ?team, ?contextActivities, ?revision, ?platform, ?language, ?statement, ?extensions) =
            { Registration = registration; Instructor = instructor; Team = team; ContextActivities = contextActivities; Revision = revision; Platform = platform; Language = language; Statement = statement; Extensions = extensions }

        override this.ToString() = sprintf "%A %A %A %A %A %A %A %A %A" this.Registration this.Instructor this.Team this.ContextActivities this.Revision this.Platform this.Language this.Statement this.Extensions

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
    end
