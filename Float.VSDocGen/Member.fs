// <copyright file="Member.fs" company="Float">
// Copyright (c) 2018 Float, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

namespace Float.VSDocGen

//open Float.Interop

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
        let printSum(str: string option) =
            match str with
            | Some sum -> sum.Trim(' ', '\n', '\r')
            | _ -> "No summary."

        let printParam(par: Param option) =
            match par with
            | Some p -> p.ToString()
            | _ -> ""

        let printParams(par: Param seq option) =
            match par with
            | Some p ->"### Parameters\n"// + (par |> Seq.map printParam |> String.concat "\n")
            | _ -> ""

        sprintf "## %O\n%O\n%O" this.Name (printSum this.Summary) (printParams this.Params)
