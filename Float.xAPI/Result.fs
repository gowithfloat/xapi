// <copyright file="Result.cs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

namespace Float.xAPI

open System
open System.Runtime.InteropServices
open Interop

/// <summary>
/// Represents a measured outcome related to the Statement in which it is included.
/// </summary>
type public IResult = 
    /// <summary>
    /// The score of the Agent in relation to the success or quality of the experience. 
    /// </summary>
    abstract member Score: option<IScore>

    /// <summary>
    /// Indicates whether or not the attempt on the Activity was successful.
    /// </summary>
    abstract member Success: option<bool>

    /// <summary>
    /// Indicates whether or not the Activity was completed.
    /// </summary>
    abstract member Completion: option<bool>

    /// <summary>
    /// A response appropriately formatted for the given Activity.
    /// </summary>
    abstract member Response: option<string>

    /// <summary>
    /// Period of time over which the Statement occurred.
    /// </summary>
    abstract member Duration: option<TimeSpan>

    /// <summary>
    /// A map of other properties as needed.
    /// </summary>
    abstract member Extensions: option<IExtensions>

[<NoComparison;NoEquality>]
type public Result =
    struct
        /// <inheritdoc />
        val Score: option<IScore>

        /// <inheritdoc />
        val Success: option<bool>

        /// <inheritdoc />
        val Completion: option<bool>

        /// <inheritdoc />
        val Response: option<string>

        /// <inheritdoc />
        val Duration: option<TimeSpan>

        /// <inheritdoc />
        val Extensions: option<IExtensions>

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

        override this.ToString() = sprintf "<%A: Score %A Success %A Completion %A Response %A Duration %A Extensions %A>" (this.GetType().Name) this.Score this.Success this.Completion this.Response this.Duration this.Extensions

        interface IResult with
            member this.Score = this.Score
            member this.Success = this.Success
            member this.Completion = this.Completion
            member this.Response = this.Response
            member this.Duration = this.Duration
            member this.Extensions = this.Extensions
    end
