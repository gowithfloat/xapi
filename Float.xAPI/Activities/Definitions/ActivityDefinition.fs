// <copyright file="ActivityDefinition.cs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

namespace Float.xAPI.Activities.Definitions

open System
open System.Runtime.InteropServices
open Float.xAPI
open Float.xAPI.Languages

/// <summary>
/// Metadata associated with an activity.
/// </summary>
type public IActivityDefinition =
    /// <summary>
    /// The human readable/visual name of the Activity.
    /// </summary>
    abstract member Name: ILanguageMap option

    /// <summary>
    /// A description of the Activity.
    /// </summary>
    abstract member Description: ILanguageMap option

    /// <summary>
    /// The type of Activity.
    /// </summary>
    abstract member Type: Uri option

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
    val Name: ILanguageMap option

    /// <inheritdoc />
    val Description: ILanguageMap option

    /// <inheritdoc />
    val Type: Uri option

    /// <inheritdoc />
    val MoreInfo: Uri option

    /// <inheritdoc />
    val Extensions: IExtensions option

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Float.xAPI.Activities.ActivityDefinition"/> struct.
    /// </summary>
    /// <param name="name">The human readable/visual name of the Activity.</param>
    /// <param name="description">A description of the Activity.</param>
    /// <param name="thetype">The type of Activity.</param>
    /// <param name="moreInfo">Resolves to a document with human-readable information about the Activity.</param>
    /// <param name="extensions">A map of other properties as needed.</param>
    new([<Optional;DefaultParameterValue(null)>] ?name, [<Optional;DefaultParameterValue(null)>] ?description, [<Optional;DefaultParameterValue(null)>] ?thetype, [<Optional;DefaultParameterValue(null)>] ?moreInfo, [<Optional;DefaultParameterValue(null)>] ?extensions) =
        { Name = name; Description = description; Type = thetype; MoreInfo = moreInfo; Extensions = extensions }

    interface IActivityDefinition with
        member this.Name = this.Name
        member this.Description = this.Description
        member this.Type = this.Type
        member this.MoreInfo = this.MoreInfo
        member this.Extensions = this.Extensions
    