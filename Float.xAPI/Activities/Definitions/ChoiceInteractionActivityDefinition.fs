// <copyright file="ChoiceInteractionActivityDefinition.fs" company="Float">
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
/// An interaction with a number of possible choices from which the learner can select.
/// This includes interactions in which the learner can select only one answer from the list and those where the learner can select multiple items.
/// </summary>
type public IChoiceInteractionActivityDefinition =
    /// <summary>
    /// Choices associated with this interaction.
    /// </summary>
    abstract member Choices: IInteractionComponent seq

    inherit IInteractionActivityDefinition

[<NoEquality;NoComparison;Struct>]
type public ChoiceInteractionActivityDefinition =
    /// <inheritdoc />
    val Name: ILanguageMap

    /// <inheritdoc />
    val Description: ILanguageMap

    /// <inheritdoc />
    val MoreInfo: Uri option

    /// <inheritdoc />
    val Extensions: IExtensions option

    /// <summary>
    /// A list of item ids delimited by [,]. If the response contains only one item, the delimiter MUST not be used.
    /// </summary>
    val CorrectResponsesPattern: IResponsePattern

    /// <inheritdoc />
    val Choices: IInteractionComponent seq

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Float.xAPI.Activities.Definitions.ChoiceInteractionActivityDefinition"/> struct.
    /// </summary>
    /// <param name="name">The human readable/visual name of the Activity.</param>
    /// <param name="description">A description of the Activity.</param>
    /// <param name="correctResponsesPattern">A pattern representing the correct response to the interaction.</param>
    /// <param name="choices">A list of choices.</param>
    /// <param name="moreInfo">Resolves to a document with human-readable information about the Activity.</param>
    /// <param name="extensions">A map of other properties as needed.</param>
    new(name, description, correctResponsesPattern, choices, [<Optional;DefaultParameterValue(null)>] ?moreInfo, [<Optional;DefaultParameterValue(null)>] ?extensions) =
        nullArg name "name"
        emptySeqArg name "name"
        nullArg description "description"
        emptySeqArg description "description"
        nullArg correctResponsesPattern "correctResponsesPattern"
        nullArg choices "choices"
        emptySeqArg choices "choices"
        { Name = name; Description = description; CorrectResponsesPattern = correctResponsesPattern; Choices = choices; MoreInfo = moreInfo; Extensions = extensions }

    /// <inheritdoc />
    member this.Type = Definition.InteractionUri
    
    /// <inheritdoc />
    member this.InteractionType = Choice

    interface IChoiceInteractionActivityDefinition with
        member this.Name = this.Name
        member this.Description = this.Description
        member this.Type = this.Type
        member this.MoreInfo = this.MoreInfo
        member this.Extensions = this.Extensions
        member this.InteractionType = this.InteractionType
        member this.CorrectResponsesPattern = this.CorrectResponsesPattern
        member this.Choices = this.Choices
