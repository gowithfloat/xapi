// <copyright file="Member.fs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

namespace Float.VSDocGen

open Float.Common.Interop

/// <summary>
/// Nearly all useful information in the parsed XML is in the form of a member of some class.
/// </summary>
type Member =
    val Classifier: MemberCategory
    val Name: string
    val Summary: string option
    val Inherited: bool
    val Params: Param seq option

    new (classifier: MemberCategory, name: string, summary: string option, inherited: bool, param: Param seq option) =
        { Classifier = classifier; Name = name; Summary = summary; Inherited = inherited; Params = param }

    /// <inheritdoc />
    override this.ToString() =
        sprintf "%O %O %O %O" this.Classifier this.Name this.Summary (seqToString(this.Params |? Seq.empty))
    