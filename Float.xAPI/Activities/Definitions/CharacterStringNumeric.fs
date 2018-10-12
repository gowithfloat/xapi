// <copyright file="CharacterStringNumeric.fs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

namespace Float.xAPI.Activities.Definitions

open System.Runtime.InteropServices
open Float.xAPI.Interop

/// <summary>
/// A range of numbers represented by a minimum and maximum.
/// Where the range does not have a minimum or maximum, that number is omitted.
/// </summary>
[<NoEquality;NoComparison;Struct>]
type CharacterStringNumeric =
    /// <inheritdoc />
    val Min: int option

    /// <inheritdoc />
    val Max: int option

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Float.xAPI.Activities.Definitions.CharacterString"/> struct.
    /// Use this for numeric interactions.
    /// </summary>
    /// <param name="min">The minimum acceptable response value.</param>
    /// <param name="max">The maximum acceptable response value.</param>
    new ([<Optional;DefaultParameterValue(null)>] ?min: int, [<Optional;DefaultParameterValue(null)>] ?max: int) =
        match (min, max) with
        | (Some n, Some x) -> if x < n then invalidArg "min, max" "Maximum value must be greater than minimum"
        | (None, None) -> invalidArg "min, max" "Must provide a minimum or maximum value"
        | _ -> ()
        { Min = min; Max = max }
    
    /// <inheritdoc />
    member this.Match(i: int): bool =
        match (this.Min, this.Max) with
        | (Some n, Some x) -> i > n && i < x
        | (Some n, None) -> i > n
        | (None, Some x) -> i < x
        | (None, None) -> true
        
    /// <inheritdoc />
    override this.ToString() =
        sprintf "%O[:]%O" (optIntToString this.Min) (optIntToString this.Max)

    interface ICharacterStringNumeric with
        member this.Min = this.Min
        member this.Max = this.Max
        member this.Match i = this.Match i
