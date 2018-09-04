// <copyright file="SHAHash.fs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

namespace Float.xAPI

open System.Runtime.InteropServices
open System.Security.Cryptography
open Interop

/// <summary>
/// Storage for data in SHA1 hash format.
/// </summary>
type public ISHAHash =
    /// <summary>
    /// The encoded data.
    /// </summary>
    abstract member Encoded: seq<byte>

[<StructuralEquality;NoComparison;Struct>]
type public SHAHash =
    /// <inhaeritdoc />
    val Encoded: seq<byte>

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Float.xAPI.SHA1Hash"/> struct.
    /// </summary>
    /// <param name="text">The text to encode.</param>
    /// <param name="algorithm">The algorithm to use when encoding. If none is provided, SHA1 will be used.</param>
    new (text, [<Optional;DefaultParameterValue(null)>] ?algorithm: HashAlgorithm) =
        invalidStringArg text "text"
        { Encoded = computeSha(text, algorithm |? (SHA1.Create() :> HashAlgorithm)) }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Float.xAPI.SHA1Hash"/> struct.
    /// <param name="bytes">The encoded data.</param>
    new (bytes) =
        nullArg bytes "bytes"
        emptySeqArg bytes "bytes"
        { Encoded = bytes }

    /// <inheritdoc />
    override this.ToString() = stringFrom this.Encoded

    static member op_Equality (lhs: SHAHash, rhs: ISHAHash) = lhs.Equals(rhs)
    static member op_Inequality (lhs: SHAHash, rhs: ISHAHash) = not(lhs.Equals(rhs))

    interface ISHAHash with
        member this.Encoded = this.Encoded
