// <copyright file="LikertInteractionActivityDefinition.fs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

namespace Float.xAPI.Activities.Definitions

open System
open System.Runtime.InteropServices
open Float.xAPI
open Float.xAPI.Activities
open Float.Interop
open Float.xAPI.Languages

/// <summary>
/// An interaction which asks the learner to select from a discrete set of choices on a scale.
/// </summary>
type public ILikertInteractionActivityDefinition =
    /// <summary>
    /// A list of discrete choices on a scale.
    /// </summary>
    abstract member Scale: IInteractionComponent seq

    inherit IInteractionActivityDefinition

[<NoEquality;NoComparison;Struct>]
type public LikertInteractionActivityDefinition =
    /// <inheritdoc />
    val Name: ILanguageMap

    /// <inheritdoc />
    val Description: ILanguageMap

    /// <inheritdoc />
    val MoreInfo: Uri option

    /// <inheritdoc />
    val Extensions: IExtensions option

    /// <summary>
    /// A single item id.
    /// </summary>
    val CorrectResponsesPattern: IResponsePattern

    /// <inheritdoc />
    val Scale: IInteractionComponent seq

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Float.xAPI.Activities.Definitions.LikertInteractionActivityDefinition"/> struct.
    /// </summary>
    /// <param name="name">The human readable/visual name of the Activity.</param>
    /// <param name="description">A description of the Activity.</param>
    /// <param name="correctResponsesPattern">A pattern representing the correct response to the interaction.</param>
    /// <param name="scale">A list of discrete choices on a scale.</param>
    /// <param name="moreInfo">Resolves to a document with human-readable information about the Activity.</param>
    /// <param name="extensions">A map of other properties as needed.</param>
    new(name, description, correctResponsesPattern, scale, [<Optional;DefaultParameterValue(null)>] ?moreInfo, [<Optional;DefaultParameterValue(null)>] ?extensions) =
        nullArg name "name"
        emptySeqArg name "name"
        nullArg description "description"
        emptySeqArg description "description"
        nullArg correctResponsesPattern "correctResponsesPattern"
        nullArg scale "scale"
        emptySeqArg scale "scale"
        emptyOptionalSeqArg extensions "extensions"
        { Name = name; Description = description; CorrectResponsesPattern = correctResponsesPattern; Scale = scale; MoreInfo = moreInfo; Extensions = extensions }

    /// <inheritdoc />
    member this.Type = Definition.InteractionUri

    /// <inheritdoc />
    member this.InteractionType = Likert

    interface ILikertInteractionActivityDefinition with
        member this.Name = this.Name
        member this.Description = this.Description
        member this.Type = this.Type
        member this.MoreInfo = this.MoreInfo
        member this.Extensions = this.Extensions
        member this.InteractionType = this.InteractionType
        member this.CorrectResponsesPattern = this.CorrectResponsesPattern
        member this.Scale = this.Scale
