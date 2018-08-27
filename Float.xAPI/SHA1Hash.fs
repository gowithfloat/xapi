// <copyright file="SHA1Hash.fs" company="">
// Copyright (c) 2018 , All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

namespace Float.xAPI

open System
open Interop

/// <summary>
/// Storage for data in SHA1 hash format.
/// </summary>
type public ISHA1Hash =
    /// <summary>
    /// The encoded data.
    /// </summary>
    abstract member Encoded: byte[]

[<CustomEquality;NoComparison>]
type public SHA1Hash =
    struct
        /// <inheritdoc />
        val Encoded: byte[]

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Float.xAPI.SHA1Hash"/> struct.
        /// </summary>
        /// <param name="text">The text to encode.</param>
        new (text) =
            invalidStringArg text "text"
            { Encoded = computeSha text }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Float.xAPI.SHA1Hash"/> struct.
        /// <param name="bytes">The encoded data.</param>
        new (bytes) =
            nullArg bytes "bytes"
            emptySeqArg bytes "bytes"
            { Encoded = bytes }

        override this.GetHashCode() = hash this.Encoded
        override this.ToString() = stringFrom this.Encoded
        override this.Equals(other) =
            match other with
            | :? ISHA1Hash as sha -> this.Encoded = sha.Encoded
            | _ -> false

        interface IEquatable<ISHA1Hash> with
            member this.Equals other = this.Equals other

        interface ISHA1Hash with
            member this.Encoded = this.Encoded
    end
