// <copyright file="SequencingInteractionActivityDefinition.fs" company="Float">
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
/// An interaction where the learner is asked to order items in a set.
/// </summary>
type public ISequencingInteractionActivityDefinition =
    /// <summary>
    /// Items in a set that must be ordered.
    /// </summary>
    abstract member Choices: IInteractionComponent seq

    inherit IInteractionActivityDefinition

type public SequencingInteractionActivityDefinition =
    /// <inheritdoc />
    val Name: ILanguageMap option

    /// <inheritdoc />
    val Description: ILanguageMap option

    /// <inheritdoc />
    val MoreInfo: Uri option

    /// <inheritdoc />
    val Extensions: IExtensions option

    /// <summary>
    /// An ordered list of item ids delimited by [,].
    /// </summary>
    val CorrectResponsesPattern: IResponsePattern

    /// <inheritdoc />
    val Choices: IInteractionComponent seq

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Float.xAPI.Activities.Definitions.SequencingInteractionActivityDefinition"/> struct.
    /// </summary>
    /// <param name="correctResponsesPattern">A pattern representing the correct response to the interaction.</param>
    /// <param name="choices">Items in a set that must be ordered.</param>
    /// <param name="name">The human readable/visual name of the Activity.</param>
    /// <param name="description">A description of the Activity.</param>
    /// <param name="moreInfo">Resolves to a document with human-readable information about the Activity.</param>
    /// <param name="extensions">A map of other properties as needed.</param>
    new(correctResponsesPattern, choices, [<Optional;DefaultParameterValue(null)>] ?name, [<Optional;DefaultParameterValue(null)>] ?description, [<Optional;DefaultParameterValue(null)>] ?moreInfo, [<Optional;DefaultParameterValue(null)>] ?extensions) =
        nullArg correctResponsesPattern "correctResponsesPattern"
        nullArg choices "choices"
        emptySeqArg choices "choices"
        emptyOptionalSeqArg extensions "extensions"
        { Name = name; Description = description; CorrectResponsesPattern = correctResponsesPattern; Choices = choices; MoreInfo = moreInfo; Extensions = extensions }

    /// <inheritdoc />
    member this.Type = Definition.InteractionUri

    /// <inheritdoc />
    member this.InteractionType = Sequencing

    interface ISequencingInteractionActivityDefinition with
        member this.Name = this.Name
        member this.Description = this.Description
        member this.Type = this.Type |> Some
        member this.MoreInfo = this.MoreInfo
        member this.Extensions = this.Extensions
        member this.InteractionType = this.InteractionType
        member this.CorrectResponsesPattern = this.CorrectResponsesPattern
        member this.Choices = this.Choices
