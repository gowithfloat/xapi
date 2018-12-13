// <copyright file="Document.fs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

namespace Float.xAPI.Resources.Documents

open System
open Float.Common.Interop

/// <summary>
/// The Experience API provides a facility for Learning Record Providers to save arbitrary data in the form of documents, perhaps related to an Activity, Agent, or combination of both.
/// </summary>
type IDocument =
    /// <summary>
    /// Set by Learning Record Provider, unique within the scope of the Agent or Activity.
    /// </summary>
    abstract member Id: StateId

    /// <summary>
    /// When the document was most recently modified.
    /// </summary>
    abstract member Updated: DateTime

    /// <summary>
    /// The contents of the document.
    /// </summary>
    abstract member Contents: Map<string, string>

[<CustomEquality;NoComparison;Struct>]
type Document =
    /// <inheritdoc />
    val Id: StateId

    /// <inheritdoc />
    val Updated: DateTime

    /// <inheritdoc />
    val Contents: Map<string, string>

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Float.xAPI.Resources.Document"/> struct.
    /// </summary>
    /// <param name="id">Unique within the scope of the Agent or Activity.</param>
    /// <param name="updated">When the document was most recently modified.</param>
    /// <param name="contents">The contents of the document.</param>
    new (id, updated, contents) =
        nullArg id "id"
        nullArg updated "updated"
        nullArg contents "contents"
        emptySeqArg contents "contents"
        { Id = id; Updated = updated; Contents = contents }
        
    /// <inheritdoc />
    override this.GetHashCode() = hash this.Id

    /// <inheritdoc />
    override this.ToString() = sprintf "<%O: Id %A Updated %O Contents %O>" (typeName this) this.Id this.Updated this.Contents

    /// <inheritdoc />
    override this.Equals other =
        match other with
        | :? IDocument as document -> this.Id = document.Id
        | _ -> false

    interface IEquatable<IDocument> with
        member this.Equals other = this.Equals other

    interface IDocument with
        member this.Id = this.Id
        member this.Updated = this.Updated
        member this.Contents = this.Contents
