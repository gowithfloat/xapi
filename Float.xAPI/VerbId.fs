// <copyright file="VerbId.fs" company="${CopyrightHolder}">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

namespace Float.xAPI

open System
open Float.Interop

/// <summary>
/// Corresponds to a Verb definition.
/// Each Verb definition corresponds to the meaning of a Verb, not the word.
/// </summary>
[<CustomEquality;NoComparison;Struct>]
type VerbId =
    val Iri: Uri
    
    /// <summary>
    /// Initializes a new instance of the <see cref="T:Float.xAPI.VerbId"/> struct.
    /// </summary>
    /// <param name="iri">Corresponds to a Verb definition.</param>
    new(iri) =
        invalidAbsoluteUri iri "iri"
        { Iri = iri }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Float.xAPI.VerbId"/> struct.
    /// </summary>
    /// <param name="iri">Corresponds to a Verb definition.</param>
    new(iri) = VerbId(Uri(iri))

    /// <inheritdoc />
    override this.GetHashCode() = hash this.Iri

    /// <inheritdoc />
    override this.ToString() = this.Iri.AbsoluteUri

    /// <inheritdoc />
    override this.Equals other = 
        match other with
        | :? VerbId as id -> this.Iri = id.Iri
        | _ -> false

    static member op_Equality (lhs: VerbId, rhs: VerbId) = lhs.Equals(rhs)
    static member op_Inequality (lhs: VerbId, rhs: VerbId) = not(lhs.Equals(rhs))

    interface IEquatable<VerbId> with
        member this.Equals other = this.Equals other
