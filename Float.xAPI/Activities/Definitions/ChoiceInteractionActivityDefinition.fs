// <copyright file="ChoiceInteractionActivityDefinition.fs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

namespace Float.xAPI.Activities.Definitions

open System
open Float.xAPI
open Float.xAPI.Activities

/// <summary>
/// An interaction with a number of possible choices from which the learner can select.
/// This includes interactions in which the learner can select only one answer from the list and those where the learner can select multiple items.
/// </summary>
type public IChoiceInteractionActivityDefinition =
    /// <summary>
    /// Choices associated with this interaction.
    /// </summary>
    abstract member Choices: seq<IInteractionComponent>

    inherit IInteractionActivityDefinition

[<NoEquality;NoComparison>]
type public ChoiceInteractionActivityDefinition =
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
        /// A list of item ids delimited by [,]. If the response contains only one item, the delimiter MUST not be used.
        /// </summary>
        val CorrectResponsesPattern: seq<string>

        /// <inheritdoc />
        val Choices: seq<IInteractionComponent>

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Float.xAPI.Activities.Definitions.ChoiceInteractionActivityDefinition"/> struct.
        /// </summary>
        /// <param name="name">The human readable/visual name of the Activity.</param>
        /// <param name="description"A description of the Activity.</param>
        /// <param name="thetype">The type of Activity.</param>
        /// <param name="correctResponsesPattern">A pattern representing the correct response to the interaction.</param>
        /// <param name="choices">A list of choices.</param>
        /// <param name="moreInfo">Resolves to a document with human-readable information about the Activity.</param>
        /// <param name="extensions">A map of other properties as needed.</param>
        new(name, description, thetype, correctResponsesPattern, choices, ?moreInfo, ?extensions) =
            { Name = name; Description = description; Type = thetype; CorrectResponsesPattern = correctResponsesPattern; Choices = choices; MoreInfo = moreInfo; Extensions = extensions }

        override this.ToString() = sprintf "%A %A %A %A %A %A %A" this.Name this.Description this.Type this.MoreInfo this.Extensions this.CorrectResponsesPattern this.Choices

        member this.InteractionType = Interaction.Choice

        interface IChoiceInteractionActivityDefinition with
            member this.Name = this.Name
            member this.Description = this.Description
            member this.Type = this.Type
            member this.MoreInfo = this.MoreInfo
            member this.Extensions = this.Extensions
            member this.InteractionType = this.InteractionType
            member this.CorrectResponsesPattern = this.CorrectResponsesPattern
            member this.Choices = this.Choices
    end
