// <copyright file="StatementResult.fs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

namespace Float.xAPI.Resources

open System
open System.Runtime.InteropServices
open Float.xAPI
open Float.xAPI.Interop

/// <summary>
/// A collection of Statements can be retrieved by performing a query on the Statement Resource.
/// </summary>
type IStatementResult =
    /// <summary>
    /// List of Statements.
    /// If the list returned has been limited (due to pagination), and there are more results, they will be located at the "statements" property within the container located at the IRL provided by the "more" property of this Statement result Object.
    /// Where no matching Statements are found, this property will contain an empty array. 
    /// </summary>
    abstract member Statements: IStatement seq

    /// <summary>
    /// Relative IRL that can be used to fetch more results, including the full path and optionally a query string but excluding scheme, host, and port.
    /// Empty string if there are no more results to fetch. 
    /// </summary>
    abstract member More: Uri option

[<NoComparison;NoEquality;Struct>]
type public StatementResult =
    /// <inheritdoc />
    val Statements: IStatement seq

    /// <inheritdoc />
    val More: Uri option
    
    /// <summary>
    /// Initializes a new instance of the <see cref="T:Float.xAPI.Resources.StatementResult"/> struct.
    /// </summary>
    /// <param name="statements">List of statements.</param>
    /// <param name="more">Relative IRL that can be used to fetch more results.</param>
    new (statements, [<Optional;DefaultParameterValue(null)>] ?more) =
        { Statements = statements; More = more }

    /// <inheritdoc />
    override this.ToString() = sprintf "<%O: Statements %O More %O>" (typeName this) this.Statements this.More

    interface IStatementResult with
        member this.Statements = this.Statements
        member this.More = this.More
