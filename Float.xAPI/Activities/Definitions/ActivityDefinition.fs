// <copyright file="ActivityDefinition.cs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

namespace Float.xAPI.Activities.Definitions

open System
open System.Runtime.InteropServices
open Float.xAPI
open Float.xAPI.Languages
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
    abstract member MoreInfo: Uri option

    /// <summary>
    /// A map of other properties as needed.
    /// </summary>
    abstract member Extensions: IExtensions option

[<NoEquality;NoComparison;Struct>]
type public ActivityDefinition =
    /// <inheritdoc />
    val Name: ILanguageMap

    /// <inheritdoc />
    val Description: ILanguageMap

    /// <inheritdoc />
    val Type: Uri

    /// <inheritdoc />
    val MoreInfo: Uri option

    /// <inheritdoc />
    val Extensions: IExtensions option

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Float.xAPI.Activities.ActivityDefinition"/> struct.
    /// </summary>
    /// <param name="name">The human readable/visual name of the Activity.</param>
    /// <param name="description"A description of the Activity.</param>
    /// <param name="thetype">The type of Activity.</param>
    /// <param name="moreInfo">Resolves to a document with human-readable information about the Activity.</param>
    /// <param name="extensions">A map of other properties as needed.</param>
    new(name, description, thetype, [<Optional;DefaultParameterValue(null)>] ?moreInfo, [<Optional;DefaultParameterValue(null)>] ?extensions) =
        nullArg name "name"
        emptySeqArg name "name"
        nullArg description "description"
        emptySeqArg description "description"
        nullArg thetype "thetype"
        invalidIRIArg thetype "thetype"
        { Name = name; Description = description; Type = thetype; MoreInfo = moreInfo; Extensions = extensions }

    /// <inheritdoc />
    override this.ToString() = 
        sprintf "<%O: Name %O Description %O Type %O%O%O>" (typeName this) (seqToString this.Name) (seqToString this.Description) this.Type (toStringOrNone this.MoreInfo " MoreInfo") (toStringOrNone this.Extensions " Extensions")

    interface IActivityDefinition with
        member this.Name = this.Name
        member this.Description = this.Description
        member this.Type = this.Type
        member this.MoreInfo = this.MoreInfo
        member this.Extensions = this.Extensions
    