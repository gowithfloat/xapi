// <copyright file="ProfileId.fs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

namespace Float.xAPI.Resources.Documents

open System
open Float.Interop

/// <summary>
/// The profile id associated with a Profile document.
/// </summary>
[<CustomEquality;NoComparison;Struct>]
type ProfileId =
    val Value: string
    
    /// <summary>
    /// Initializes a new instance of the <see cref="T:Float.xAPI.Resources.Documents.ProfileId"/> struct.
    /// </summary>
    /// <param name="value">Unique within the given context.</param>
    new(value) =
        invalidStringArg value "value"
        { Value = value }

    /// <inheritdoc />
    override this.GetHashCode() = hash this.Value

    /// <inheritdoc />
    override this.Equals other = 
        match other with
        | :? ProfileId as id -> this.Value = id.Value
        | _ -> false

    static member op_Equality (lhs: ProfileId, rhs: ProfileId) = lhs.Equals(rhs)
    static member op_Inequality (lhs: ProfileId, rhs: ProfileId) = not(lhs.Equals(rhs))

    interface IEquatable<ProfileId> with
        member this.Equals other = this.Equals other
