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

[<CustomEquality;NoComparison;Struct>]
type OpenID =
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
    override this.ToString() = sprintf "<%O: %A>" (typeName this) this.OpenID

    /// <inheritdoc />
    override this.GetHashCode() = hash this.OpenID

    /// <inheritdoc />
    override this.Equals other = 
        match other with
        | :? IOpenID as openid -> this.OpenID = openid.OpenID
        | _ -> false

    static member op_Equality (lhs: IOpenID, rhs: IOpenID) = lhs.Equals(rhs)
    static member op_Inequality (lhs: IOpenID, rhs: IOpenID) = not(lhs.Equals(rhs))

    interface IOpenID with
        member this.OpenID = this.OpenID
        member this.Equals other = this.Equals other
