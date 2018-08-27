// <copyright file="ActivityDefinition.cs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

namespace Float.xAPI.Activities.Definitions

open System
open Float.xAPI
open Interop

/// <summary>
/// Metadata associated with an activity.
/// </summary>
type public IActivityDefinition =
    /// <summary>
    /// The human readable/visual name of the Activity.
    /// </summary>
    abstract member Name: ILanguageMap

    /// <summary>
    /// A description of the Activity.
    /// </summary>
    abstract member Description: ILanguageMap

    /// <summary>
    /// The type of Activity.
    /// </summary>
    abstract member Type: Uri

    /// <summary>
    /// Resolves to a document with human-readable information about the Activity, which could include a way to launch the activity. 
    /// </summary>
    abstract member MoreInfo: option<Uri>

    /// <summary>
    /// A map of other properties as needed.
    /// </summary>
    abstract member Extensions: option<IExtensions>

[<NoEquality;NoComparison>]
type public ActivityDefinition =
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
        /// Initializes a new instance of the <see cref="T:Float.xAPI.Activities.ActivityDefinition"/> struct with the minimum required parameters.
        /// </summary>
        /// <param name="name">The human readable/visual name of the Activity.</param>
        /// <param name="description"A description of the Activity.</param>
        /// <param name="thetype">The type of Activity.</param>
        new (name, description, thetype) =
            emptySeqArg name "name"
            emptySeqArg description "description"
            invalidIRIArg thetype "thetype"
            { Name = name; Description = description; Type = thetype; MoreInfo = None; Extensions = None }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Float.xAPI.Activities.ActivityDefinition"/> struct.
        /// </summary>
        /// <param name="name">The human readable/visual name of the Activity.</param>
        /// <param name="description"A description of the Activity.</param>
        /// <param name="thetype">The type of Activity.</param>
        /// <param name="moreInfo">Resolves to a document with human-readable information about the Activity.</param>
        /// <param name="extensions">A map of other properties as needed.</param>
        new(name, description, thetype, ?moreInfo, ?extensions) =
            emptySeqArg name "name"
            emptySeqArg description "description"
            invalidIRIArg thetype "thetype"
            { Name = name; Description = description; Type = thetype; MoreInfo = moreInfo; Extensions = extensions }

        override this.ToString() = sprintf "<%A: Name %A Description %A Type %A MoreInfo %A Extensions %A>" (this.GetType().Name) this.Name this.Description this.Type this.MoreInfo this.Extensions

        interface IActivityDefinition with
            member this.Name = this.Name
            member this.Description = this.Description
            member this.Type = this.Type
            member this.MoreInfo = this.MoreInfo
            member this.Extensions = this.Extensions
    end
    