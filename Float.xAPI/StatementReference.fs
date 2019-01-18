// <copyright file="StatementReference.cs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

namespace Float.xAPI

open System
open Float.xAPI
open Float.Common.Interop

/// <summary>
/// A Statement Reference is a pointer to another pre-existing Statement.
/// </summary>
type public IStatementReference =
    /// <summary>
    /// The UUID of a Statement.
    /// </summary>
    abstract member Id: Guid

    inherit IObject
    inherit IEquatable<IStatementReference>

[<NoComparison;CustomEquality;Struct>]
type public StatementReference =
    /// <inheritdoc />
    val Id: Guid

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Float.xAPI.StatementReference"/> struct.
    /// </summary>
    /// <param name="id">The UUID of a Statement. Required.</param>
    new (id) =
        if id = Guid() then invalidArg "id" "Default GUID is not valid for a statement reference"
        nullArg id "id" // todo: this might not be necessary; C# won't allow a null Guid
        { Id = id }
        
    /// <inheritdoc />
    override this.GetHashCode() = hash this.Id

    static member op_Equality (lhs: IStatementReference, rhs: IStatementReference) = lhs.Equals(rhs)
    static member op_Inequality (lhs: IStatementReference, rhs: IStatementReference) = not(lhs.Equals(rhs))

    /// <inheritdoc />
    override this.Equals other =
        match other with
        | :? IStatementReference as ref -> this.Id = ref.Id
        | _ -> false

    /// <inheritdoc />
    member this.ObjectType = ObjectType.StatementReference

    interface IStatementReference with
        member this.ObjectType = this.ObjectType
        member this.Id = this.Id
        member this.Equals other = this.Equals other
