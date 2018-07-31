// <copyright file="TrueFalseInteractionActivityDefinition.fs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

namespace Float.xAPI.Activities.Definitions

open System
open Float.xAPI
open Float.xAPI.Activities

/// <summary>
/// An interaction with two possible responses: true or false.
/// </summary>
[<NoEquality;NoComparison>]
type public TrueFalseInteractionActivityDefinition =
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
        /// Either true or false.
        /// </summary>
        val CorrectResponsesPattern: seq<string>

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Float.xAPI.Activities.Definitions.TrueFalseInteractionActivityDefinition"/> struct.
        /// </summary>
        /// <param name="name">The human readable/visual name of the Activity.</param>
        /// <param name="description">A description of the Activity.</param>
        /// <param name="thetype">The type of Activity.</param>
        /// <param name="correctAnswer">The correct answer for this interaction.</param>
        /// <param name="moreInfo">Resolves to a document with human-readable information about the Activity.</param>
        /// <param name="extensions">A map of other properties as needed.</param>
        new(name, description, thetype, correctAnswer: bool, ?moreInfo, ?extensions) =
            { Name = name; Description = description; Type = thetype; CorrectResponsesPattern = Seq.singleton(correctAnswer.ToString()) ; MoreInfo = moreInfo; Extensions = extensions }

        override this.ToString() = sprintf "%A %A %A %A %A %A" this.Name this.Description this.Type this.MoreInfo this.Extensions this.CorrectResponsesPattern

        /// <inheritdoc />
        member this.InteractionType = Interaction.TrueFalse

        interface IInteractionActivityDefinition with
            member this.Name = this.Name
            member this.Description = this.Description
            member this.Type = this.Type
            member this.MoreInfo = this.MoreInfo
            member this.Extensions = this.Extensions
            member this.InteractionType = this.InteractionType
            member this.CorrectResponsesPattern = this.CorrectResponsesPattern
    end
