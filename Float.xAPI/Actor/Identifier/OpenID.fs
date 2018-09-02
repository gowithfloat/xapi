// <copyright file="OpenID.cs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

namespace Float.xAPI.Actor.Identifier

open System
open Float.xAPI.Interop

/// <summary>
/// An openID that uniquely identifies the Agent.
/// </summary>
type public IOpenID =
    /// <summary>
    /// An openID that uniquely identifies the Agent.
    /// </summary>
    abstract member OpenID: Uri

    inherit IInverseFunctionalIdentifier

[<StructuralEquality;NoComparison>]
type public OpenID =
    struct
        /// <inheridoc />
        val OpenID: Uri

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Float.xAPI.Actor.Identifier.OpenID"/> class.
        /// </summary>
        /// <param name="openID">An openID that uniquely identifies the Agent.</param>
        new (openID) =
            nullArg openID "openID"
            { OpenID = openID }

        /// <inheritdoc />
        override this.ToString() = sprintf "<%O: %A>" (this.GetType().Name) this.OpenID

        static member op_Equality (lhs: OpenID, rhs: IOpenID) = lhs.Equals(rhs)
        static member op_Inequality (lhs: OpenID, rhs: IOpenID) = not(lhs.Equals(rhs))

        interface IOpenID with
            member this.OpenID = this.OpenID
    end
