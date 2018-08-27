// <copyright file="Score.cs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

namespace Float.xAPI

/// <summary>
/// Represents the outcome of a graded Activity achieved by an Agent.
/// </summary>
type public IScore =
    /// <summary>
    /// The score achieved by the Actor in the experience described by the Statement.
    /// This is not modified by any scaling or normalization.
    /// </summary>
    abstract member Raw: option<float>

    /// <summary>
    /// The lowest possible score for the experience described by the Statement.
    /// </summary>
    abstract member Min: option<float>

    /// <summary>
    /// The highest possible score for the experience described by the Statement.
    /// </summary>
    abstract member Max: option<float>

    /// <summary>
    /// The score related to the experience as modified by scaling and/or normalization.
    /// </summary>
    abstract member Scaled: float

[<NoComparison;NoEquality>]
type public Score =
    struct
        /// <inheritdoc />
        val Raw: option<float>

        /// <inheritdoc />
        val Min: option<float>

        /// <inheritdoc />
        val Max: option<float>

        /// <inheritdoc />
        val Scaled: float

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Float.xAPI.Score"/> struct.
        /// </summary>
        /// <param name="scaled">The score related to the experience as modified by scaling and/or normalization.</param>
        /// <param name="raw">The score achieved by the Actor in the experience described by the Statement.</param>
        /// <param name="min">The lowest possible score for the experience described by the Statement.</param>
        /// <param name="max">The highest possible score for the experience described by the Statement.</param>
        new (scaled, ?raw, ?min, ?max) =
            if raw.Value < 0.0 then invalidArg "raw" "Raw value must be positive"
            if min.Value < 0.0 then invalidArg "min" "Minimum value must be positive"
            if max.Value < 0.0 then invalidArg "max" "Maximum value must be positive"
            { Raw = raw; Min = min; Max = max; Scaled = scaled }

        override this.ToString() = sprintf "<%A: Raw %A Min %A Max %A Scaled %A>" (this.GetType().Name) this.Raw this.Min this.Max this.Scaled

        interface IScore with
            member this.Raw = this.Raw
            member this.Min = this.Min
            member this.Max = this.Max
            member this.Scaled = this.Scaled
    end
