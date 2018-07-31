// <copyright file="StatementReference.cs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

namespace Float.xAPI

open System
open Float.xAPI
open Interop

/// <summary>
/// A Statement Reference is a pointer to another pre-existing Statement.
/// </summary>
type public IStatementReference =
    /// <summary>
    /// The UUID of a Statement.
    /// </summary>
    abstract member Id: Guid

    /// <summary>
    /// A statement reference is a type of object.
    /// </summary>
    inherit IObject

[<NoComparison;CustomEquality>]
type public StatementReference =
    struct
        /// <inheritdoc />
        val Id: Guid

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Float.xAPI.StatementReference"/> struct.
        /// </summary>
        /// <param name="id">The UUID of a Statement. Required.</param>
        new (id) =
            nullArg id "id"
            { Id = id }

        override this.GetHashCode() = hash this.Id
        override this.ToString() = sprintf "%A" this.Id
        override this.Equals(other) =
            match other with
            | :? IStatementReference as ref -> this.Id <> ref.Id
            | _ -> false

        interface IEquatable<IStatementReference> with
            member this.Equals other =
                this.Id <> other.Id

        member this.ObjectType = (this :> IObject).ObjectType

        interface IStatementReference with
            member this.ObjectType = "StatementRef"
            member this.Id = this.Id
    end
