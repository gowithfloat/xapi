// <copyright file="SequencingInteractionActivityDefinition.fs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

namespace Float.xAPI.Activities.Definitions

open System
open System.Runtime.InteropServices
open Float.xAPI
open Float.xAPI.Activities
open Float.xAPI.Interop

/// <summary>
/// An interaction where the learner is asked to order items in a set.
/// </summary>
type public ISequencingInteractionActivityDefinition =
    /// <summary>
    /// Items in a set that must be ordered.
    /// </summary>
    abstract member Choices: seq<IInteractionComponent>

    inherit IInteractionActivityDefinition

type public SequencingInteractionActivityDefinition =
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
        /// An ordered list of item ids delimited by [,].
        /// </summary>
        val CorrectResponsesPattern: seq<string>

        /// <inheritdoc />
        val Choices: seq<IInteractionComponent>

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Float.xAPI.Activities.Definitions.SequencingInteractionActivityDefinition"/> struct.
        /// </summary>
        /// <param name="name">The human readable/visual name of the Activity.</param>
        /// <param name="description"A description of the Activity.</param>
        /// <param name="thetype">The type of Activity.</param>
        /// <param name="correctResponsesPattern">A pattern representing the correct response to the interaction.</param>
        /// <param name="choices">Items in a set that must be ordered.</param>
        /// <param name="moreInfo">Resolves to a document with human-readable information about the Activity.</param>
        /// <param name="extensions">A map of other properties as needed.</param>
        new(name, description, thetype, correctResponsesPattern, choices, [<Optional;DefaultParameterValue(null)>] ?moreInfo, [<Optional;DefaultParameterValue(null)>] ?extensions) =
            nullArg name "name"
            emptySeqArg name "name"
            nullArg description "description"
            emptySeqArg description "description"
            nullArg thetype "thetype"
            { Name = name; Description = description; Type = thetype; CorrectResponsesPattern = correctResponsesPattern; Choices = choices; MoreInfo = moreInfo; Extensions = extensions }

        override this.ToString() = sprintf "<%A: Name %A Description %A Type %A MoreInfo %A Extensions %A CorrectResponsesPattern %A Choices %A>" (this.GetType().Name) this.Name this.Description this.Type this.MoreInfo this.Extensions this.CorrectResponsesPattern this.Choices

        member this.InteractionType = Interaction.Sequencing

        interface IInteractionActivityDefinition with
            member this.Name = this.Name
            member this.Description = this.Description
            member this.Type = this.Type
            member this.MoreInfo = this.MoreInfo
            member this.Extensions = this.Extensions
            member this.InteractionType = this.InteractionType
            member this.CorrectResponsesPattern = this.CorrectResponsesPattern
    end
