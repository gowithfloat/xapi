// <copyright file="Result.cs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

namespace Float.xAPI.Statements

open System
open System.Runtime.InteropServices
open Float.Interop
open Float.xAPI

/// <summary>
/// Represents a measured outcome related to the Statement in which it is included.
/// </summary>
type public IResult = 
    /// <summary>
    /// The score of the Agent in relation to the success or quality of the experience. 
    /// </summary>
    abstract member Score: IScore option

    /// <summary>
    /// Indicates whether or not the attempt on the Activity was successful.
    /// </summary>
    abstract member Success: bool option

    /// <summary>
    /// Indicates whether or not the Activity was completed.
    /// </summary>
    abstract member Completion: bool option

    /// <summary>
    /// A response appropriately formatted for the given Activity.
    /// </summary>
    abstract member Response: string option

    /// <summary>
    /// Period of time over which the Statement occurred.
    /// </summary>
    abstract member Duration: TimeSpan option

    /// <summary>
    /// A map of other properties as needed.
    /// </summary>
    abstract member Extensions: IExtensions option

[<NoComparison;NoEquality;Struct>]
type public Result =
    /// <inheritdoc />
    val Score: IScore option

    /// <inheritdoc />
    val Success: bool option

    /// <inheritdoc />
    val Completion: bool option

    /// <inheritdoc />
    val Response: string option

    /// <inheritdoc />
    val Duration: TimeSpan option

    /// <inheritdoc />
    val Extensions: IExtensions option

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Float.xAPI.Result"/> struct.
    /// </summary>
    /// <param name="score">The score of the Agent in relation to the success or quality of the experience.</param>
    /// <param name="success">Indicates whether or not the attempt on the Activity was successful.</param>
    /// <param name="completion">Indicates whether or not the Activity was completed.</param>
    /// <param name="response">A response appropriately formatted for the given Activity.</param>
    /// <param name="duration">Period of time over which the Statement occurred.</param>
    /// <param name="extensions">A map of other properties as needed.</param>
    new ([<Optional;DefaultParameterValue(null)>] ?score, [<Optional;DefaultParameterValue(null)>] ?success, [<Optional;DefaultParameterValue(null)>] ?completion, [<Optional;DefaultParameterValue(null)>] ?response, [<Optional;DefaultParameterValue(null)>] ?duration, [<Optional;DefaultParameterValue(null)>] ?extensions) =
        invalidOptionalStringArg response "response"
        emptyOptionalSeqArg extensions "extensions"
        { Score = score; Success = success; Completion = completion ; Response = response; Duration = duration; Extensions = extensions }

    interface IResult with
        member this.Score = this.Score
        member this.Success = this.Success
        member this.Completion = this.Completion
        member this.Response = this.Response
        member this.Duration = this.Duration
        member this.Extensions = this.Extensions
