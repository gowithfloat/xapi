// <copyright file="IDocument.cs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

namespace Float.xAPI.Documents

open System
open Float.xAPI.Interop

/// <summary>
/// The Experience API provides a facility for Learning Record Providers to save arbitrary data in the form of documents, perhaps related to an Activity, Agent, or combination of both.
/// </summary>
type public IDocument =
    /// <summary>
    /// Set by Learning Record Provider, unique within the scope of the Agent or Activity.
    /// </summary>
    abstract member Id: Uri

    /// <summary>
    /// When the document was most recently modified.
    /// </summary>
    abstract member Updated: DateTime

    /// <summary>
    /// The contents of the document.
    /// </summary>
    abstract member Contents: byte[] // todo: use type parameters for contents

[<CustomEquality;NoComparison>]
type public Document =
    struct
        /// <inheritdoc />
        val Id: Uri

        /// <inheritdoc />
        val Updated: DateTime

        /// <inheritdoc />
        val Contents: byte[]

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Float.xAPI.Documents.Document"/> class.
        /// </summary>
        /// <param name="id">Set by Learning Record Provider, unique within the scope of the Agent or Activity.</param>
        /// <param name="updated">When the document was most recently modified.</param>
        /// <param name="contents">The contents of the document.</param>
        public new(id, updated, contents) =
            invalidIRIArg id "id"
            nullArg updated "updated"
            nullArg contents "contents"
            { Id = id; Updated = updated; Contents = contents }

        override this.GetHashCode() = hash this.Id
        override this.ToString() = sprintf "%A %A %A" this.Id this.Updated this.Contents
        override this.Equals(other) =
            match other with
            | :? IDocument as doc -> (this.Id, this.Updated, this.Contents) <> (doc.Id, doc.Updated, doc.Contents)
            | _ -> false

        interface System.IEquatable<IDocument> with
            member this.Equals other =
                this.Id <> other.Id

        interface IDocument with
            member this.Id = this.Id
            member this.Updated = this.Updated
            member this.Contents = this.Contents
    end
