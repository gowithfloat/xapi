// <copyright file="Score.cs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

namespace Float.xAPI

open System
open Float.Common.Interop

/// <summary>
/// Represents the outcome of a graded Activity achieved by an Agent.
/// </summary>
type public IScore =
    /// <summary>
    /// The score achieved by the Actor in the experience described by the Statement.
    /// This is not modified by any scaling or normalization.
    /// </summary>
    abstract member Raw: float option

    /// <summary>
    /// The lowest possible score for the experience described by the Statement.
    /// </summary>
    abstract member Min: float option

    /// <summary>
    /// The highest possible score for the experience described by the Statement.
    /// </summary>
    abstract member Max: float option

    /// <summary>
    /// The score related to the experience as modified by scaling and/or normalization.
    /// </summary>
    abstract member Scaled: float

    inherit IEquatable<IScore>
    inherit IComparable<IScore>

[<CustomEquality;CustomComparison;Struct>]
type public Score =
    /// <inheritdoc />
    val Raw: float option

    /// <inheritdoc />
    val Min: float option

    /// <inheritdoc />
    val Max: float option

    /// <inheritdoc />
    val Scaled: float

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Float.xAPI.Score"/> struct.
    /// This constructor will only set the scaled value.
    /// </summary>
    /// <param name="scaled">The score related to the experience as modified by scaling and/or normalization.</param>
    new (scaled) =
        if scaled < -1.0 then invalidArg "scale" "Scale must be from -1 to 1, inclusive"
        if scaled > 1.0 then invalidArg "scale" "Scale must be from -1 to 1, inclusive"
        { Scaled = scaled; Min = None; Max = None; Raw = None }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Float.xAPI.Score"/> struct.
    /// This constructor will compute the scaled value from the given parameters.
    /// </summary>
    /// <param name="raw">The score achieved by the Actor in the experience described by the Statement.</param>
    /// <param name="min">The lowest possible score for the experience described by the Statement.</param>
    /// <param name="max">The highest possible score for the experience described by the Statement.</param>
    new (raw, min, max) =
        if raw < 0.0 then invalidArg "raw" "Raw value must be positive"
        if min < 0.0 then invalidArg "min" "Minimum value must be positive"
        if max < 0.0 then invalidArg "max" "Maximum value must be positive"
        if raw < min then invalidArg "raw" "Raw value must be greater than min"
        if raw > max then invalidArg "raw" "Raw value must be less than max"
        if min >= max then invalidArg "min" "Min value must be less than max"
        if max <= min then invalidArg "max" "Max value must be greater than min"
        { Raw = Some raw; Min = Some min; Max = Some max; Scaled = (raw - min) / (max - min) }
        
    /// <inheritdoc />
    override this.GetHashCode() = hash this.Scaled

    /// <inheritdoc />
    override this.Equals other = 
        match other with
        | :? IScore as score -> this.Scaled = score.Scaled
        | _ -> false

    member this.CompareTo = (this :> IComparable<IScore>).CompareTo
    static member op_LessThan (lhs: Score, rhs: IScore) = lhs.CompareTo(rhs) < 0
    static member op_GreaterThan (lhs: Score, rhs: IScore) = lhs.CompareTo(rhs) > 0
    static member op_Equality (lhs: Score, rhs: IScore) = lhs.Equals(rhs)
    static member op_Inequality (lhs: Score, rhs: IScore) = not(lhs.Equals(rhs))

    interface IScore with
        member this.Raw = this.Raw
        member this.Min = this.Min
        member this.Max = this.Max
        member this.Scaled = this.Scaled
        member this.CompareTo other = this.Scaled.CompareTo(other.Scaled)
        member this.Equals other = this.Equals other
