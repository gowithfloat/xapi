﻿// <copyright file="PerformanceInteractionActivityDefinition.fs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

namespace Float.xAPI.Activities.Definitions

open System
open Float.xAPI
open Float.xAPI.Activities

/// <summary>
/// An interaction that requires the learner to perform a task that requires multiple steps.
/// </summary>
type public IPerformanceInteractionActivityDefinition =
    /// <summary>
    /// Steps within the task.
    /// </summary>
    abstract member Steps: seq<IInteractionComponent>

    inherit IInteractionActivityDefinition

[<NoEquality;NoComparison>]
type public PerformanceInteractionActivityDefinition =
    struct
        /// <inheritdoc />
        val Name: ILanguageMap

        /// <inheritdoc />
        val Description: ILanguageMap

        /// <inheritdoc />
        val Type: Uri

        /// <inheritdoc />
        val MoreInfo: option<Uri>

        /// <inheritdoc />
        val Extensions: option<IExtensions>

        /// <summary>
        /// A list of steps containing a step ids and the response to that step.
        /// Step ids are separated from responses by [.]. Steps are delimited by [,].
        /// The response can be a String as in a fill-in interaction or a number range as in a numeric interaction.
        /// </summary>
        val CorrectResponsesPattern: seq<string>

        /// <inheritdoc />
        val Steps: seq<IInteractionComponent>

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Float.xAPI.Activities.Definitions."/> struct.
        /// </summary>
        /// <param name="name">The human readable/visual name of the Activity.</param>
        /// <param name="description"A description of the Activity.</param>
        /// <param name="thetype">The type of Activity.</param>
        /// <param name="correctResponsesPattern">A pattern representing the correct response to the interaction.</param>
        /// <param name="steps">Steps within the task.</param>
        /// <param name="moreInfo">Resolves to a document with human-readable information about the Activity.</param>
        /// <param name="extensions">A map of other properties as needed.</param>
        new(name, description, thetype, correctResponsesPattern, steps, ?moreInfo, ?extensions) =
            { Name = name; Description = description; Type = thetype; CorrectResponsesPattern = correctResponsesPattern; Steps = steps; MoreInfo = moreInfo; Extensions = extensions }

        override this.ToString() = sprintf "%A %A %A %A %A %A %A" this.Name this.Description this.Type this.MoreInfo this.Extensions this.CorrectResponsesPattern this.Steps

        member this.InteractionType = Interaction.Performance

        interface IPerformanceInteractionActivityDefinition with
            member this.Name = this.Name
            member this.Description = this.Description
            member this.Type = this.Type
            member this.MoreInfo = this.MoreInfo
            member this.Extensions = this.Extensions
            member this.InteractionType = this.InteractionType
            member this.CorrectResponsesPattern = this.CorrectResponsesPattern
            member this.Steps = this.Steps
    end