// <copyright file="PerformanceInteractionActivityDefinition.fs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

namespace Float.xAPI.Activities.Definitions

open System
open System.Runtime.InteropServices
open Float.xAPI
open Float.xAPI.Activities
open Float.xAPI.Interop
open Float.xAPI.Languages

/// <summary>
/// An interaction that requires the learner to perform a task that requires multiple steps.
/// </summary>
type public IPerformanceInteractionActivityDefinition =
    /// <summary>
    /// Steps within the task.
    /// </summary>
    abstract member Steps: IInteractionComponent seq

    inherit IInteractionActivityDefinition

[<NoEquality;NoComparison;Struct>]
type public PerformanceInteractionActivityDefinition =
    /// <inheritdoc />
    val Name: ILanguageMap

    /// <inheritdoc />
    val Description: ILanguageMap

    /// <inheritdoc />
    val MoreInfo: Uri option

    /// <inheritdoc />
    val Extensions: IExtensions option

    /// <summary>
    /// A list of steps containing a step ids and the response to that step.
    /// Step ids are separated from responses by [.]. Steps are delimited by [,].
    /// The response can be a String as in a fill-in interaction or a number range as in a numeric interaction.
    /// </summary>
    val CorrectResponsesPattern: IResponsePattern

    /// <inheritdoc />
    val Steps: IInteractionComponent seq

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Float.xAPI.Activities.Definitions.PerformanceInteractionActivityDefinition"/> struct.
    /// </summary>
    /// <param name="name">The human readable/visual name of the Activity.</param>
    /// <param name="description"A description of the Activity.</param>
    /// <param name="correctResponsesPattern">A pattern representing the correct response to the interaction.</param>
    /// <param name="steps">Steps within the task.</param>
    /// <param name="moreInfo">Resolves to a document with human-readable information about the Activity.</param>
    /// <param name="extensions">A map of other properties as needed.</param>
    new(name, description, correctResponsesPattern, steps, [<Optional;DefaultParameterValue(null)>] ?moreInfo, [<Optional;DefaultParameterValue(null)>] ?extensions) =
        nullArg name "name"
        emptySeqArg name "name"
        nullArg description "description"
        emptySeqArg description "description"
        nullArg correctResponsesPattern "correctResponsesPattern"
        nullArg steps "steps"
        emptySeqArg steps "steps"
        { Name = name; Description = description; CorrectResponsesPattern = correctResponsesPattern; Steps = steps; MoreInfo = moreInfo; Extensions = extensions }

    /// <inheritdoc />
    member this.Type = Definition.InteractionUri

    /// <inheritdoc />
    member this.InteractionType = Performance

    interface IPerformanceInteractionActivityDefinition with
        member this.Name = this.Name
        member this.Description = this.Description
        member this.Type = this.Type
        member this.MoreInfo = this.MoreInfo
        member this.Extensions = this.Extensions
        member this.InteractionType = this.InteractionType
        member this.CorrectResponsesPattern = this.CorrectResponsesPattern
        member this.Steps = this.Steps
